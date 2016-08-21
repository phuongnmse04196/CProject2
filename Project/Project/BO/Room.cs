using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.BO
{
    public class Room
    {
        public string roomno { get; set; }
        public string hotelcode { get; set; }
        public int typecode { get; set; }
        public double price { get; set; }

        public Room(string roomno, string hotelcode, int typecode, double price)
        {
            this.roomno = roomno;
            this.hotelcode = hotelcode;
            this.typecode = typecode;
            this.price = price;
        }
    }
}