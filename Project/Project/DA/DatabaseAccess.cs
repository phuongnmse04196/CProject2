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
        protected SqlConnection myConnection;
        public void openConnection()
        {
            myConnection = new SqlConnection("user id=sa;" +
                                       "password=123456;server=localhost;" +
                                       "Trusted_Connection=yes;" +
                                       "database=HotelReservation; " +
                                       "connection timeout=30; MultipleActiveResultSets=true");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        

        public Account login(string id, string password)
        {
            SqlCommand myCommand = new SqlCommand("Select * from Login WHERE LoginId =  '" + id + "'", myConnection);
            SqlDataReader datareader = myCommand.ExecuteReader();
            if (datareader.HasRows)
            {
                datareader.Read();
                if (datareader["LoginPassword"].ToString().Equals(password))
                {
                    return new Account(datareader.GetString(0), datareader.GetString(1), datareader.GetBoolean(2));
                }
            }
            return null;
        }

        public SqlDataReader getHotel()
        {
            SqlCommand myCommand = new SqlCommand("Select * from Hotel", myConnection);
            SqlDataReader datareader = myCommand.ExecuteReader();
            return datareader;
        }

        public SqlDataReader getRoomType()
        {
            SqlCommand myCommand = new SqlCommand("Select * from RoomType", myConnection);
            SqlDataReader datareader = myCommand.ExecuteReader();
            return datareader;
        }

        public decimal GetRoomPrice(string Roomno)
        {
            if (string.IsNullOrEmpty(Roomno))
            {
                return -1;
            }
            SqlCommand myCommand = new SqlCommand("Select Price from Room where roomno = @roomno", myConnection);
            myCommand.Parameters.Add("@roomno", SqlDbType.NChar);
            myCommand.Parameters["@roomno"].Value = Roomno;
            decimal a = (decimal)myCommand.ExecuteScalar();
            return a;
        }
    }
}