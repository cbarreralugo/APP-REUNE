using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE.Modelo
{
    public class Login_Modelo
    {
        string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
        public string msg { get; set; }
        Login_Modelo()
        {
            username = "";
            password = "";
            token = "";
            msg = "";
        }
    }
}
