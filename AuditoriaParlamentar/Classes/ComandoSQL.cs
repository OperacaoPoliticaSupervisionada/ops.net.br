using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriaParlamentar.Classes
{
    public static class ComandoSQL
    {
        public enum eGrupoComandoSQL
        {
            /// <summary>
            /// Resumo da Auditoria da Pagina Principal
            /// </summary>
            ResumoAuditoria = 1
        }

        /// <summary>
        /// Executa Consultas Armazenadas que retornam resultado unico (Ex: Select Count(x) ...)
        /// </summary>
        /// <param name="cache"></param>
        /// <param name="Grupo"></param>
        /// <returns></returns>
        public static DataTable ExecutarConsultaSimples(System.Web.Caching.Cache cache, eGrupoComandoSQL Grupo)
        {
            string grupo = Grupo.GetHashCode().ToString();
            DataTable dtResultadoComandoSQL = cache["ResultadoComandoSQL" + grupo] as DataTable;
            if (dtResultadoComandoSQL == null)
            {
                using (Banco banco = new Banco())
                {
                    dtResultadoComandoSQL = banco.GetTable("SELECT Nome, ComandoSQL, '' as Resultado FROM ComandoSQL WHERE Grupo=" + grupo + " ORDER BY Ordem");

                    if (dtResultadoComandoSQL != null)
                    {
                        foreach (DataRow row in dtResultadoComandoSQL.Rows)
                        {
                            row["Resultado"] = banco.ExecuteScalar(row["ComandoSQL"].ToString()).ToString();
                        }
                    }
                }

                try
                {
                    cache.Add("ResultadoComandoSQL" + grupo, dtResultadoComandoSQL, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.Normal, null);
                }
                catch (Exception ex)
                {
                }
            }

            return dtResultadoComandoSQL;
        }
    }
}