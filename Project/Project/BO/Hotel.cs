using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.BO
{
    public class Hotel
    {
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }

        public Hotel(string code, string name, string address)
        {
            this.code = code;
            this.name = name;
            this.address = address;
        }
    }
}