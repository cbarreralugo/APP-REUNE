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
        public static void CargarComboRamo(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(25, "Vida"),
            new Combo(26, "Accidentes y enfermedades"),
            new Combo(27, "Daños"),
            new Combo(33, "Pensiones")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }
        public static void CargarComboResolucion(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(1, "Totalmente favorable al Usuario"),
            new Combo(2, "Desfavorable al Usuario"),
            new Combo(3, "Parcialmente favorable al Usuario.")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboOperacionExtranjero(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo("SI", "SI"),
            new Combo("NO", "NO")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboReversa(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(0, "No es reversa SIGE (Gestión electrónica)"),
            new Combo(1, "Si es reversa SIGE (Gestión electrónica)")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboNivelAtencion(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(1, "UNE"),
            new Combo(2, "Sucursal"),
            new Combo(3, "Centro de atención telefonica"),
            new Combo(4, "Oficinas de atención")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboEdad(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>();

            // Bucle para añadir edades de 18 a 99 años
            for (int edad = 18; edad <= 99; edad++)
            {
                items.Add(new Combo(edad, edad + " años"));
            }

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboSexo(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo("H", "Hombre"),
            new Combo("M", "Mujer")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboTipoPersona(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(1, "Física"),
            new Combo(2, "Moral")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboPORI(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo("SI", "SI"),
            new Combo("NO", "NO")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboMonetario(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo("SI", "SI"),
            new Combo("NO", "NO")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboEstadoConPend(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(1, "Pendiente"),
            new Combo(2, "Concluido")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboNumero(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(1, "1"),

        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            comboBox.SelectedIndex = 0;
        }

        public static void CargarComboTrimestre(ComboBox comboBox)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(1, "Primer trimestre"),
            new Combo(2, "Segundo trimestre"),
            new Combo(3, "Tercer trimestre") ,
            new Combo(4, "Cuarto trimestre")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            SelectComboBoxItemById(comboBox, GetActualTrimestre());
        }



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

        public static void CargarComboReclamaciones(ComboBox comboBox, int id)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(0, "Instituciones de Céredito"),
            new Combo(1, "General"),
            new Combo(2, "Seguros")
        };

            comboBox.ItemsSource = items;
            comboBox.DisplayMemberPath = "Text";
            comboBox.SelectedValuePath = "ID";

            // Seleccionar el elemento con ID especificado
            SelectComboBoxItemById(comboBox, id);
        }

        public static void CargarComboAclaraciones(ComboBox comboBox, int id)
        {
            List<Combo> items = new List<Combo>
        {
            new Combo(0, "General")
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

        private static int GetActualTrimestre()
        {
            int month = DateTime.Now.Month;
            return (month + 2) / 3;
        }
    }
}
