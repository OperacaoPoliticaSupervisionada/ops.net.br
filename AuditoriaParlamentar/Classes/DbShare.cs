using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace AuditoriaParlamentar.Classes
{
    public class DbShare
    {
        public static ParametrosShare Carregar(Int32 id)
        {
            ParametrosShare parametros = null;

            using (Banco banco = new Banco())
            {
                using (MySqlDataReader reader = banco.ExecuteReader("SELECT * FROM share_parametros WHERE id = " + id, 300))
                {
                    if (reader.Read())
                    {
                        parametros = new ParametrosShare();

                        parametros.Cargo = Convert.ToString(reader["cargo"]);
                        parametros.Agrupamento = Convert.ToString(reader["agrupamento"]);
                        parametros.Parlamentares = Convert.ToString(reader["parlamentares"]);
                        parametros.Despesas = Convert.ToString(reader["despesas"]);
                        parametros.Fornecedores = Convert.ToString(reader["fornecedores"]);
                        parametros.Partidos = Convert.ToString(reader["partidos"]);                        
                        parametros.Ufs = Convert.ToString(reader["uf"]);
                        parametros.MesInicial = Convert.ToInt32(reader["mes_inicial"]);
                        parametros.AnoInicial = Convert.ToInt32(reader["ano_inicial"]);
                        parametros.MesFinal = Convert.ToInt32(reader["mes_final"]);
                        parametros.AnoFinal = Convert.ToInt32(reader["ano_final"]);
                    }
                }
            }

            return parametros;
        }

        public static void Incluir(ParametrosShare parametros)
        {
            using (Banco banco = new Banco())
            {
                banco.AddParameter("cargo", parametros.Cargo);
                banco.AddParameter("agrupamento", parametros.Agrupamento);
                banco.AddParameter("parlamentares", parametros.Parlamentares);
                banco.AddParameter("despesas", parametros.Despesas);
                banco.AddParameter("fornecedores", parametros.Fornecedores);
                banco.AddParameter("partidos", parametros.Partidos);
                banco.AddParameter("uf", parametros.Ufs);
                banco.AddParameter("mes_inicial", parametros.MesInicial);
                banco.AddParameter("ano_inicial", parametros.AnoInicial);
                banco.AddParameter("mes_final", parametros.MesFinal);
                banco.AddParameter("ano_final", parametros.AnoFinal);
                banco.ExecuteNonQuery("INSERT INTO share_parametros (cargo, agrupamento, parlamentares, despesas, fornecedores, partidos, uf, mes_inicial, ano_inicial, mes_final, ano_final) VALUES (@cargo, @agrupamento, @parlamentares, @despesas, @fornecedores, @partidos, @uf, @mes_inicial, @ano_inicial, @mes_final, @ano_final)");

                parametros.Id = banco.LastInsertedId;
            }
        }
    }

    public class ParametrosShare
    {
        public long Id { get; set; }
        public String Cargo { get; set; }
        public String Agrupamento { get; set; }
        public String Parlamentares { get; set; }
        public String Despesas { get; set; }
        public String Fornecedores { get; set; }
        public String Partidos { get; set; }
        public String Ufs { get; set; }
        public Int32 MesInicial { get; set; }
        public Int32 AnoInicial { get; set; }
        public Int32 MesFinal { get; set; }
        public Int32 AnoFinal { get; set; }

    }
}