using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;
using System.Collections;

namespace AuditoriaParlamentar.Classes
{
    public class Fornecedor
    {
        public String IdAtualizacao { get; set; }
        public String Cnpj { get; set; }
        public String DataAbertura { get; set; }
        public String RazaoSocial { get; set; }
        public String NomeFantasia { get; set; }
        public String AtividadePrincipal { get; set; }
        public String NaturezaJuridica { get; set; }
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Cep { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Uf { get; set; }
        public String Situacao { get; set; }
        public String DataSituacao { get; set; }
        public String MotivoSituacao { get; set; }
        public String SituacaoEspecial { get; set; }
        public String DataSituacaoEspecial { get; set; }

        public String Email { get; set; }
        public String Telefone { get; set; }
        public String EnteFederativoResponsavel { get; set; }

        public String AtividadeSecundaria01 { get; set; }
        public String AtividadeSecundaria02 { get; set; }
        public String AtividadeSecundaria03 { get; set; }
        public String AtividadeSecundaria04 { get; set; }
        public String AtividadeSecundaria05 { get; set; }
        public String AtividadeSecundaria06 { get; set; }
        public String AtividadeSecundaria07 { get; set; }
        public String AtividadeSecundaria08 { get; set; }
        public String AtividadeSecundaria09 { get; set; }
        public String AtividadeSecundaria10 { get; set; }
        public String AtividadeSecundaria11 { get; set; }
        public String AtividadeSecundaria12 { get; set; }
        public String AtividadeSecundaria13 { get; set; }
        public String AtividadeSecundaria14 { get; set; }
        public String AtividadeSecundaria15 { get; set; }
        public String AtividadeSecundaria16 { get; set; }
        public String AtividadeSecundaria17 { get; set; }
        public String AtividadeSecundaria18 { get; set; }
        public String AtividadeSecundaria19 { get; set; }
        public String AtividadeSecundaria20 { get; set; }
        public Boolean Doador { get; set; }
        public String UsuarioInclusao { get; set; }
        public DateTime DataInclusao { get; set; }
        public int Matriz { get; internal set; }

        internal Boolean EstaAtualizado(String cnpj)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("Cnpj", cnpj);

                Object retorno = banco.ExecuteScalar("SELECT 1 FROM fornecedores WHERE txtCNPJCPF = @Cnpj AND DataInclusao > DATE_ADD(now(), INTERVAL - 30 DAY)");

                if (retorno != null)
                {
                    if (retorno.ToString() == "1")
                        return true;
                }
            }

            return false;
        }

        internal Int64 PreparaAtualizacao(String UserName)
        {
            Int64 retorno = 0;

            using (Banco banco = new Banco())
            {
                banco.AddParameter("UserName", UserName);

                banco.ExecuteNonQuery("INSERT INTO fornecedores_atu (UserName, Date) VALUES (@UserName, NOW())");
                
                retorno = banco.LastInsertedId;

                banco.ExecuteNonQuery("UPDATE fornecedores_atu SET IdKey = '" + Comum.Encrypt(retorno.ToString()) + "' WHERE id = " + retorno.ToString());

                
            }

            return retorno;
        }

        internal void MarcaVisitado(String UserName)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("txtCNPJCPF", Cnpj);
                banco.AddParameter("UserName", UserName);

                try
                {
                    banco.ExecuteNonQuery("INSERT INTO fornecedores_visitado (txtCNPJCPF, UserName) VALUES (@txtCNPJCPF, @UserName)");
                }
                catch { }
            }
        }

        internal Boolean CarregaDados(String cnpj)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("Cnpj", cnpj);

                using (MySql.Data.MySqlClient.MySqlDataReader reader = banco.ExecuteReader("SELECT * FROM fornecedores WHERE txtCNPJCPF = @Cnpj"))
                {
                    if (reader.Read())
                    {
                        try { Cnpj = Convert.ToString(reader["txtCNPJCPF"]); }
                        catch { Cnpj = ""; }

                        try { DataAbertura = Convert.ToString(reader["DataAbertura"]); }
                        catch { DataAbertura = ""; }

                        try { RazaoSocial = Convert.ToString(reader["txtBeneficiario"]); }
                        catch { RazaoSocial = ""; }

                        try { NomeFantasia = Convert.ToString(reader["NomeFantasia"]); }
                        catch { NomeFantasia = ""; }

                        try { AtividadePrincipal = Convert.ToString(reader["AtividadePrincipal"]); }
                        catch { AtividadePrincipal = ""; }

                        try { NaturezaJuridica = Convert.ToString(reader["NaturezaJuridica"]); }
                        catch { NaturezaJuridica = ""; }

                        try { Logradouro = Convert.ToString(reader["Logradouro"]); }
                        catch { Logradouro = ""; }

                        try { Numero = Convert.ToString(reader["Numero"]); }
                        catch { Numero = ""; }

                        try { Complemento = Convert.ToString(reader["Complemento"]); }
                        catch { Complemento = ""; }

                        try { Cep = Convert.ToString(reader["Cep"]); }
                        catch { Cep = ""; }

                        try { Bairro = Convert.ToString(reader["Bairro"]); }
                        catch { Bairro = ""; }

                        try { Cidade = Convert.ToString(reader["Cidade"]); }
                        catch { Cidade = ""; }

                        try { Uf = Convert.ToString(reader["Uf"]); }
                        catch { Uf = ""; }

                        try { Situacao = Convert.ToString(reader["Situacao"]); }
                        catch { Situacao = ""; }

                        try { DataSituacao = Convert.ToString(reader["DataSituacao"]); }
                        catch { DataSituacao = ""; }

                        try { MotivoSituacao = Convert.ToString(reader["MotivoSituacao"]); }
                        catch { MotivoSituacao = ""; }

                        try { SituacaoEspecial = Convert.ToString(reader["SituacaoEspecial"]); }
                        catch { SituacaoEspecial = ""; }

                        try { Email = Convert.ToString(reader["Email"]); }
                        catch { Email = ""; }

                        try { Telefone = Convert.ToString(reader["Telefone"]); }
                        catch { Telefone = ""; }

                        try { EnteFederativoResponsavel = Convert.ToString(reader["EnteFederativoResponsavel"]); }
                        catch { EnteFederativoResponsavel = ""; }

                        try { AtividadeSecundaria01 = Convert.ToString(reader["AtividadeSecundaria01"]); }
                        catch { AtividadeSecundaria01 = ""; }

                        try { AtividadeSecundaria02 = Convert.ToString(reader["AtividadeSecundaria02"]); }
                        catch { AtividadeSecundaria02 = ""; }

                        try { AtividadeSecundaria03 = Convert.ToString(reader["AtividadeSecundaria03"]); }
                        catch { AtividadeSecundaria03 = ""; }

                        try { AtividadeSecundaria04 = Convert.ToString(reader["AtividadeSecundaria04"]); }
                        catch { AtividadeSecundaria04 = ""; }

                        try { AtividadeSecundaria05 = Convert.ToString(reader["AtividadeSecundaria05"]); }
                        catch { AtividadeSecundaria05 = ""; }

                        try { AtividadeSecundaria06 = Convert.ToString(reader["AtividadeSecundaria06"]); }
                        catch { AtividadeSecundaria06 = ""; }

                        try { AtividadeSecundaria07 = Convert.ToString(reader["AtividadeSecundaria07"]); }
                        catch { AtividadeSecundaria07 = ""; }

                        try { AtividadeSecundaria08 = Convert.ToString(reader["AtividadeSecundaria08"]); }
                        catch { AtividadeSecundaria08 = ""; }

                        try { AtividadeSecundaria09 = Convert.ToString(reader["AtividadeSecundaria09"]); }
                        catch { AtividadeSecundaria09 = ""; }

                        try { AtividadeSecundaria10 = Convert.ToString(reader["AtividadeSecundaria10"]); }
                        catch { AtividadeSecundaria10 = ""; }

                        try { AtividadeSecundaria11 = Convert.ToString(reader["AtividadeSecundaria11"]); }
                        catch { AtividadeSecundaria11 = ""; }

                        try { AtividadeSecundaria12 = Convert.ToString(reader["AtividadeSecundaria12"]); }
                        catch { AtividadeSecundaria12 = ""; }

                        try { AtividadeSecundaria13 = Convert.ToString(reader["AtividadeSecundaria13"]); }
                        catch { AtividadeSecundaria13 = ""; }

                        try { AtividadeSecundaria14 = Convert.ToString(reader["AtividadeSecundaria14"]); }
                        catch { AtividadeSecundaria14 = ""; }

                        try { AtividadeSecundaria15 = Convert.ToString(reader["AtividadeSecundaria15"]); }
                        catch { AtividadeSecundaria15 = ""; }

                        try { AtividadeSecundaria16 = Convert.ToString(reader["AtividadeSecundaria16"]); }
                        catch { AtividadeSecundaria16 = ""; }

                        try { AtividadeSecundaria17 = Convert.ToString(reader["AtividadeSecundaria17"]); }
                        catch { AtividadeSecundaria17 = ""; }

                        try { AtividadeSecundaria18 = Convert.ToString(reader["AtividadeSecundaria18"]); }
                        catch { AtividadeSecundaria18 = ""; }

                        try { AtividadeSecundaria19 = Convert.ToString(reader["AtividadeSecundaria19"]); }
                        catch { AtividadeSecundaria19 = ""; }

                        try { AtividadeSecundaria20 = Convert.ToString(reader["AtividadeSecundaria20"]); }
                        catch { AtividadeSecundaria20 = ""; }

                        try { Doador = Convert.ToBoolean(reader["Doador"]); }
                        catch { Doador = false; }

                        try { DataSituacaoEspecial = Convert.ToString(reader["DataSituacaoEspecial"]); }
                        catch { DataSituacaoEspecial = ""; }

                        try { DataInclusao = Convert.ToDateTime(reader["DataInclusao"]); }
                        catch { DataInclusao = DateTime.MinValue; }
                    }

                    reader.Close();
                }
            }

            return true;
        }

        internal Boolean AtualizaDados()
        {
            Object retorno;

            using (Banco banco = new Banco())
            {
                banco.AddParameter("IdAtualizacao", IdAtualizacao);

                retorno = banco.ExecuteScalar("SELECT 1 FROM fornecedores_atu WHERE IdKey = @IdAtualizacao");

                if (retorno != null)
                {
                    banco.AddParameter("DataAbertura", DataAbertura);
                    banco.AddParameter("RazaoSocial", RazaoSocial);
                    banco.AddParameter("NomeFantasia", NomeFantasia);
                    banco.AddParameter("AtividadePrincipal", AtividadePrincipal);
                    banco.AddParameter("NaturezaJuridica", NaturezaJuridica);
                    banco.AddParameter("Logradouro", Logradouro);
                    banco.AddParameter("Numero", Numero);
                    banco.AddParameter("Complemento", Complemento);
                    banco.AddParameter("Cep", Cep);
                    banco.AddParameter("Bairro", Bairro);
                    banco.AddParameter("Cidade", Cidade);
                    banco.AddParameter("Uf", Uf);
                    banco.AddParameter("Situacao", Situacao);
                    banco.AddParameter("DataSituacao", DataSituacao);
                    banco.AddParameter("MotivoSituacao", MotivoSituacao);
                    banco.AddParameter("SituacaoEspecial", SituacaoEspecial);
                    banco.AddParameter("DataSituacaoEspecial", DataSituacaoEspecial);
                    banco.AddParameter("UsuarioInclusao", UsuarioInclusao);

                    banco.AddParameter("Email", Email);
                    banco.AddParameter("Telefone", Telefone);
                    banco.AddParameter("EnteFederativoResponsavel", EnteFederativoResponsavel);

                    banco.AddParameter("AtividadeSecundaria01", AtividadeSecundaria01);
                    banco.AddParameter("AtividadeSecundaria02", AtividadeSecundaria02);
                    banco.AddParameter("AtividadeSecundaria03", AtividadeSecundaria03);
                    banco.AddParameter("AtividadeSecundaria04", AtividadeSecundaria04);
                    banco.AddParameter("AtividadeSecundaria05", AtividadeSecundaria05);
                    banco.AddParameter("AtividadeSecundaria06", AtividadeSecundaria06);
                    banco.AddParameter("AtividadeSecundaria07", AtividadeSecundaria07);
                    banco.AddParameter("AtividadeSecundaria08", AtividadeSecundaria08);
                    banco.AddParameter("AtividadeSecundaria09", AtividadeSecundaria09);
                    banco.AddParameter("AtividadeSecundaria10", AtividadeSecundaria10);
                    banco.AddParameter("AtividadeSecundaria11", AtividadeSecundaria11);
                    banco.AddParameter("AtividadeSecundaria12", AtividadeSecundaria12);
                    banco.AddParameter("AtividadeSecundaria13", AtividadeSecundaria13);
                    banco.AddParameter("AtividadeSecundaria14", AtividadeSecundaria14);
                    banco.AddParameter("AtividadeSecundaria15", AtividadeSecundaria15);
                    banco.AddParameter("AtividadeSecundaria16", AtividadeSecundaria16);
                    banco.AddParameter("AtividadeSecundaria17", AtividadeSecundaria17);
                    banco.AddParameter("AtividadeSecundaria18", AtividadeSecundaria18);
                    banco.AddParameter("AtividadeSecundaria19", AtividadeSecundaria19);
                    banco.AddParameter("AtividadeSecundaria20", AtividadeSecundaria20);
                    banco.AddParameter("Cnpj", Cnpj);

                    System.Text.StringBuilder sql = new System.Text.StringBuilder();

                    sql.Append("UPDATE fornecedores");
                    sql.Append("   SET txtBeneficiario       = @RazaoSocial,");
                    sql.Append("       NomeFantasia          = @NomeFantasia,");
                    sql.Append("       AtividadePrincipal    = @AtividadePrincipal,");
                    sql.Append("       NaturezaJuridica      = @NaturezaJuridica,");
                    sql.Append("       Logradouro            = @Logradouro,");
                    sql.Append("       Numero                = @Numero,");
                    sql.Append("       Complemento           = @Complemento,");
                    sql.Append("       Cep                   = @Cep,");
                    sql.Append("       Bairro                = @Bairro,");
                    sql.Append("       Cidade                = @Cidade,");
                    sql.Append("       Uf                    = @Uf,");
                    sql.Append("       Situacao              = @Situacao,");
                    sql.Append("       DataSituacao          = @DataSituacao,");
                    sql.Append("       MotivoSituacao        = @MotivoSituacao,");
                    sql.Append("       SituacaoEspecial      = @SituacaoEspecial,");
                    sql.Append("       DataSituacaoEspecial  = @DataSituacaoEspecial,");
                    sql.Append("       DataAbertura          = @DataAbertura,");

                    sql.Append("       Email                = @Email,");
                    sql.Append("       Telefone             = @Telefone,");
                    sql.Append("       EnteFederativoResponsavel = @EnteFederativoResponsavel,");

                    sql.Append("       AtividadeSecundaria01 = @AtividadeSecundaria01,");
                    sql.Append("       AtividadeSecundaria02 = @AtividadeSecundaria02,");
                    sql.Append("       AtividadeSecundaria03 = @AtividadeSecundaria03,");
                    sql.Append("       AtividadeSecundaria04 = @AtividadeSecundaria04,");
                    sql.Append("       AtividadeSecundaria05 = @AtividadeSecundaria05,");
                    sql.Append("       AtividadeSecundaria05 = @AtividadeSecundaria06,");
                    sql.Append("       AtividadeSecundaria07 = @AtividadeSecundaria07,");
                    sql.Append("       AtividadeSecundaria08 = @AtividadeSecundaria08,");
                    sql.Append("       AtividadeSecundaria09 = @AtividadeSecundaria09,");
                    sql.Append("       AtividadeSecundaria10 = @AtividadeSecundaria10,");
                    sql.Append("       AtividadeSecundaria11 = @AtividadeSecundaria11,");
                    sql.Append("       AtividadeSecundaria12 = @AtividadeSecundaria12,");
                    sql.Append("       AtividadeSecundaria13 = @AtividadeSecundaria13,");
                    sql.Append("       AtividadeSecundaria14 = @AtividadeSecundaria14,");
                    sql.Append("       AtividadeSecundaria15 = @AtividadeSecundaria15,");
                    sql.Append("       AtividadeSecundaria15 = @AtividadeSecundaria16,");
                    sql.Append("       AtividadeSecundaria17 = @AtividadeSecundaria17,");
                    sql.Append("       AtividadeSecundaria18 = @AtividadeSecundaria18,");
                    sql.Append("       AtividadeSecundaria19 = @AtividadeSecundaria19,");
                    sql.Append("       AtividadeSecundaria20 = @AtividadeSecundaria20,");
                    sql.Append("       UsuarioInclusao       = @UsuarioInclusao,");
                    sql.Append("       DataInclusao          = NOW()");
                    sql.Append(" WHERE txtCNPJCPF            = @Cnpj");

                    if (banco.ExecuteNonQuery(sql.ToString()) == false)
                    {
                        return false;
                    }

                    banco.AddParameter("IdAtualizacao", IdAtualizacao);
                    banco.ExecuteScalar("DELETE FROM fornecedores_atu WHERE IdKey = @IdAtualizacao");

                    VerificaSeEhDoador(Cnpj);
                }
            }

            return true;
        }

        internal Boolean VerificaSeEhDoador(String cnpj)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("Cnpj", cnpj);

                using (MySql.Data.MySqlClient.MySqlDataReader reader = banco.ExecuteReader("SELECT * FROM fornecedores WHERE txtCNPJCPF = @Cnpj"))
                {
                    if (reader.Read())
                    {
                        try { Doador = Convert.ToBoolean(reader["Doador"]); }
                        catch { Doador = false; }
                    }

                    reader.Close();
                }
            }

            return true;
        }

        internal Boolean IncluirSolicitacaoFoto(String cnpj)
        {
            try
            {
                using (Banco banco = new Banco())
                {
                    StringBuilder sql = new StringBuilder();

                    sql.Append("UPDATE fornecedores");
                    sql.Append("   SET PendenteFoto = 1");
                    sql.Append(" WHERE txtCNPJCPF   = @Cnpj");

                    banco.AddParameter("Cnpj", cnpj);

                    if (banco.ExecuteNonQuery(sql.ToString()) == false)
                    {
                        return false;
                    }

                    EnviaEmail(cnpj);
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        internal Boolean ExcluiSolicitacaoFoto(String cnpj)
        {
            try
            {
                using (Banco banco = new Banco())
                {
                    StringBuilder sql = new StringBuilder();

                    sql.Append("UPDATE fornecedores");
                    sql.Append("   SET PendenteFoto = 0");
                    sql.Append(" WHERE txtCNPJCPF   = @Cnpj");

                    banco.AddParameter("Cnpj", cnpj);

                    if (banco.ExecuteNonQuery(sql.ToString()) == false)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }

        internal void CarregaCidadesPendencias(GridView grid)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT Uf,");
            sql.Append("          Cidade,");
            sql.Append("          COUNT(*) AS pendencias");
            sql.Append("     FROM fornecedores");
            sql.Append("    WHERE PendenteFoto = 1");
            sql.Append(" GROUP BY Uf, Cidade");
            sql.Append(" ORDER BY Uf, Cidade");

            using (Banco banco = new Banco())
            {
                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("fornecedores");
                    table.Load(reader);

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal void CarregaCidadesPendenciasFornecedor(GridView grid)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT Uf,");
            sql.Append("          Cidade,");
            sql.Append("          txtCNPJCPF,");
            sql.Append("          txtBeneficiario");
            sql.Append("     FROM fornecedores");
            sql.Append("    WHERE PendenteFoto = 1");
            sql.Append(" ORDER BY Uf, Cidade");

            using (Banco banco = new Banco())
            {
                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("fornecedores");
                    table.Load(reader);

                    table.Columns[0].ColumnName = "UF";
                    table.Columns[1].ColumnName = "Cidade";
                    table.Columns[2].ColumnName = "CNPJ/CPF";
                    table.Columns[3].ColumnName = "Razão Social";

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal void EnviaEmail(String cnpj)
        {
            ThreadStart work = delegate
            {
                Email envio = new Email();
                StringBuilder corpo = null;

                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT users.Email, fornecedores.Uf, fornecedores.Cidade");
                sql.Append("  FROM fornecedores, users, users_detail");
                sql.Append(" WHERE txtCNPJCPF            = @txtCNPJCPF");
                sql.Append("   AND users_detail.username = users.username");
                sql.Append("   AND users_detail.uf       = fornecedores.Uf");

                using (Banco banco = new Banco())
                {
                    banco.AddParameter("txtCNPJCPF", cnpj);

                    using (DataTable table = banco.GetTable(sql.ToString(), 300))
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (corpo == null)
                            {
                                corpo = new StringBuilder();

                                corpo.Append(@"<html><head><title>O.P.S.</title></head><body><table width=""100%""><tr><td><center><h3>O.P.S. - Operação Política Supervisionada</h3></center></td></tr>");
                                corpo.Append(@"<tr><td>&nbsp;</td></tr>");
                                corpo.Append(@"<tr><td>Precisamos da sua ajuda para levantar informações na cidade de <b>" + row["cidade"] + " - " + row["uf"] + @"</b>. Na maioria das vezes precisamos de uma fotografia atualizada de algum endereço suspeito. Em alguns poucos casos precisamos de documentos na junta comercial. Se você tiver disponibilidade e for maior de 18 anos entre em contado no email <a href=""mailto:luciobig@ops.net.br"">luciobig@ops.net.br</a> para receber as instruções.</td></tr>");
                                corpo.Append(@"<tr><td>&nbsp;</td></tr>");
                                corpo.Append(@"<tr><td>Para visualizar todas as cidades onde precisamos de sua ajuda acesse o <a href=""http://www.ops.net.br/CidadesPendencia.aspx"">Portal da OPS</a>.</td></tr>");
                                corpo.Append(@"</table></body></html>");
                            }
                            
                            ArrayList destinatario = new ArrayList();
                            destinatario.Add(row["Email"]);
                            envio.Enviar(destinatario, "[O.P.S.] Nova Pendência", corpo.ToString());
                        }
                    }
                }
            };
            new Thread(work).Start();
        }
     }
}