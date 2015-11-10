using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.UI.HtmlControls;

namespace AuditoriaParlamentar
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    MenuItem menuMembros = new MenuItem();
                    menuMembros.Text = "Membros";
                    menuMembros.Value = "Membros";
                    menuMembros.NavigateUrl = "~/Membros.aspx";
                    NavigationMenu.Items.Add(menuMembros);
                    
                    MenuItem menuDenuncia = new MenuItem();
                    menuDenuncia.Text = "Denúncias";
                    menuDenuncia.Value = "Denúncias";
                    menuDenuncia.NavigateUrl = "~/Denuncias.aspx";
                    NavigationMenu.Items.Add(menuDenuncia);

                    if (Roles.IsUserInRole(System.Web.HttpContext.Current.User.Identity.Name, "REVISOR"))
                    {
                        MenuItem menuRevisao = new MenuItem();
                        menuRevisao.Text = "Revisão";
                        menuRevisao.Value = "Revisão";
                        menuRevisao.NavigateUrl = "~/Revisao.aspx";
                        NavigationMenu.Items.Add(menuRevisao);

                        //MenuItem menuAcompanha = new MenuItem();
                        //menuAcompanha.Text = "Relatórios";
                        //menuAcompanha.Value = "Relatórios";
                        //menuAcompanha.NavigateUrl = "~/Relatorio.aspx";
                        //NavigationMenu.Items.Add(menuAcompanha);
                    }

                }

                MenuItem menuNoticia = new MenuItem();
                menuNoticia.Text = "Notícias";
                menuNoticia.Value = "Notícias";
                menuNoticia.NavigateUrl = "~/Noticias.aspx";
                NavigationMenu.Items.Add(menuNoticia);

                MenuItem menuSobre = new MenuItem();
                menuSobre.Text = "Sobre";
                menuSobre.Value = "Sobre";
                menuSobre.NavigateUrl = "~/Sobre.aspx";
                NavigationMenu.Items.Add(menuSobre);

                
            }
        }
    }
}
