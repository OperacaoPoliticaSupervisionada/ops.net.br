using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Threading;
using System.Collections;

namespace AuditoriaParlamentar.Classes
{
    public class Denuncia
    {
        internal const String TXT_SITUACAO_AGUARDANDO_REVISAO = "Aguardando Revisão";
        internal const String TXT_SITUACAO_CASO_DUVIDOSO = "Caso Duvidoso";
        internal const String TXT_SITUACAO_CASO_DOSSIE = "Caso Dossiê";
        internal const String TXT_SITUACAO_CASO_REPETIDO = "Caso Repetido";
        internal const String TXT_SITUACAO_NAO_PROCEDE = "Não Procede";
        internal const String TXT_SITUACAO_PENDENTE_INFORMACOES = "Pendente Informação";

        internal const String SITUACAO_AGUARDANDO_REVISAO = "A";
        internal const String SITUACAO_CASO_DUVIDOSO = "P";
        internal const String SITUACAO_CASO_DOSSIE = "D";
        internal const String SITUACAO_CASO_REPETIDO = "R";
        internal const String SITUACAO_NAO_PROCEDE = "N";
        internal const String SITUACAO_PENDENTE_INFORMACOES = "I";

        internal Int64 IdDenuncia { get; set; }
        internal String Cnpj { get; set; }
        internal String RazaoSocial { get; set; }
        internal Int32 PendenteFoto { get; set; }
        internal String UsuarioDenuncia { get; set; }
        internal DateTime DataDenuncia { get; set; }
        internal String Texto { get; set; }
        internal String Situacao { get; set; }
        internal String DesSituacao { get; set; }
        internal String UsuarioAuditoria { get; set; }
        internal DateTime DataAuditoria { get; set; }

        internal static String StringStatus()
        {
            StringBuilder status = new StringBuilder();

            status.Append(" CASE denuncias.Situacao");
            status.Append("     WHEN '" + SITUACAO_AGUARDANDO_REVISAO + "' THEN '" + TXT_SITUACAO_AGUARDANDO_REVISAO + "'");
            status.Append("     WHEN '" + SITUACAO_CASO_DUVIDOSO + "' THEN '" + TXT_SITUACAO_CASO_DUVIDOSO + "'");
            status.Append("     WHEN '" + SITUACAO_CASO_DOSSIE + "' THEN '" + TXT_SITUACAO_CASO_DOSSIE + "'");
            status.Append("     WHEN '" + SITUACAO_CASO_REPETIDO + "' THEN '" + TXT_SITUACAO_CASO_REPETIDO + "'");
            status.Append("     WHEN '" + SITUACAO_NAO_PROCEDE + "' THEN '" + TXT_SITUACAO_NAO_PROCEDE + "'");
            status.Append("     WHEN '" + SITUACAO_PENDENTE_INFORMACOES + "' THEN '" + TXT_SITUACAO_PENDENTE_INFORMACOES + "'");
            status.Append("     ELSE ''");
            status.Append(" END AS Situacao");

            return status.ToString();
        }

        internal Boolean InsereDenuncia()
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("txtCNPJCPF", Cnpj);
                banco.AddParameter("UserNameDenuncia", UsuarioDenuncia);
                banco.AddParameter("Texto", Texto);

                if (banco.ExecuteNonQuery("INSERT INTO denuncias (txtCNPJCPF, UserNameDenuncia, DataDenuncia, Texto, Situacao) VALUES (@txtCNPJCPF, @UserNameDenuncia, NOW(), @Texto, 'A')") == false)
                {
                    return false;
                }

                IdDenuncia = banco.LastInsertedId;

                EnviaEmail();
            }

            return true;
        }

        internal void Carrega(Int64 idDenuncia, String usuario, Boolean revisor)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT denuncias.idDenuncia,");
            sql.Append("       denuncias.txtCNPJCPF,");
            sql.Append("       fornecedores.txtBeneficiario,");
            sql.Append("       fornecedores.PendenteFoto,");
            sql.Append("       denuncias.UserNameDenuncia,");
            sql.Append("       denuncias.DataDenuncia,");
            sql.Append("       denuncias.Texto,");
            sql.Append("       denuncias.Situacao,");
            sql.Append("       denuncias.UserNameAuditoria,");
            sql.Append("       denuncias.DataAuditoria");
            sql.Append("  FROM denuncias, fornecedores");
            sql.Append(" WHERE denuncias.idDenuncia       = @idDenuncia");

            if (!revisor)
                sql.Append("   AND denuncias.UserNameDenuncia = @UserNameDenuncia");
            
            sql.Append("   AND denuncias.txtCNPJCPF       = fornecedores.txtCNPJCPF");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("idDenuncia", idDenuncia);

                if (!revisor)
                    banco.AddParameter("UserNameDenuncia", usuario);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    if (reader.Read())
                    {
                        try { IdDenuncia = Convert.ToInt64(reader["idDenuncia"]); }
                        catch { IdDenuncia = 0; }

                        try { Cnpj = Convert.ToString(reader["txtCNPJCPF"]); }
                        catch { Cnpj = ""; }

                        try { RazaoSocial = Convert.ToString(reader["txtBeneficiario"]); }
                        catch { RazaoSocial = ""; }

                        try { PendenteFoto = Convert.ToInt32(reader["PendenteFoto"]); }
                        catch { PendenteFoto = 0; }

                        try { UsuarioDenuncia = Convert.ToString(reader["UserNameDenuncia"]); }
                        catch { UsuarioDenuncia = ""; }

                        try { DataDenuncia = Convert.ToDateTime(reader["DataDenuncia"]); }
                        catch { }

                        try { Texto = Convert.ToString(reader["Texto"]); }
                        catch { Texto = ""; }

                        try { Situacao = Convert.ToString(reader["Situacao"]); }
                        catch { Situacao = ""; }

                        try { UsuarioAuditoria = Convert.ToString(reader["UserNameAuditoria"]); }
                        catch { UsuarioAuditoria = ""; }

                        try { DataAuditoria = Convert.ToDateTime(reader["DataAuditoria"]); }
                        catch { }

                        switch (Situacao)
                        {
                            case SITUACAO_AGUARDANDO_REVISAO:
                                DesSituacao = TXT_SITUACAO_AGUARDANDO_REVISAO;
                                break;
                            case SITUACAO_CASO_DUVIDOSO:
                                DesSituacao = TXT_SITUACAO_CASO_DUVIDOSO;
                                break;
                            case SITUACAO_CASO_REPETIDO:
                                DesSituacao = TXT_SITUACAO_CASO_REPETIDO;
                                break;
                            case SITUACAO_CASO_DOSSIE:
                                DesSituacao = TXT_SITUACAO_CASO_DOSSIE;
                                break;
                            case SITUACAO_NAO_PROCEDE:
                                DesSituacao = TXT_SITUACAO_NAO_PROCEDE;
                                break;
                            case SITUACAO_PENDENTE_INFORMACOES:
                                DesSituacao = TXT_SITUACAO_PENDENTE_INFORMACOES;
                                break;
                        }
                    }

                    reader.Close();
                }
            }
        }

        internal void AtualizaSituacao(Int64 idDenuncia, String revisor, String situacao)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("UPDATE denuncias");
            sql.Append("   SET Situacao          = @Situacao,");
            sql.Append("       UserNameAuditoria = @UserNameAuditoria,");
            sql.Append("       DataAuditoria     = NOW()");
            sql.Append(" WHERE idDenuncia        = @idDenuncia");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("Situacao", situacao);
                banco.AddParameter("UserNameAuditoria", revisor);
                banco.AddParameter("idDenuncia", idDenuncia);

                banco.ExecuteNonQuery(sql.ToString());
            }
        }

        internal Boolean Existe(String cnpj, String usuario)
        {
            Boolean existe = false;
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT denuncias.idDenuncia");
            sql.Append("  FROM denuncias");
            sql.Append(" WHERE denuncias.txtCNPJCPF       = @txtCNPJCPF");
            sql.Append("   AND denuncias.UserNameDenuncia = @UserNameDenuncia");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("txtCNPJCPF", cnpj);
                banco.AddParameter("UserNameDenuncia", usuario);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    if (reader.Read())
                    {
                        existe = true;

                        try { IdDenuncia = Convert.ToInt64(reader["idDenuncia"]); }
                        catch { IdDenuncia = 0; }
                    }

                    reader.Close();
                }
            }

            return existe;
        }

        internal void DenunciasUsuario(GridView grid, String usuario)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT denuncias.idDenuncia,");
            sql.Append("       denuncias.txtCNPJCPF,");
            sql.Append("       fornecedores.txtBeneficiario,");
            sql.Append("       denuncias.DataDenuncia,");
            sql.Append(StringStatus() + ",");
            sql.Append("       (SELECT 'messages-new.png'");
            sql.Append("          FROM notificacoes");
            sql.Append("         WHERE notificacoes.idDenuncia = denuncias.idDenuncia");
            sql.Append("           AND notificacoes.UserName   = @UserName LIMIT 1) AS nova_msg");
            sql.Append("  FROM denuncias, fornecedores");
            sql.Append(" WHERE denuncias.UserNameDenuncia = @UserNameDenuncia");
            sql.Append("   AND denuncias.txtCNPJCPF       = fornecedores.txtCNPJCPF");
            sql.Append(" ORDER BY idDenuncia");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("UserName", usuario);
                banco.AddParameter("UserNameDenuncia", usuario);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Código";
                    table.Columns[1].ColumnName = "CNPJ/CPF";
                    table.Columns[2].ColumnName = "Razão social";
                    table.Columns[3].ColumnName = "Data da denúncia";
                    table.Columns[4].ColumnName = "Situação";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal void DenunciasFornecedor(GridView grid)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("SELECT denuncias.idDenuncia,");
            sql.Append("       denuncias.DataDenuncia,");
            sql.Append("       denuncias.UserNameDenuncia,");
            sql.Append(StringStatus());           
            sql.Append("  FROM denuncias");
            sql.Append(" WHERE denuncias.txtCNPJCPF =  @txtCNPJCPF");
            sql.Append("   AND denuncias.idDenuncia <> @idDenuncia");
            sql.Append(" ORDER BY idDenuncia");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("txtCNPJCPF", Cnpj);
                banco.AddParameter("idDenuncia", IdDenuncia);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Denúncia";
                    table.Columns[1].ColumnName = "Data da denúncia";
                    table.Columns[2].ColumnName = "Usuário";
                    table.Columns[3].ColumnName = "Situação";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal void DenunciasFornecedorResumida(GridView grid, String cnpj)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT denuncias.idDenuncia, denuncias.DataDenuncia,");
            sql.Append(StringStatus());
            sql.Append("     FROM denuncias");
            sql.Append("    WHERE denuncias.txtCNPJCPF =  @txtCNPJCPF");
            sql.Append(" ORDER BY idDenuncia");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("txtCNPJCPF", cnpj);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Codigo";
                    table.Columns[1].ColumnName = "Data da denúncia";
                    table.Columns[2].ColumnName = "Situação";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal void DenunciasRevisao(GridView grid, Boolean revisao, Boolean duvidoso, Boolean dossie, Boolean naoProcede, Boolean pendenteInformacao, Boolean naoLidas, Boolean repetido)
        {
            StringBuilder sql = new StringBuilder();
            String situacao = "";

            if (revisao == true)
            {
                if (situacao.Length > 0)
                    situacao+= ",'" + SITUACAO_AGUARDANDO_REVISAO + "'";
                else
                    situacao += "'" + SITUACAO_AGUARDANDO_REVISAO + "'";
            }

            if (duvidoso == true)
            {
                if (situacao.Length > 0)
                    situacao += ",'" + SITUACAO_CASO_DUVIDOSO + "'";
                else
                    situacao += "'" + SITUACAO_CASO_DUVIDOSO + "'";
            }

            if (repetido == true)
            {
                if (situacao.Length > 0)
                    situacao += ",'" + SITUACAO_CASO_REPETIDO + "'";
                else
                    situacao += "'" + SITUACAO_CASO_REPETIDO + "'";
            }

            if (dossie == true)
            {
                if (situacao.Length > 0)
                    situacao += ",'" + SITUACAO_CASO_DOSSIE + "'";
                else
                    situacao += "'" + SITUACAO_CASO_DOSSIE + "'";
            }

            if (naoProcede == true)
            {
                if (situacao.Length > 0)
                    situacao += ",'" + SITUACAO_NAO_PROCEDE + "'";
                else
                    situacao += "'" + SITUACAO_NAO_PROCEDE + "'";
            }

            if (pendenteInformacao == true)
            {
                if (situacao.Length > 0)
                    situacao += ",'" + SITUACAO_PENDENTE_INFORMACOES + "'";
                else
                    situacao += "'" + SITUACAO_PENDENTE_INFORMACOES + "'";
            }

            if (situacao.Length == 0)
            {
                situacao = "''";
            }

            sql.Append("SELECT denuncias.idDenuncia,");
            sql.Append("       denuncias.txtCNPJCPF,");
            sql.Append("       fornecedores.txtBeneficiario,");
            sql.Append("       denuncias.DataDenuncia,");
            sql.Append(StringStatus() + ",");
            sql.Append("       denuncias.UsernameDenuncia,");
            sql.Append("       denuncias.UsernameAuditoria,");
            sql.Append("       (SELECT 'messages-new.png'");
            sql.Append("          FROM notificacoes");
            sql.Append("         WHERE notificacoes.idDenuncia = denuncias.idDenuncia");
            sql.Append("           AND notificacoes.UserName   = @UserName LIMIT 1) AS nova_msg");
            sql.Append("  FROM denuncias, fornecedores");

            if (situacao.Length == 3)
                sql.Append(" WHERE (denuncias.Situacao  = " + situacao);
            else
                sql.Append(" WHERE (denuncias.Situacao IN (" + situacao + ")");

            if (naoLidas)
            {
                sql.Append(" OR EXISTS (SELECT 1");
                sql.Append("              FROM notificacoes");
                sql.Append("             WHERE notificacoes.idDenuncia = denuncias.idDenuncia");
                sql.Append("               AND notificacoes.UserName   = @UserName)");
            }

            sql.Append(")");

            sql.Append("   AND denuncias.txtCNPJCPF       = fornecedores.txtCNPJCPF");
            sql.Append(" ORDER BY idDenuncia");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("UserName", System.Web.HttpContext.Current.User.Identity.Name);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "Código";
                    table.Columns[1].ColumnName = "CNPJ/CPF";
                    table.Columns[2].ColumnName = "Razão social";
                    table.Columns[3].ColumnName = "Data da denúncia";
                    table.Columns[4].ColumnName = "Situação";
                    table.Columns[5].ColumnName = "Usuário";
                    table.Columns[6].ColumnName = "Revisor";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal void EnviaEmail()
        {
            ThreadStart work = delegate
            {
                ArrayList destinatarios = new ArrayList();

                using (Banco banco = new Banco())
                {
                    banco.AddParameter("idDenuncia", IdDenuncia);

                    using (MySqlDataReader reader = banco.ExecuteReader("SELECT Email FROM users, usersinroles WHERE usersinroles.Username = users.Username AND usersinroles.Rolename = 'REVISOR'", 300))
                    {
                        while (reader.Read())
                        {
                            destinatarios.Add(reader["Email"].ToString());
                        }
                    }
                }

                StringBuilder corpo = new StringBuilder();

                corpo.Append(@"<html><head><title>O.P.S.</title></head><body><table width=""100%""><tr><td><center><h3>O.P.S. - Operação Política Supervisionada</h3></center></td></tr><tr><td><i>Uma nova denúncia foi feita.</i></td></tr><tr><td><table><tr><td valign=""top""><b>Denúncia:</b></td><td>");
                corpo.Append(@"<a href=""http://www.ops.net.br/Revisao.aspx"">" + IdDenuncia.ToString("0000") + "</a></td></tr>");
                corpo.Append(@"<tr><td valign=""top""><b>Fornecedor:</b></td><td>");
                corpo.Append(Cnpj + " - " + RazaoSocial);
                corpo.Append(@"</td></tr>");
                corpo.Append(@"<tr><td valign=""top""><b>Usuário:</b></td><td>");
                corpo.Append(UsuarioDenuncia);
                corpo.Append(@"</td></tr>");
                corpo.Append(@"<tr><td valign=""top""><b>Texto:</b></td><td>");
                corpo.Append(Texto);
                corpo.Append(@"</td></tr></table></td></tr></table></body></html>");

                Email envio = new Email();
                envio.Enviar(destinatarios, "[O.P.S.] Nova Denúncia", corpo.ToString());
            };
            new Thread(work).Start();
        }
    }
}