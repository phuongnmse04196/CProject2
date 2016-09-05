using Project.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Admin
{
    public partial class AddNewStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || (bool)Session["role"] != true)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(this, "All field must not be empty");
                return;
            }
            Account a = new Account(txtUsername.Text, txtPassword.Text, rbAdmin.Checked);
            AdminDatabaseAccess ada = new AdminDatabaseAccess();
            try
            {
                ada.openConnection();
                ada.AddNewLogin(a);
                MessageBox.Show(this, "Success");
            } catch
            {
                MessageBox.Show(this, "This account already exist");
            }
        }
    }
}