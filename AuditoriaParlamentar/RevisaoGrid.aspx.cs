using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class RevisaoGrid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated || !System.Web.HttpContext.Current.User.IsInRole("REVISOR"))
                Response.Redirect("~/Default.aspx");

            GridViewRevisao.PreRender += GridViewRevisao_PreRender;
            
            if (!IsPostBack)
            {
                if (Session["CheckBoxNaoLidas"] != null)
                    CheckBoxNaoLidas.Checked = Convert.ToBoolean(Session["CheckBoxNaoLidas"]);

                if (Session["CheckBoxAguardando"] != null)
                    CheckBoxAguardando.Checked = Convert.ToBoolean(Session["CheckBoxAguardando"]);

                if (Session["CheckBoxDossie"] != null)
                    CheckBoxDossie.Checked = Convert.ToBoolean(Session["CheckBoxDossie"]);

                if (Session["CheckBoxDuvidoso"] != null)
                    CheckBoxDuvidoso.Checked = Convert.ToBoolean(Session["CheckBoxDuvidoso"]);

                if (Session["CheckBoxNaoProcede"] != null)
                    CheckBoxNaoProcede.Checked = Convert.ToBoolean(Session["CheckBoxNaoProcede"]);

                if (Session["CheckBoxPendenteInformacao"] != null)
                    CheckBoxPendenteInformacao.Checked = Convert.ToBoolean(Session["CheckBoxPendenteInformacao"]);

                if (Session["CheckBoxRepetido"] != null)
                    CheckBoxRepetido.Checked = Convert.ToBoolean(Session["CheckBoxRepetido"]);

                CarregaDados();
            }
        }

        private void GridViewRevisao_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridViewRevisao.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch (Exception ex)
            {
            }
        }

        protected void CarregaDados()
        {
            Denuncia denuncia = new Denuncia();
            denuncia.DenunciasRevisao(GridViewRevisao, CheckBoxAguardando.Checked, CheckBoxDuvidoso.Checked, CheckBoxDossie.Checked, CheckBoxNaoProcede.Checked, CheckBoxPendenteInformacao.Checked, CheckBoxNaoLidas.Checked, CheckBoxRepetido.Checked);
        }

        protected void GridViewDenuncias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Width = 25;
                e.Row.Cells[2].Width = 60;
                e.Row.Cells[3].Width = 130;
                e.Row.Cells[4].Width = 300;
                e.Row.Cells[5].Width = 160;
            }

            if (e.Row.RowType != DataControlRowType.EmptyDataRow)
            {
                e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
            }
        }

        protected void GridViewDenuncias_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                Int32 index = Convert.ToInt32(e.CommandArgument);

                Response.Redirect(String.Format("~/DenunciaMsg.aspx?Retorno=RevisaoGrid&IdDenuncia={0}", GridViewRevisao.Rows[index].Cells[2].Text));
            }
        }

        protected void ButtonEnviar_Click(object sender, EventArgs e)
        {
            Session["CheckBoxNaoLidas"] = CheckBoxNaoLidas.Checked.ToString();
            Session["CheckBoxAguardando"] = CheckBoxAguardando.Checked.ToString();
            Session["CheckBoxDuvidoso"] = CheckBoxDuvidoso.Checked.ToString();
            Session["CheckBoxDossie"] = CheckBoxDossie.Checked.ToString();
            Session["CheckBoxNaoProcede"] = CheckBoxNaoProcede.Checked.ToString();
            Session["CheckBoxPendenteInformacao"] = CheckBoxPendenteInformacao.Checked.ToString();
            Session["CheckBoxRepetido"] = CheckBoxRepetido.Checked.ToString();

            CarregaDados();
        }
    }
}