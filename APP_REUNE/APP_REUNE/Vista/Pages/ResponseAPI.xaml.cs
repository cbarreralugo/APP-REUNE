using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace APP_REUNE.Vista.Pages
{
    /// <summary>
    /// Lógica de interacción para ResponseAPI.xaml
    /// </summary>
    public partial class ResponseAPI : Window
    {
        public ResponseAPI()
        {
            InitializeComponent();
        }
        public void LoadResponse(string responseText,DataTable table=null, string titleTable=null)
        {
            if (table.Rows.Count>0)
            {
                dg_tabla.LoadData(table, titleTable);
                Toast.Correcto(titleTable);
            }
            else
            {
                Toast.Error(titleTable);
            }
            DisplayResponse(responseText);
        }

        // Start: Button Close | Restore | Minimize 
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnRestore_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;
            else
                WindowState = WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        // End: Button Close | Restore | Minimize

        public class ApiResponse_Model
        {
            public string Message { get; set; }
            public Dictionary<string, string> Data { get; set; } // Ajusta esto según el formato de tu respuesta
        }

        private void DisplayResponse(string jsonResponse)
        {
            var apiResponse = JsonConvert.DeserializeObject<ApiResponse_Model>(jsonResponse);
            txtApiResponse.Text = $"Mensaje: {apiResponse.Message}\nUserID: {apiResponse.Data["userid"]}";
        }
    }
}
