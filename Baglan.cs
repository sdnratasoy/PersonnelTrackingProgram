using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Sqlite
{
    internal class Baglan
    {
       public static SQLiteConnection connection = new SQLiteConnection("Data source=.\\Veritabani.db;Version=3");
        
    }
}
