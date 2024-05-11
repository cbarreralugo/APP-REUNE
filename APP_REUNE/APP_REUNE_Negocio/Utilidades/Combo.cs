using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE_Negocio.Utilidades
{



    public class Combo
    {
        public int ID { get; set; }
        public string Text { get; set; }

        public Combo(int id, string text)
        {
            ID = id;
            Text = text;
        }
    }
}
