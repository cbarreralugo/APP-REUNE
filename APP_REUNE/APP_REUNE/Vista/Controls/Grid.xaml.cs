using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32; 

namespace APP_REUNE.Vista.Controls
{
    /// <summary>
    /// Lógica de interacción para UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        private DataView dataView;
        public UserControl1()
        {
            InitializeComponent();
            txtFilter.TextChanged += TxtFilter_TextChanged;
        }
        private void TxtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
           if (dataGrid.ItemsSource != null)
            {
                ApplyFilter();
            }
        }

        private void ApplyFilter()
        {
            if (dataView == null) return;

            string filterText = txtFilter.Text;
            if (string.IsNullOrWhiteSpace(filterText))
            {
                dataView.RowFilter = string.Empty;
            }
            else
            {
                StringBuilder filter = new StringBuilder();
                // Acceder a las columnas a través de la propiedad Table del DataView
                foreach (DataColumn column in dataView.Table.Columns)
                {
                    // Convertimos todos los valores a string antes de aplicar LIKE
                    filter.Append($"CONVERT([{column.ColumnName}], 'System.String') LIKE '%{filterText.Replace("'", "''")}%' OR ");
                }
                if (filter.Length > 4)
                {
                    filter.Length -= 4; // Remueve el último " OR "
                    dataView.RowFilter = filter.ToString();
                }
                else
                {
                    // No hay columnas o filtro formado incorrectamente, manejar apropiadamente
                    dataView.RowFilter = "1=0"; // Esto hará que no se muestre ninguna fila
                }
            }
        }



        public void LoadData(DataTable dataTable,string nombreTabla ="",string filtro="")
        { 
            if (dataTable != null)
            {
                tb_title.Content = nombreTabla;
                dataView = dataTable.DefaultView;
                dataGrid.ItemsSource = dataView; 
                AdjustHeightBasedOnRows();
                txtFilter.Text = filtro;
                txtFilter.Text = filtro;
                ApplyFilter(); // Aplicar filtro inicial si hay texto ya en el TextBox de filtro.
            }
            else
            {
                dataGrid.ItemsSource = null;
                dataView = null;
            }
        }

        private void AdjustHeightBasedOnRows()
        {
            int rows = ((DataView)dataGrid.ItemsSource).Count;
            double heightPerRow = 25;  // Estimación de la altura por fila
            double minHeight = 100;
            double maxHeight = 600;

            double newHeight = rows * heightPerRow + 95; // Añadir espacio para el título y botones
            if (newHeight < minHeight)
                newHeight = minHeight;
            else if (newHeight > maxHeight)
                newHeight = maxHeight;

            dataGrid.Height = newHeight - 55; // Ajustar por el espacio del título y botones
            this.Height = newHeight;
        }

        private void btn_ExportTxt_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file (*.txt)|*.txt";
            if (saveFileDialog.ShowDialog() == true)
            {
                ExportDataToTxt(saveFileDialog.FileName); 
                Toast.Correcto("Archivo txt creado correctamente");
                Toast.CreateLog("Se exporto información en un .txt", "Los datos de la tabla ".ToString() + tb_title.Content.ToString() + " \n" +
                    "Se exporto a la ubicación local:".ToString() + saveFileDialog.FileName.ToString() + " con exito!!!".ToString());
            }
        }

        private void btn_ExportCsv_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == true)
            {
                ExportDataToCsv(saveFileDialog.FileName);
                Toast.Correcto("Archivo csv creado correctamente");
                Toast.CreateLog("Se exporto información en un .csv","Los datos de la tabla ".ToString()+tb_title.Content.ToString()+" \n" +
                    "Se exporto a la ubicación local:".ToString()+ saveFileDialog.FileName.ToString()+" con exito!!!".ToString());
            }
        }

        private void ExportDataToTxt(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            // Añadir encabezados
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                sb.Append(dataGrid.Columns[i].Header.ToString());
                if (i < dataGrid.Columns.Count - 1) sb.Append("\t");
            }
            sb.AppendLine();

            // Añadir datos
            foreach (DataRowView row in dataGrid.ItemsSource)
            {
                for (int i = 0; i < row.Row.Table.Columns.Count; i++)
                {
                    sb.Append(row[i].ToString());
                    if (i < row.Row.Table.Columns.Count - 1) sb.Append("\t");
                }
                sb.AppendLine();
            }
            File.WriteAllText(filePath, sb.ToString());
        }

        private void ExportDataToCsv(string filePath)
        {
            StringBuilder sb = new StringBuilder();
            // Añadir encabezados
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                sb.Append($"\"{dataGrid.Columns[i].Header.ToString()}\"");
                if (i < dataGrid.Columns.Count - 1) sb.Append(",");
            }
            sb.AppendLine();

            // Añadir datos
            foreach (DataRowView row in dataGrid.ItemsSource)
            {
                for (int i = 0; i < row.Row.Table.Columns.Count; i++)
                {
                    sb.Append($"\"{row[i].ToString()}\"");
                    if (i < row.Row.Table.Columns.Count - 1) sb.Append(",");
                }
                sb.AppendLine();
            }
            File.WriteAllText(filePath, sb.ToString());
        }


    }
}
