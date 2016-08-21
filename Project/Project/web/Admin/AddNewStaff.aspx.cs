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

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show(this, "All field must not be empty");
                return;
            }
            Account a = new Account(txtUsername.Text, txtPassword.Text, rbAdmin.Checked);
            try
            {
                AdminDatabaseAccess ada = new AdminDatabaseAccess();
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