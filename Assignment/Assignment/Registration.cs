using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

namespace Assignment
{
    public class Registration
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string Title { get; set; }
        public string Mobile { get; set; }
        public string Dob { get; set; }
        public string Telefon { get; set; }
        public string Corporation { get; set; }
        public string Address { get; set; }
        public string Department { get; set; }

    }
}