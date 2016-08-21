using Project.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Staff
{
    public partial class UpdateStaff : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtUser.Enabled = false;
            txtUser.Text = Session["username"].ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            if (!(string.IsNullOrEmpty(txtNewPass.Text) || string.IsNullOrEmpty(txtOldPass.Text) || string.IsNullOrEmpty(txtUser.Text)))
            {
                if(sda.UpdateAccount(txtUser.Text, txtOldPass.Text, txtNewPass.Text))
                {
                    MessageBox.Show(this, "Success");
                } else
                {
                    MessageBox.Show(this, "Wrong Password");
                }
                
            } else
            {
                MessageBox.Show(this, "All field must not be empty");
            }
        }
    }
}