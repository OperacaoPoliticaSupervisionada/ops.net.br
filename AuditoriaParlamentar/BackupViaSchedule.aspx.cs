using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuditoriaParlamentar.Classes;

namespace AuditoriaParlamentar
{
    public partial class BackupViaSchedule : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpUtility.HtmlDecode(Request.QueryString["id"]) == "AKFPROFMAHFHR")
            {
                Backup backup = new Backup();
                backup.FazerBackup(Server.MapPath("Backup"));
            }
        }
    }
}