using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Assignment
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
    }
}
