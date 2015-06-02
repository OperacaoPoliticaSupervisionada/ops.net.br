using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace AuditoriaParlamentar.Classes
{
    public class DbEstatisticas
    {
        public static void InsereEstatisticaPesquisa(String tipo, String agrupmento, String perido, String userName, String sql, String anoIni, String mesIni, String anoFim, String mesFim)
        {
            ThreadStart work = delegate
            {
                if (perido != Pesquisa.PERIODO_INFORMAR)
                {
                    anoFim = "";
                    anoIni = "";
                    mesFim = "";
                    mesIni = "";
                }

                using (Banco banco = new Banco())
                {
                    banco.AddParameter("tipo", tipo);
                    banco.AddParameter("agrupamento", agrupmento);
                    banco.AddParameter("periodo", perido);
                    banco.AddParameter("periodo_inicial", anoIni + mesIni);
                    banco.AddParameter("periodo_final", anoFim + mesFim);
                    banco.AddParameter("usuario", userName);
                    banco.AddParameter("sqlCmd", sql);
                    banco.ExecuteNonQuery("INSERT INTO estatistica_pesquisa (tipo, agrupamento, periodo, periodo_inicial, periodo_final, usuario, dataPesquisa, sqlCmd) VALUES (@tipo, @agrupamento, @periodo, @periodo_inicial, @periodo_final, @usuario, NOW(), @sqlCmd)");
                }
            };
            new Thread(work).Start();
        }

    }
}