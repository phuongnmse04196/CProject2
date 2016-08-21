using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.BO
{
    public class Booking
    {
        string roomno { get; set; }
        decimal price { get; set; }
        DateTime checkin { get; set; }
        DateTime checkout { get; set; }

        public Booking(string roomno, decimal price, DateTime checkin, DateTime checkout)
        {
            this.roomno = roomno;
            this.price = price;
            this.checkin = checkin;
        }
    }
}