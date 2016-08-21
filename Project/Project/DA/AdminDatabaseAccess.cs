using Project.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace Project
{
    public class AdminDatabaseAccess : DatabaseAccess
    {


        public void AddNewRoomType(string roomtype)
        {
            SqlCommand myCommand = new SqlCommand("Insert into roomtype values (@type)", myConnection);
            myCommand.Parameters.Add("@type", SqlDbType.NChar);
            myCommand.Parameters["@type"].Value = roomtype;
            myCommand.ExecuteNonQuery();
        }

        public void AddNewHotel(string code, string name, string address)
        {
            SqlCommand myCommand = new SqlCommand("Insert into Hotel values (@code, @name, @address)", myConnection);
            myCommand.Parameters.Add("@code", SqlDbType.NChar);
            myCommand.Parameters["@code"].Value = code;
            myCommand.Parameters.Add("@name", SqlDbType.NChar);
            myCommand.Parameters["@name"].Value = name;
            myCommand.Parameters.Add("@address", SqlDbType.NChar);
            myCommand.Parameters["@address"].Value = address;
            myCommand.ExecuteNonQuery();
        }

        public void AddNewLogin(Account a)
        {
            SqlCommand myCommand = new SqlCommand("Insert into Login values (@id, @password, @role)", myConnection);
            myCommand.Parameters.Add("@id", SqlDbType.NChar);
            myCommand.Parameters["@id"].Value = a.username;
            myCommand.Parameters.Add("@password", SqlDbType.NChar);
            myCommand.Parameters["@password"].Value = a.password;
            myCommand.Parameters.Add("@role", SqlDbType.Bit);
            myCommand.Parameters["@role"].Value = a.role;
            myCommand.ExecuteNonQuery();
        }

        public void AddNewRoom(Room r)
        {
            SqlCommand myCommand = new SqlCommand("Insert into Room values (@roomno, @hotelcode, @typecode, @price, @busy)", myConnection);
            myCommand.Parameters.Add("@roomno", SqlDbType.NChar);
            myCommand.Parameters["@roomno"].Value = r.roomno;
            myCommand.Parameters.Add("@hotelcode", SqlDbType.NChar);
            myCommand.Parameters["@hotelcode"].Value = r.hotelcode;
            myCommand.Parameters.Add("@typecode", SqlDbType.Int);
            myCommand.Parameters["@typecode"].Value = r.typecode;
            myCommand.Parameters.Add("@price", SqlDbType.Money);
            myCommand.Parameters["@price"].Value = r.price;
            myCommand.Parameters.Add("@busy", SqlDbType.Bit);
            myCommand.Parameters["@busy"].Value = false;
            myCommand.ExecuteNonQuery();
        }

        public DataTable GetRoom1(string HotelID, int RoomID)
        {
            SqlDataAdapter sda;
            DataTable dt = new DataTable();
            if (HotelID == null && RoomID == -1)
            {
                sda = new SqlDataAdapter("Select * from Room", myConnection);
            }
            else
            {
                if (HotelID == null)
                {
                    sda = new SqlDataAdapter("Select * from Room where hotelcode = @hotelcode", myConnection);
                    sda.SelectCommand.Parameters.Add("@hotelcode", SqlDbType.NChar);
                    sda.SelectCommand.Parameters["@hotelcode"].Value = HotelID;
                }
                else if (RoomID == -1)
                {
                    sda = new SqlDataAdapter("Select * from Room where typecode = @typecode", myConnection);
                    sda.SelectCommand.Parameters.Add("@typecode", SqlDbType.Int);
                    sda.SelectCommand.Parameters["@typecode"].Value = RoomID;
                }
                else
                {
                    sda = new SqlDataAdapter("Select * from Room where hotelcode = @hotelcode", myConnection);
                    sda.SelectCommand.Parameters.Add("@hotelcode", SqlDbType.NChar);
                    sda.SelectCommand.Parameters["@hotelcode"].Value = HotelID;
                    sda.SelectCommand.Parameters.Add("@typecode", SqlDbType.Int);
                    sda.SelectCommand.Parameters["@typecode"].Value = RoomID;
                }
            }
            DataSet ds = new DataSet();
            sda.Fill(dt);
            return dt;
        }

        

        public SqlDataReader GetBooking(string HotelID, string RoomID, DateTime checkin, DateTime checkout)
        {
            if (HotelID == null)
            {
                SqlCommand myCommand = new SqlCommand("Select * from Room where hotelid = @hotelid", myConnection);
                myCommand.Parameters.Add("@hotelid", SqlDbType.NChar);
                myCommand.Parameters["@hotelid"].Value = HotelID;
                return myCommand.ExecuteReader();
            }
            else if (RoomID == null)
            {
                SqlCommand myCommand = new SqlCommand("Select * from Room where typecode = @typecode", myConnection);
                myCommand.Parameters.Add("@typecode", SqlDbType.NChar);
                myCommand.Parameters["@typecode"].Value = RoomID;
                return myCommand.ExecuteReader();
            }
            else
            {
                SqlCommand myCommand = new SqlCommand("Select * from Room where hotelID = @hotelid and typecode = @typecode", myConnection);
                myCommand.Parameters.Add("@hotelid", SqlDbType.NChar);
                myCommand.Parameters["@hotelid"].Value = HotelID;
                myCommand.Parameters.Add("@typecode", SqlDbType.NChar);
                myCommand.Parameters["@typecode"].Value = RoomID;
                return myCommand.ExecuteReader();
            }
        }

        public void UpdatePrice(string roomno, double price)
        {
            SqlCommand myCommand = new SqlCommand("Update Room set price = @price where roomno = @roomno", myConnection);
            myCommand.Parameters.Add("@roomno", SqlDbType.NChar);
            myCommand.Parameters["@roomno"].Value = roomno;
            myCommand.Parameters.Add("@price", SqlDbType.Money);
            myCommand.Parameters["@price"].Value = price;
            myCommand.ExecuteNonQuery();
        }

        public DataTable Print(string hcode, int roomtype, string checkin, string checkout)
        {
            string sql = "select r.RoomNo, bd.CheckinDate, bd.CheckoutDate, DATEDIFF(DAY, bd.CheckinDate, bd.CheckoutDate) + 1 as 'Number of Night(s)', bd.Price as 'Price per night', (DATEDIFF(DAY, bd.CheckinDate, bd.CheckoutDate)+1) * bd.Price as 'Total amount', bd.Code, b.BookingDate "
                        + " from BookingDetail bd, Room r, Booking b "
                        + " where r.RoomNo = bd.RoomNo and b.Code = bd.Code "
                        + " and r.TypeCode = @roomType and r.HotelCode = @hCode "
                        + " and bd.CheckinDate >= @checin and bd.CheckoutDate <= @checkout";
            SqlDataAdapter sda = new SqlDataAdapter(sql, myConnection);
            sda.SelectCommand.Parameters.AddWithValue("@roomType", roomtype);
            sda.SelectCommand.Parameters.AddWithValue("@hCode", hcode);
            sda.SelectCommand.Parameters.AddWithValue("@checin", checkin);
            sda.SelectCommand.Parameters.AddWithValue("@checkout", checkout);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}