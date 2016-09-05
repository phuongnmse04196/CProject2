using Project.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Staff
{
    public partial class Print : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || (bool)Session["role"] != false)
            {
                Response.Redirect("../Login.aspx");
            }
            if (IsPostBack)
            {
                StaffDataAccess sda = new StaffDataAccess();
                sda.openConnection();
                GridView1.DataSource = sda.getBooking(txtName.Text, txtDate.Text);
                GridView1.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            GridView1.DataSource = sda.getBooking(txtName.Text, txtDate.Text);
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtChekOut.Text))
            {
                MessageBox.Show(this, "You must input roomno!");
                return;
            }
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            try
            {
                sda.Checkout(txtChekOut.Text);
                MessageBox.Show(this, "Success!");
                GridView1.DataSource = sda.getBooking(txtName.Text, txtDate.Text);
                GridView1.DataBind();
            } catch
            {
                MessageBox.Show(this, "Failed!");
            }
        }
    }
}