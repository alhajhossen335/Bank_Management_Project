using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bank
{
    public static class AppSettings
    {
        public static string ConnectionString()
        {
            string constring = "server=localhost;port=3306;username=root;password=;database=bank_management_system";

            return constring;
        }
    }
}
