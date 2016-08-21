using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project.DA
{
    public class StaffDatabaseAccess
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



        public bool login(string id, string password)
        {
            SqlCommand myCommand = new SqlCommand("Select * from Login WHERE LoginId =  '" + id + "'", myConnection);
            SqlDataReader datareader = myCommand.ExecuteReader();
            if (datareader.HasRows)
            {
                datareader.Read();
                if (datareader["LoginPassword"].ToString().Equals(password))
                {
                    if ((bool)datareader["Roles"] == true)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void AddNewCustomer(string roomtype)
        {
            SqlCommand myCommand = new SqlCommand("Insert into roomtype values @type");
            myCommand.Parameters.Add("@type", SqlDbType.NChar);
            myCommand.Parameters["@type"].Value = roomtype;
            myCommand.ExecuteNonQuery();
        }
    }
}