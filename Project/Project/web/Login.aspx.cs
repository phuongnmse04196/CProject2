using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        DatabaseAccess da = new DatabaseAccess();
        protected void Button1_Click(object sender, EventArgs e)
        {
            da.openConnection();
            bool x = da.login(txtUser.Text, txtPass.Text, true);
            if (x)
            {
                Session["username"] = txtUser.Text;
                Session["role"] = true;
            }
            else
            {
                MessageBox.Show(this, "Failed");
            }
        }
    }
}