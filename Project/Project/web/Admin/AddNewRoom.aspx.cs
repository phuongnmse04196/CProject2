using Project.BO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project.web.Admin
{
    public partial class AddNewRoom1 : System.Web.UI.Page
    {
        AdminDatabaseAccess ada = new AdminDatabaseAccess();
        protected void Page_Load(object sender, EventArgs e)
        {
            ada.openConnection();
            if (!IsPostBack)
            {
                SqlDataReader hotel = ada.getHotel();
                while (hotel.Read())
                {
                    drHotel.Items.Add(new ListItem(hotel.GetString(1), hotel.GetString(2)));
                }
                SqlDataReader roomtype = ada.getRoomType();
                while (roomtype.Read())
                {
                    drRoomType.Items.Add(new ListItem((string)roomtype["TypeName"],((int)roomtype["TypeCode"]).ToString()));
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int a, b;
            if (string.IsNullOrEmpty(txtPrice.Text))
            {
                MessageBox.Show(this, "All field must not be empty");
                return;
            }
            Int32.TryParse(txtPrice.Text, out a);
            Int32.TryParse(drRoomType.SelectedValue, out b);
            Room r = new Room(txtRoom.Text, drHotel.SelectedValue, b, a);
            try
            {
                ada.AddNewRoom(r);
                MessageBox.Show(this, "Success");
            }
            catch
            {
                MessageBox.Show(this, "Failed");
            }

        }
    }
}