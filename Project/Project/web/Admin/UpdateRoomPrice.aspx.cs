using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Admin
{
    public partial class UpdateRoomPrice : System.Web.UI.Page
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
                drHotel.Items.Add(new ListItem("", null));
                while (hotel.Read())
                {
                    drHotel.Items.Add(new ListItem(hotel.GetString(1), hotel.GetString(0)));
                }
                hotel.Close();
                SqlDataReader roomtype = ada.getRoomType();
                drRoomType.Items.Add(new ListItem("", null));
                while (roomtype.Read())
                {
                    drRoomType.Items.Add(new ListItem((string)roomtype["TypeName"], ((int)roomtype["TypeCode"]).ToString()));
                }
                decimal a = ada.GetRoomPrice(drRoom.SelectedValue);
                txtOldPrice.Text = a.ToString();
                roomtype.Close();
            }
            else
            {
                ada.GetRoom1(null, -1);
            }
            ada.close();
        }

        protected void drHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a;
            Int32.TryParse(drRoomType.SelectedValue, out a);
            drRoom.DataTextField = "RoomNo";
            drRoom.DataValueField = "RoomNo";
            drRoom.DataSource = ada.GetRoom1(drHotel.SelectedValue, a);
            drRoom.DataBind();
            decimal b = ada.GetRoomPrice(drRoom.SelectedValue);
            if (b != -1)
            {
                txtOldPrice.Text = b.ToString();
            }
        }

        protected void drRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a;
            Int32.TryParse(drRoomType.SelectedValue, out a);
            if (drRoomType.SelectedValue == null)
            {
                a = -1;
            }
            drRoom.DataTextField = "RoomNo";
            drRoom.DataValueField = "RoomNo";
            drRoom.DataSource = ada.GetRoom1(drHotel.SelectedValue, a);
            drRoom.DataBind();
            decimal b = ada.GetRoomPrice(drRoom.SelectedValue);
            if (b != -1)
            {
                txtOldPrice.Text = b.ToString();
            }
        }

        protected void drRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal a = ada.GetRoomPrice(drRoom.SelectedValue);
            txtOldPrice.Text = a.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            double price;
            if (double.TryParse(txtNewPrice.Text, out price) == false || price <= 0)
            {
                MessageBox.Show(this, "Price must be a positive number");
                return;
            }
            try
            {
                ada.UpdatePrice(drRoom.SelectedValue, price);
                MessageBox.Show(this, "Update success!");
            }
            catch
            {
                MessageBox.Show(this, "Update failed!");
            }
        }
    }
}