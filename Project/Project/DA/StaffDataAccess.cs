using Project.BO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.DA
{
    public class StaffDataAccess : DatabaseAccess
    {
        public void AddCustomer(string code, string name, string address)
        {
            string sql = " insert into Customer values(@code, @name, @address)";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            cmd.Parameters.AddWithValue("@code", code);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.ExecuteNonQuery();
        }

        public bool UpdateAccount(string account, string oldpassword, string newpassword)
        {
            string sql = " select loginpassword from login where loginid = @account";
            SqlCommand cmd = new SqlCommand(sql, myConnection);
            cmd.Parameters.AddWithValue("@account", account);
            string s = (string)cmd.ExecuteScalar();
            if (s.Equals(oldpassword))
            {
                sql = " update login set loginpassword = @npassword where loginid = @account";
                cmd = new SqlCommand(sql, myConnection);
                cmd.Parameters.AddWithValue("@account", account);
                cmd.Parameters.AddWithValue("@npassword", newpassword);
                cmd.ExecuteNonQuery();
                return true;
            }
            return false;
        }

        public DataTable getBooking(string name, string date)
        {
            string sql = "Select c.Name, b.BookingDate, bd.RoomNo, bd.CheckinDate, bd.CheckoutDate, bd.Price as 'Price per night' "
                        + " From Customer c, BookingDetail bd, Booking b "
                        + " where c.Code = b.CustomerCode and b.Code = bd.Code ";
            if (string.IsNullOrEmpty(name))
            {
                sql += " and DATEDIFF( DAY,b.BookingDate, @date) = 0 ";
            }
            else
            {
                sql += " and c.Name like @name ";
            }
            SqlDataAdapter sda = new SqlDataAdapter(sql, myConnection);

            if (string.IsNullOrEmpty(name))
            {
                sda.SelectCommand.Parameters.AddWithValue("@date", date);
            }
            else
            {
                string name2 = "%" + name.Trim() + "%";
                sda.SelectCommand.Parameters.AddWithValue("@name", name2);
            }
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }

        public string getCustomer(string code)
        {
            SqlCommand myCommand = new SqlCommand("Select Name from Customer where Code = @code", myConnection);
            myCommand.Parameters.Add("@code", SqlDbType.NChar);
            myCommand.Parameters["@code"].Value = code;
            return (string)myCommand.ExecuteScalar();
        }

        public DataTable getARoom(string hotel, string roomtype, string checkin, string checkout)
        {
            DataTable dt = new DataTable();
            string sql = "Select Roomno "
            + " from room r "
            + " where r.hotelcode = @hotel and r.typecode = @roomtype and r.busy = '0' "
            + " and r.RoomNo not in "
            + " (Select roomno from BookingDetail "
            + " where(CAST(CheckoutDate as DATE) >= @checkin "
            + " AND CAST(CheckinDate as DATE) <= @checkin) "
            + " OR(CAST(CheckinDate as DATE) <= @checkout "
            + " AND CAST(CheckoutDate as DATE) >= @checkout)) ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, myConnection);
            sda.SelectCommand.Parameters.AddWithValue("@hotel", hotel);
            sda.SelectCommand.Parameters.AddWithValue("@roomtype", roomtype);
            sda.SelectCommand.Parameters.AddWithValue("@checkin", checkin);
            sda.SelectCommand.Parameters.AddWithValue("@checkout", checkout);
            sda.Fill(dt);
            return dt;
        }

        public DataTable Validate(string roomno, DateTime checkin, DateTime checkout)
        {
            DataTable dt = new DataTable();
            string sql = "Select Roomno "
            + " from room r "
            + " where r.roomno = @roomno and r.busy = '0' "
            + " and r.RoomNo not in "
            + " (Select roomno from BookingDetail "
            + " where(CAST(CheckoutDate as DATE) >= @checkin "
            + " AND CAST(CheckinDate as DATE) <= @checkin) "
            + " OR(CAST(CheckinDate as DATE) <= @checkout "
            + " AND CAST(CheckoutDate as DATE) >= @checkout)) ";
            SqlDataAdapter sda = new SqlDataAdapter(sql, myConnection);
            sda.SelectCommand.Parameters.AddWithValue("@roomno", roomno);
            sda.SelectCommand.Parameters.AddWithValue("@checkin", checkin);
            sda.SelectCommand.Parameters.AddWithValue("@checkout", checkout);
            sda.Fill(dt);
            return dt;
        }

        public void book(string roomno, string customercode, DateTime checkin, DateTime checkout)
        {
            DateTime date = DateTime.Now;
            string date2 = date.Year.ToString() + date.Month.ToString() + date.Day.ToString();
            string sql = "Insert into Booking values (@customercode, @date); select Scope_Identity();";
            SqlCommand command = new SqlCommand(sql, myConnection);
            command.Parameters.AddWithValue("@customercode", customercode);
            command.Parameters.AddWithValue("@date", date);
            decimal id = (decimal)command.ExecuteScalar();
            command = new SqlCommand("select Price from room where roomno = @roomno", myConnection);
            command.Parameters.AddWithValue("@roomno", roomno);
            decimal price = (decimal)command.ExecuteScalar();
            command = new SqlCommand("Insert into BookingDetail values (@code, @roomno, @checkin, @checkout, @price)", myConnection);
            command.Parameters.AddWithValue("@code", id);
            command.Parameters.AddWithValue("@roomno", roomno);
            command.Parameters.AddWithValue("@checkin", checkin);
            command.Parameters.AddWithValue("@checkout", checkout);
            command.Parameters.AddWithValue("@price", price);
            command.ExecuteNonQuery();
        }
        public void Checkout(string roomno)
        {
            SqlCommand command;
            command = new SqlCommand("Update Room set busy = '0' where roomno = @roomno", myConnection);
            command.Parameters.AddWithValue("@roomno", roomno);
            command.ExecuteNonQuery();
            command = new SqlCommand("Select code from BookingDetail where roomno = @roomno", myConnection);
            command.Parameters.AddWithValue("@roomno", roomno);
            int a = (int)command.ExecuteScalar();
            command = new SqlCommand("Delete from BookingDetail where roomno = @roomno", myConnection);
            command.Parameters.AddWithValue("@roomno", roomno);
            command.ExecuteNonQuery();
            command = new SqlCommand("Delete from Booking where code = @code", myConnection);
            command.Parameters.AddWithValue("@code", a);
            command.ExecuteNonQuery();
        }
    }
}