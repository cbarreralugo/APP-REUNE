using APP_REUNE_Negocio.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
using System.Windows.Controls;

namespace APP_REUNE.Utilidad
{
    public static class Util
    {
        public static void CargarComboLog(ComboBox comboBox, int id)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(0, "Solo en Base de datos"),
            new Combo(1, "Solo en archivo .log"),
            new Combo(2, "En Base de datos y archivo .log")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            SelectComboBoxItemById(comboBox, id);
        }

        private static void SelectComboBoxItemById(ComboBox comboBox, int id)
        {
            foreach (Combo item in comboBox.Items)
            {
                if (item.ID == id)
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }
    }
}
