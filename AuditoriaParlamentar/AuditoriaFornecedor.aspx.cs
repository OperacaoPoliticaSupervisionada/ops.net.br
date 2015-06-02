using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class AuditoriaFornecedor : System.Web.UI.Page
    {
        public Int64 Id { get; set; }
        public String UserName {get; set;}
        public String Cnpj { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == false)
                Response.Redirect("~/Account/Login.aspx");

            String forcarConsulta;

            UserName = HttpContext.Current.User.Identity.Name;
            Cnpj = Request.QueryString["codigo"];
            forcarConsulta = Request.QueryString["forcarConsulta"];

            if (Cnpj == null || Cnpj == "")
            {
                Response.Redirect("~/PesquisaInicio.aspx");
            }
            else
            {
                Fornecedor fornecedor = new Fornecedor();

                if (forcarConsulta != null)
                {
                    Id = fornecedor.PreparaAtualizacao(UserName);
                }
                else if (fornecedor.EstaAtualizado(Cnpj))
                {
                    Response.Redirect("~/AtualizaFornecedor.aspx?a=" + Cnpj);
                }
                else
                {
                    Id = fornecedor.PreparaAtualizacao(UserName);
                }
            }
        }
    }
}