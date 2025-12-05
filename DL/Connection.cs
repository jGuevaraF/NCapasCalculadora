using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Connection
    {
        public static string GetConnection()
        {
            string connectionString = "Data Source=.;Initial Catalog=JGuevaraDiciembre;User ID=sa;Password=pass@word1;Encrypt=False";
            return connectionString;
        }
    }
}
