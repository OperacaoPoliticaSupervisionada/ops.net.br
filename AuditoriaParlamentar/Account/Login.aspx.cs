using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace AuditoriaParlamentar.Account
{
    public partial class Login : System.Web.UI.Page
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
            RegisterHyperLink.NavigateUrl = "Register.aspx?ReturnUrl=" + HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);

            if (Session["MasterPage"] == "Farejador")
            {
                LoginUser.DestinationPageUrl = "~/PesquisaFarejador.aspx";
            }
            else
            {
                LoginUser.DestinationPageUrl = "~/PesquisaInicio.aspx";
            }
        }

        protected void LoginUser_LoginError(object sender, EventArgs e)
        {

        }

        protected void LoginUser_LoggedIn(object sender, EventArgs e)
        {
            //if (LoginUser.RememberMeSet)
            //{
            //    // Clear any other tickets that are already in the response
            //    Response.Cookies.Clear();

            //    // Set the new expiry date - to thirty days from now
            //    DateTime expiryDate = DateTime.Now.AddDays(30);

            //    // Create a new forms auth ticket
            //    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(2, LoginUser.UserName, DateTime.Now, expiryDate, true, String.Empty);

            //    // Encrypt the ticket
            //    string encryptedTicket = FormsAuthentication.Encrypt(ticket);

            //    // Create a new authentication cookie - and set its expiration date
            //    HttpCookie authenticationCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            //    authenticationCookie.Expires = ticket.Expiration;

            //    // Add the cookie to the response.
            //    Response.Cookies.Add(authenticationCookie);
            //}
        }
    }
}
