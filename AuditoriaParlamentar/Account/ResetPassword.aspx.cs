using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriaParlamentar.Account
{
    public partial class ResetPassword : System.Web.UI.Page
    {
        protected override void OnPreInit(EventArgs e)
        {
            if (Session["MasterPage"] == "Farejador")
            {
                Page.MasterPageFile = "~/OpsFarejador.Master";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String chave = Request.QueryString["chave"];

                if (chave != null)
                {
                    MySqlMembershipProvider member = new MySqlMembershipProvider();
                    LabelSenha.Text = member.RecuperaSenha(chave);
                }
            }
        }
    }
}