using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriaParlamentar.Account
{
    public partial class Register : System.Web.UI.Page
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
                DropDownList dropDownListUF = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("dropDownListUF");
                dropDownListUF.Items.Add(new ListItem("Acre", "AC"));
                dropDownListUF.Items.Add(new ListItem("Alagoas", "AL"));
                dropDownListUF.Items.Add(new ListItem("Amapá", "AP"));
                dropDownListUF.Items.Add(new ListItem("Amazonas", "AM"));
                dropDownListUF.Items.Add(new ListItem("Bahia", "BA"));
                dropDownListUF.Items.Add(new ListItem("Ceará", "CE"));
                dropDownListUF.Items.Add(new ListItem("Distrito Federal", "DF"));
                dropDownListUF.Items.Add(new ListItem("Espírito Santo", "ES"));
                dropDownListUF.Items.Add(new ListItem("Goiás", "GO"));
                dropDownListUF.Items.Add(new ListItem("Maranhão", "MA"));
                dropDownListUF.Items.Add(new ListItem("Mato Grosso", "MT"));
                dropDownListUF.Items.Add(new ListItem("Mato Grosso do Sul", "MS"));
                dropDownListUF.Items.Add(new ListItem("Minas Gerais", "MG"));
                dropDownListUF.Items.Add(new ListItem("Pará", "PA"));
                dropDownListUF.Items.Add(new ListItem("Paraíba", "PB"));
                dropDownListUF.Items.Add(new ListItem("Paraná", "PR"));
                dropDownListUF.Items.Add(new ListItem("Pernambuco", "PE"));
                dropDownListUF.Items.Add(new ListItem("Piauí", "PI"));
                dropDownListUF.Items.Add(new ListItem("Rio de Janeiro", "RJ"));
                dropDownListUF.Items.Add(new ListItem("Rio Grande do Norte", "RN"));
                dropDownListUF.Items.Add(new ListItem("Rio Grande do Sul", "RS"));
                dropDownListUF.Items.Add(new ListItem("Rondônia", "RO"));
                dropDownListUF.Items.Add(new ListItem("Roraima", "RR"));
                dropDownListUF.Items.Add(new ListItem("Santa Catarina", "SC"));
                dropDownListUF.Items.Add(new ListItem("São Paulo", "SP"));
                dropDownListUF.Items.Add(new ListItem("Sergipe", "SE"));
                dropDownListUF.Items.Add(new ListItem("Tocantins", "TO"));
            }

            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            DropDownList dropDownListUF = (DropDownList)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("DropDownListUF");
            TextBox cidade = (TextBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("TextBoxCidade");
            CheckBox mostraEmail = (CheckBox)RegisterUser.CreateUserStep.ContentTemplateContainer.FindControl("CheckBoxMostraEmail");

            Usuario usuario = new Usuario();
            usuario.InsereDadosComplementares(RegisterUser.UserName, dropDownListUF.SelectedValue, cidade.Text, mostraEmail.Checked);
            
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);

            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }
    }
}
