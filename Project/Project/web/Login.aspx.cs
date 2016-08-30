using Project.BO;
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
            Session["username"] = null;
            Session["role"] = null;
        }
        DatabaseAccess da = new DatabaseAccess();
        protected void Button1_Click(object sender, EventArgs e)
        {
            da.openConnection();
            if (string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show(this, "All field must not be empty");
                return;
            }
            Account x = da.login(txtUser.Text, txtPass.Text);
            if (x != null)
            {
                Session["username"] = txtUser.Text;
                Session["role"] = x.role;
                if (x.role)
                {
                    Response.Redirect("Admin/AdminHome.aspx");
                }
                else
                {
                    Response.Redirect("Staff/Home.aspx");
                }
            }
            else
            {
                MessageBox.Show(this, "Failed");
            }
        }
    }
}