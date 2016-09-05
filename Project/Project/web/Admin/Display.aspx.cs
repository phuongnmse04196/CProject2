using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Admin
{
    public partial class Display : System.Web.UI.Page
    {
        AdminDatabaseAccess ada = new AdminDatabaseAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || (bool)Session["role"] != true)
            {
                Response.Redirect("../Login.aspx");
            }
            ada.openConnection();
            if (!IsPostBack)
            {
                SqlDataReader hotel = ada.getHotel();
                while (hotel.Read())
                {
                    drHotel.Items.Add(new ListItem(hotel.GetString(1), hotel.GetString(0)));
                }
                hotel.Close();
                SqlDataReader roomtype = ada.getRoomType();
                while (roomtype.Read())
                {
                    drRoomType.Items.Add(new ListItem((string)roomtype["TypeName"], ((int)roomtype["TypeCode"]).ToString()));
                }
                roomtype.Close();
            } else
            {
                if (string.IsNullOrEmpty(txtCheckIn.Text) || string.IsNullOrEmpty(txtCheckOut.Text))
                {
                    MessageBox.Show(this, "All field must not be empty");
                    return;
                }
                DataTable dt;
                AdminDatabaseAccess ada1 = new AdminDatabaseAccess();
                ada1.openConnection();
                int a;
                Int32.TryParse(drRoomType.SelectedValue, out a);
                dt = ada.Print(drHotel.SelectedValue, a, txtCheckIn.Text, txtCheckOut.Text);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCheckIn.Text) || string.IsNullOrEmpty(txtCheckOut.Text))
            {
                MessageBox.Show(this, "All field must not be empty");
                return;
            }
            DataTable dt;
            AdminDatabaseAccess ada = new AdminDatabaseAccess();
            ada.openConnection();
            int a;
            a = Convert.ToInt32(drRoomType.SelectedValue);
            dt = ada.Print(drHotel.SelectedValue, a, txtCheckIn.Text, txtCheckOut.Text);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}