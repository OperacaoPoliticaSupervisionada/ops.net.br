using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace AuditoriaParlamentar.Classes
{
    public class Anexos
    {
        internal Int64 IdAnexo { get; set; }
        internal Int64 IdDenuncia { get; set; }
        internal String UserName { get; set; }
        internal DateTime Data { get; set; }
        internal String Arquivo { get; set; }

        internal void Carrega(GridView grid, Int64 idDenuncia)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("   SELECT denuncias_anexo.Arquivo");
            sql.Append("     FROM denuncias_anexo");
            sql.Append("    WHERE denuncias_anexo.idDenuncia = @idDenuncia");
            sql.Append(" ORDER BY denuncias_anexo.idAnexo");

            using (Banco banco = new Banco())
            {
                banco.AddParameter("idDenuncia", idDenuncia);

                using (MySqlDataReader reader = banco.ExecuteReader(sql.ToString(), 300))
                {
                    DataTable table = new DataTable("denuncias_anexo");
                    table.Load(reader);

                    grid.DataSource = table;
                    grid.DataBind();
                }
            }
        }

        internal Boolean InsereAnexo()
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("idDenuncia", IdDenuncia);
                banco.AddParameter("UserName", UserName);
                banco.AddParameter("Arquivo", Arquivo);

                if (banco.ExecuteNonQuery("INSERT INTO denuncias_anexo (idDenuncia, UserName, Data, Arquivo) VALUES (@idDenuncia, @UserName, NOW(), @Arquivo)") == false)
                {
                    return false;
                }

                IdAnexo = banco.LastInsertedId;
            }

            return true;
        }
    }
}