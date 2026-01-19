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
            string connectionString = "Data Source=ALIEN3;Initial Catalog=JGuevaraDiciembre;User ID=sa;Password=Qwerty123456$$$#;Encrypt=False";
            return connectionString;
        }
    }
}
