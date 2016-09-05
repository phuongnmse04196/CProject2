using Project.DA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Staff
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || (bool)Session["role"] != false)
            {
                Response.Redirect("../Login.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtAddress.Text) || string.IsNullOrEmpty(txtCode.Text))
            {
                MessageBox.Show(this, "All text cannot null");
                return;
            }
            try
            {
                sda.AddCustomer(txtCode.Text, txtName.Text, txtAddress.Text);
                MessageBox.Show(this, "New Customer has been added");
            }
            catch
            {
                MessageBox.Show(this, "Customer already exist");
            }
        }
    }
}