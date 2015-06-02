using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriaParlamentar
{
    public partial class CertificadoJava : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            // You should put more appropriate MIME type as per your file time - perhaps based on extension
            Response.ContentType = "application/octate-stream";
            Response.AddHeader("content-disposition", "attachment;filename=ops.crt");
            // Start pushing file to user, IIS will do the streaming.
            Response.TransmitFile("~/ops.crt");
        }
    }
}