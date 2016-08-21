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

        public string getCustomer (string code)
        {
            SqlCommand myCommand = new SqlCommand("Select Name from Customer where Code = @code", myConnection);
            myCommand.Parameters.Add("@code", SqlDbType.NChar);
            myCommand.Parameters["@code"].Value = code;
            return (string)myCommand.ExecuteScalar();
        }

        public DataTable getARoom (string hotel, string roomtype, string checkin, string checkout)
        {
            DataTable dt = new DataTable();
            string sql = "Select Roomno from room r where r.hotelcode = @hotel and r.typecode = @roomtype and r.busy = '0'";
            SqlDataAdapter sda = new SqlDataAdapter(sql, myConnection);
            sda.SelectCommand.Parameters.AddWithValue("@hotel", hotel);
            sda.SelectCommand.Parameters.AddWithValue("@roomtype", roomtype);
            sda.Fill(dt);
            return dt;
        }

        public void book (string roomno, string customercode, DateTime checkin, DateTime checkout)
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
            command = new SqlCommand("Update Room set busy = '1' where roomno = @roomno", myConnection);
            command.Parameters.AddWithValue("@roomno", roomno);
            command.ExecuteNonQuery();
        }
        
    }
}