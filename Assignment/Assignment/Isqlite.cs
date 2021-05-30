using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Assignment
{
    public interface Isqlite
    {
        SQLiteConnection GetConnection();
    }
}
