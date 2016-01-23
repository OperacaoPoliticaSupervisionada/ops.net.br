using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;

namespace AuditoriaParlamentar.Classes
{
    public class Dossie
    {
        internal Int64 IdDossie { get; set; }
        internal String NomeDossie { get; set; }

        internal Boolean Insere(GridView grid)
        {
            using (Banco banco = new Banco())
            {
                try
                {
                    banco.BeginTransaction();

                    banco.AddParameter("NomeDossie", NomeDossie);
                    banco.ExecuteNonQuery("INSERT INTO dossies (NomeDossie) VALUES (@NomeDossie)");

                    IdDossie = banco.LastInsertedId;

                    InsereParlamenteres(banco, grid);

                    banco.CommitTransaction();
                }
                catch (Exception ex)
                {
                    banco.RollBackTransaction();
                    return false;
                }
            }

            return true;
        }

        internal Boolean Atualiza(GridView grid)
        {
            using (Banco banco = new Banco())
            {
                try
                {
                    banco.BeginTransaction();

                    banco.AddParameter("IdDossie", IdDossie);
                    banco.AddParameter("NomeDossie", NomeDossie);
                    banco.ExecuteNonQuery("UPDATE dossies SET NomeDossie = @NomeDossie WHERE IdDossie = @IdDossie");

                    banco.AddParameter("IdDossie", IdDossie);
                    banco.ExecuteNonQuery("DELETE FROM dossies_parlamentar WHERE IdDossie = @IdDossie");

                    InsereParlamenteres(banco, grid);

                    banco.CommitTransaction();
                }
                catch (Exception ex)
                {
                    banco.RollBackTransaction();
                    return false;
                }
            }

            return true;
        }

        private void InsereParlamenteres(Banco banco, GridView grid)
        {
            foreach (GridViewRow row in grid.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("CheckBoxSelecionar") as CheckBox);

                    if (chkRow.Checked)
                    {
                        banco.AddParameter("IdDossie", IdDossie);
                        banco.AddParameter("IdDenuncia", row.Cells[2].Text);
                        banco.AddParameter("CodigoParlamentar", row.Cells[4].Text);
                        banco.AddParameter("TipoParlamentar", row.Cells[5].Text);
                        banco.ExecuteNonQuery("INSERT INTO dossies_parlamentar (IdDossie, IdDenuncia, CodigoParlamentar, TipoParlamentar) VALUES (@IdDossie, @IdDenuncia, @CodigoParlamentar, @TipoParlamentar)");
                    }
                }
            }
        }

        internal Boolean Excluir()
        {
            using (Banco banco = new Banco())
            {
                try
                {
                    banco.BeginTransaction();

                    banco.AddParameter("IdDossie", IdDossie);
                    banco.ExecuteNonQuery("DELETE FROM dossies WHERE IdDossie = @IdDossie");

                    banco.AddParameter("IdDossie", IdDossie);
                    banco.ExecuteNonQuery("DELETE FROM dossies_parlamentar WHERE IdDossie = @IdDossie");

                    banco.CommitTransaction();
                }
                catch (Exception ex)
                {
                    banco.RollBackTransaction();
                    return false;
                }
            }

            return true;
        }

        internal void Carrega(Int64 idDossie, GridView grid)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT dossies.IdDossie,");
            sql.Append("       dossies.NomeDossie");
            sql.Append("  FROM dossies");
            sql.Append(" WHERE dossies.IdDossie = @IdDossie");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("IdDossie", idDossie);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    if (reader.Read())
                    {
                        try { IdDossie = Convert.ToInt64(reader["IdDossie"]); }
                        catch { IdDossie = 0; }

                        try { NomeDossie = Convert.ToString(reader["NomeDossie"]); }
                        catch { NomeDossie = ""; }
                    }

                    reader.Close();
                }

                sql.Clear();
                sql.Append("   SELECT DISTINCT");

                if (idDossie > 0)
                {
                    sql.Append("          (SELECT 1");
                    sql.Append("             FROM dossies_parlamentar ");
                    sql.Append("            WHERE dossies_parlamentar.IdDossie          = @IdDossie");
                    sql.Append("              AND dossies_parlamentar.IdDenuncia        = denuncias.idDenuncia");
                    sql.Append("              AND dossies_parlamentar.CodigoParlamentar = parlamentares.ideCadastro");
                    sql.Append("              AND dossies_parlamentar.TipoParlamentar   = 'DEPFEDERAL') AS selecionado,");
                }
                else
                {
                    sql.Append("      '' AS selecionado,");
                }

                sql.Append("          denuncias.idDenuncia,");
                sql.Append("	      CONCAT(parlamentares.txNomeParlamentar, ' (DEPUTADO FEDERAL)') AS parlamentar,");
                sql.Append("          parlamentares.ideCadastro AS CodigoParlamentar,");
                sql.Append("          'DEPFEDERAL' AS TipoParlamentar,");
                sql.Append("          (SELECT MAX(dossies.NomeDossie)");
                sql.Append("             FROM dossies_parlamentar, dossies ");
                sql.Append("            WHERE dossies_parlamentar.IdDossie         <> @IdDossie");
                sql.Append("              AND dossies_parlamentar.IdDenuncia        = denuncias.idDenuncia");
                sql.Append("              AND dossies_parlamentar.CodigoParlamentar = parlamentares.ideCadastro");
                sql.Append("              AND dossies_parlamentar.TipoParlamentar   = 'DEPFEDERAL'");
                sql.Append("              AND dossies_parlamentar.IdDossie          = dossies.IdDossie) AS outro_dossie");
                sql.Append("     FROM denuncias, lancamentos, parlamentares");
                sql.Append("    WHERE denuncias.Situacao      = 'D'");
                sql.Append("      AND lancamentos.txtCNPJCPF  = denuncias.txtCNPJCPF ");
                sql.Append("      AND lancamentos.ideCadastro = parlamentares.ideCadastro ");
                sql.Append("    UNION");
                sql.Append("   SELECT DISTINCT");

                if (idDossie > 0)
                {
                    sql.Append("          (SELECT 1");
                    sql.Append("             FROM dossies_parlamentar ");
                    sql.Append("            WHERE dossies_parlamentar.IdDossie          = @IdDossie");
                    sql.Append("              AND dossies_parlamentar.IdDenuncia        = denuncias.idDenuncia");
                    sql.Append("              AND dossies_parlamentar.CodigoParlamentar = senadores.CodigoParlamentar");
                    sql.Append("              AND dossies_parlamentar.TipoParlamentar   = 'SENADOR') AS selecionado,");
                }
                else
                {
                    sql.Append("      '' AS selecionado,");
                }

                sql.Append("          denuncias.idDenuncia,");
                sql.Append("          CONCAT(senadores.NomeParlamentar, ' (SENADOR)') AS parlamentar,");
                sql.Append("          senadores.CodigoParlamentar AS CodigoParlamentar,");
                sql.Append("          'SENADOR' AS TipoParlamentar,");
                sql.Append("          (SELECT MAX(dossies.NomeDossie)");
                sql.Append("             FROM dossies_parlamentar, dossies ");
                sql.Append("            WHERE dossies_parlamentar.IdDossie         <> @IdDossie");
                sql.Append("              AND dossies_parlamentar.IdDenuncia        = denuncias.idDenuncia");
                sql.Append("              AND dossies_parlamentar.CodigoParlamentar = senadores.CodigoParlamentar");
                sql.Append("              AND dossies_parlamentar.TipoParlamentar   = 'SENADOR'");
                sql.Append("              AND dossies_parlamentar.IdDossie          = dossies.IdDossie) AS outro_dossie");
                sql.Append("     FROM denuncias, lancamentos_senadores, senadores");
                sql.Append("    WHERE denuncias.Situacao                      = 'D'");
                sql.Append("      AND lancamentos_senadores.CnpjCpf           = denuncias.txtCNPJCPF");
                sql.Append("      AND lancamentos_senadores.CodigoParlamentar = senadores.CodigoParlamentar ");
                sql.Append(" ORDER BY 1 DESC, 3");

                banco.AddParameter("IdDossie", idDossie);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias");
                    table.Load(reader);

                    table.Columns[1].ColumnName = "Código da Denúncia";
                    table.Columns[2].ColumnName = "Nome do Parlamentar";
                    table.Columns[5].ColumnName = "Já Utilizado?";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal void CarregaDossies(GridView grid)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT DISTINCT");
            sql.Append("          dossies.NomeDossie,");
            sql.Append("	      CONCAT(parlamentares.txNomeParlamentar, ' (DEPUTADO FEDERAL)') AS parlamentar,");
            sql.Append("          dossies.IdDossie,");
            sql.Append("           CAST(CONCAT('~/Figuras/Parlamentares/DEPFEDERAL/', dossies_parlamentar.CodigoParlamentar, '.jpg') AS CHAR) AS FotoParlamentar,");
            sql.Append("           CAST(CONCAT('http://www.camara.leg.br/internet/Deputado/dep_Detalhe.asp?id=', dossies_parlamentar.CodigoParlamentar) AS CHAR) AS UrlParlamentar");
            sql.Append("     FROM dossies, dossies_parlamentar, parlamentares");
            sql.Append("    WHERE dossies_parlamentar.idDossie          = dossies.idDossie");
            sql.Append("      AND dossies_parlamentar.CodigoParlamentar = parlamentares.ideCadastro");
            sql.Append("      AND dossies_parlamentar.TipoParlamentar   = 'DEPFEDERAL'");
            sql.Append("    UNION");
            sql.Append("   SELECT DISTINCT");
            sql.Append("          dossies.NomeDossie,");
            sql.Append("          CONCAT(senadores.NomeParlamentar, ' (SENADOR)') AS parlamentar,");
            sql.Append("          dossies.IdDossie,");
            sql.Append("          CAST(CONCAT('~/Figuras/Parlamentares/SENADOR/', dossies_parlamentar.CodigoParlamentar, '.jpg') AS CHAR) AS FotoParlamentar,");
            sql.Append("          CAST(senadores.url AS CHAR) AS UrlParlamentar");
            sql.Append("     FROM dossies, dossies_parlamentar, senadores");
            sql.Append("    WHERE dossies_parlamentar.idDossie          = dossies.idDossie");
            sql.Append("      AND dossies_parlamentar.CodigoParlamentar = senadores.CodigoParlamentar");
            sql.Append("      AND dossies_parlamentar.TipoParlamentar   = 'SENADOR'");
            sql.Append(" ORDER BY 3, 2");

            using (Banco banco = new Banco())
            {
                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("dossies");
                    table.Load(reader);

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }
    }
}