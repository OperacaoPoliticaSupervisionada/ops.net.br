using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AuditoriaParlamentar.Classes
{
    public static class Extenssion
    {
        public static string SelectedItems(this ListControl lc)
        {
            List<string> selectedItems =
                        lc.Items.Cast<ListItem>()
                        .Where(item => item.Selected == true)
                        .Select(item => item.Text)
                        .ToList();

            return string.Join(",", selectedItems);
        }
    }
}