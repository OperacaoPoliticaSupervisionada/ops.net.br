using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using AuditoriaParlamentar.Classes;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace AuditoriaParlamentar
{
    public partial class EmailPendente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ThreadStart work = delegate
            {
                Email email = new Email();
                email.ReEnviaEmail();
            };
            new Thread(work).Start();
        }
    }
}