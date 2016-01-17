using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriaParlamentar.Account
{
    public partial class UpdateAccount : System.Web.UI.Page
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
                DropDownListUF.Items.Add(new ListItem("Acre", "AC"));
                DropDownListUF.Items.Add(new ListItem("Alagoas", "AL"));
                DropDownListUF.Items.Add(new ListItem("Amapá", "AP"));
                DropDownListUF.Items.Add(new ListItem("Amazonas", "AM"));
                DropDownListUF.Items.Add(new ListItem("Bahia", "BA"));
                DropDownListUF.Items.Add(new ListItem("Ceará", "CE"));
                DropDownListUF.Items.Add(new ListItem("Distrito Federal", "DF"));
                DropDownListUF.Items.Add(new ListItem("Espírito Santo", "ES"));
                DropDownListUF.Items.Add(new ListItem("Goiás", "GO"));
                DropDownListUF.Items.Add(new ListItem("Maranhão", "MA"));
                DropDownListUF.Items.Add(new ListItem("Minas Gerais", "MG"));
                DropDownListUF.Items.Add(new ListItem("Mato Grosso", "MT"));
                DropDownListUF.Items.Add(new ListItem("Mato Grosso do Sul", "MS"));
                DropDownListUF.Items.Add(new ListItem("Pará", "PA"));
                DropDownListUF.Items.Add(new ListItem("Paraíba", "PB"));
                DropDownListUF.Items.Add(new ListItem("Paraná", "PR"));
                DropDownListUF.Items.Add(new ListItem("Pernambuco", "PE"));
                DropDownListUF.Items.Add(new ListItem("Piauí", "PI"));
                DropDownListUF.Items.Add(new ListItem("Rio de Janeiro", "RJ"));
                DropDownListUF.Items.Add(new ListItem("Rio Grande do Norte", "RN"));
                DropDownListUF.Items.Add(new ListItem("Rondônia", "RO"));
                DropDownListUF.Items.Add(new ListItem("Roraima", "RR"));
                DropDownListUF.Items.Add(new ListItem("Rio Grande do Sul", "RS"));
                DropDownListUF.Items.Add(new ListItem("Santa Catarina", "SC"));
                DropDownListUF.Items.Add(new ListItem("Sergipe", "SE"));
                DropDownListUF.Items.Add(new ListItem("São Paulo", "SP"));
                DropDownListUF.Items.Add(new ListItem("Tocantins", "TO"));

                String userName = HttpContext.Current.User.Identity.Name;
                
                if (userName != "" && userName != null)
                {
                    Usuario usuario = new Usuario();
                    usuario.CarregaDadosComplementares(userName);
                    DropDownListUF.SelectedValue = usuario.UserUF;
                    TextBoxCidade.Text = usuario.UserCidade;
                    CheckBoxMostraEmail.Checked = Convert.ToBoolean(usuario.MostraEmail);
                }
            }
        }

        protected void UpdateUserButton_Click(object sender, EventArgs e)
        {
            String userName = HttpContext.Current.User.Identity.Name;

            Usuario usuario = new Usuario();

            if (usuario.AtualizaDadosComplementares(userName, DropDownListUF.SelectedValue, TextBoxCidade.Text, CheckBoxMostraEmail.Checked) == true)
                Response.Redirect("~/Account/UpdateAccountSuccess.aspx");
        }
    }
}
