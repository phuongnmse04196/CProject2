using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Admin
{
    public partial class AddNewHotel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || (bool) Session["role"] != true)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        AdminDatabaseAccess ada = new AdminDatabaseAccess();
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show(this, "All field must not be empty");
                return;
            }
            try
            {
                ada.openConnection();
                ada.AddNewHotel(txtCode.Text, txtName.Text, txtAddress.Text);
                MessageBox.Show(this, "Success");
                ada.close();
            }
            catch
            {
                MessageBox.Show(this, "This hotel code already exist");
                ada.close();
            }

        }
    }
}