using Project.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project
{
    public partial class StaffHome : System.Web.UI.Page
    {
        DataTable dt1;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"] == null || (bool)Session["role"] != false)
            {
                Response.Redirect("../Login.aspx");
            }
            Page.DataBind();
            GridView2.AutoGenerateColumns = true;
            txtName.Enabled = false;
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            if (!IsPostBack)
            {
                dt1 = new DataTable();
                dt1.Columns.Add(new DataColumn("RoomNo"));
                dt1.Columns.Add(new DataColumn("Price"));
                dt1.Columns.Add(new DataColumn("CheckIn"));
                dt1.Columns.Add(new DataColumn("CheckOut"));
                dt1.Columns.Add(new DataColumn("NumberofNights"));
                dt1.Columns.Add(new DataColumn("TotalPrice"));
                GridView2.DataSource = dt1;
                GridView2.DataBind();
                ViewState["dt"] = dt1;
                SqlDataReader hotel = sda.getHotel();
                while (hotel.Read())
                {
                    drHotel.Items.Add(new ListItem(hotel.GetString(1), hotel.GetString(0)));
                }
                hotel.Close();
                SqlDataReader roomtype = sda.getRoomType();
                while (roomtype.Read())
                {
                    drRoomType.Items.Add(new ListItem((string)roomtype["TypeName"], ((int)roomtype["TypeCode"]).ToString()));
                }
                roomtype.Close();
            } else
            {
                dt1 = (DataTable)ViewState["dt"];
                GridView2.DataSource = dt1;
                GridView2.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            if(!string.IsNullOrEmpty(txtCode.Text))
            {
                txtName.Text = sda.getCustomer(txtCode.Text);
            }
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCustomer.aspx");
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            ListBox1.DataTextField = "RoomNo";
            ListBox1.DataValueField = "RoomNo";
            ListBox1.DataSource = sda.getARoom(drHotel.SelectedValue, drRoomType.SelectedValue, txtCheckIn.Text, txtCheckOut.Text);
            ListBox1.DataBind();
        }

        protected void btnBook_Click(object sender, EventArgs e)
        {
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            if (string.IsNullOrEmpty(ListBox1.Text.Trim()))
            {
                MessageBox.Show(this, "Please select room to book");
                return;
            }

            DateTime checkin = new DateTime();
            try
            {
                checkin = DateTime.Parse(txtCheckIn.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Please input the check in date!");
                txtCheckIn.Focus();
                return;

            }
            DateTime checkout = new DateTime();
            try
            {
                checkout = DateTime.Parse(txtCheckOut.Text);
            }
            catch (Exception)
            {
                MessageBox.Show(this, "Please input the check out date!");
                txtCheckOut.Focus();
                return;
            }
            //if (dt1.Rows.Count != 0)
            //{
            //    MessageBox.Show(this, "Please save before making furthur booking");
            //    return;
            //}
            if (checkin < DateTime.Today)
            {
                MessageBox.Show(this, "Invalid Check in date");
                dt1.Clear();
                return;
            }
            if (checkout < DateTime.Today)
            {
                MessageBox.Show(this, "Invalid Check out date");
                dt1.Clear();
                return;
            }
            DataTable dt2 = sda.Validate(ListBox1.Text.Trim(), checkin, checkout);
            if (dt2.Rows.Count == 0)
            {
                MessageBox.Show(this, "This room is occupied");
                return;
            }
            TimeSpan night;
            night = checkout - checkin;

            double night2 = night.TotalDays;
            decimal x = sda.GetRoomPrice(ListBox1.Text);
            double x1 = System.Convert.ToDouble(x);
            bool flag = false;
            foreach (DataRow rows in dt1.Rows)
            {
                if (rows[0].Equals(ListBox1.Text))
                {
                    rows[1] = x;
                    rows[2] = checkin.Day + "/" + checkin.Month + "/" + checkin.Year;
                    rows[3] = checkout.Day + "/" + checkout.Month + "/" + checkout.Year;
                    rows[4] = night2;
                    rows[5] = night2 * x1;
                    flag = true;
                    break;
                }
            }
            if (!flag)
            {
                DataRow newRows = dt1.NewRow();
                newRows[0] = ListBox1.Text;
                newRows[1] = x;
                newRows[2] = checkin.Day + "/" + checkin.Month + "/" + checkin.Year;
                newRows[3] = checkout.Day + "/" + checkout.Month + "/" + checkout.Year;
                newRows[4] = night2;
                newRows[5] = night2 * x1;
                dt1.Rows.Add(newRows);
            }
            ViewState["dt"] = dt1;
            GridView2.DataSource = dt1;
            GridView2.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            StaffDataAccess sda = new StaffDataAccess();
            sda.openConnection();
            foreach (DataRow rows in dt1.Rows)
            {
                //DateTime checkin = DateTime.ParseExact(rows[2].ToString(), "dd/M/yyyy",
                //                       null);
                //DateTime checkout = DateTime.ParseExact(rows[3].ToString(), "dd/M/yyyy",
                //                           null);
                DateTime checkin = DateTime.Parse(rows[2].ToString());
                DateTime checkout = DateTime.Parse(rows[3].ToString());

                DataTable dt2 = sda.Validate(rows[0].ToString(), checkin, checkout);
                if (dt2.Rows.Count == 0)
                {
                    MessageBox.Show(this, "This room is occupied");
                    return;
                }
                sda.book(rows[0].ToString(), txtCode.Text, checkin, checkout);
            }
            Response.Redirect("Print.aspx");
        }
    }
}