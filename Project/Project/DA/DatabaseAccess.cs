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
    public class DatabaseAccess
    {
        SqlConnection myConnection;
        public void openConnection()
        {
            myConnection = new SqlConnection("user id=sa;" +
                                       "password=sa;server=localhost;" +
                                       "Trusted_Connection=yes;" +
                                       "database=HotelReservation; " +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        

        public bool login(string id, string password, bool authority)
        {
            SqlCommand myCommand = new SqlCommand("Select * from Login WHERE LoginId =  '" + id + "'", myConnection);
            SqlDataReader datareader = myCommand.ExecuteReader();
            if (datareader.HasRows)
            {
                datareader.Read();
                if (datareader["LoginPassword"].ToString().Equals(password))
                {
                    if ((bool)datareader["Roles"] == authority)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AddNewRoom(string roomtype)
        {       
            SqlCommand myCommand = new SqlCommand("Insert into roomtype values @type");
            myCommand.Parameters.Add("@type", SqlDbType.NChar);
            myCommand.Parameters["@type"].Value = roomtype;
            myCommand.ExecuteNonQuery();
            return false;
        }

        public bool AddNewHotel(string code, string name, string address)
        {

            SqlCommand myCommand = new SqlCommand("Insert into Hotel values (@code, @name, @address)");
            myCommand.Parameters.Add("@code", SqlDbType.NChar);
            myCommand.Parameters["@code"].Value = code;
            myCommand.Parameters.Add("@name", SqlDbType.NChar);
            myCommand.Parameters["@name"].Value = name;
            myCommand.Parameters.Add("@address", SqlDbType.NChar);
            myCommand.Parameters["@address"].Value = address;
            myCommand.ExecuteNonQuery();
            return false;
        }

        public bool AddNewLogin(Account a)
        {
            SqlCommand myCommand = new SqlCommand("Insert into Login values (@id, @password, @role)");
            myCommand.Parameters.Add("@id", SqlDbType.NChar);
            myCommand.Parameters["@id"].Value = a.username;
            myCommand.Parameters.Add("@password", SqlDbType.NChar);
            myCommand.Parameters["@password"].Value = a.password;
            myCommand.Parameters.Add("@role", SqlDbType.Bit);
            myCommand.Parameters["@role"].Value = a.role;
            myCommand.ExecuteNonQuery();
            return false;
        }

        public bool AddNewRoom(Room r)
        {
            SqlCommand myCommand = new SqlCommand("Insert into Room values (@roomno, @hotelcode, @typecode, @price)");
            myCommand.Parameters.Add("@roomno", SqlDbType.NChar);
            myCommand.Parameters["@roomno"].Value = r.roomno;
            myCommand.Parameters.Add("@hotelcode", SqlDbType.NChar);
            myCommand.Parameters["@hotelcode"].Value = r.hotelcode;
            myCommand.Parameters.Add("@typecode", SqlDbType.Bit);
            myCommand.Parameters["@typecode"].Value = r.typecode;
            myCommand.Parameters.Add("@price", SqlDbType.Money);
            myCommand.Parameters["@price"].Value = r.price;
            myCommand.ExecuteNonQuery();
            return false;
        }
    }
}