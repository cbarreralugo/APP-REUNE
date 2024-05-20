﻿using APP_REUNE.Service;
using APP_REUNE_Negocio.Modelo;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace APP_REUNE.Vista.Pages.Reclamaciones
{
    /// <summary>
    /// Lógica de interacción para General.xaml
    /// </summary>
    public partial class General : Page
    {
        public General()
        {
            InitializeComponent();
            CargarPreInformacio();
        }

        private void CargarPreInformacio()
        {
            Utilidad.Util.CargarComboTrimestre(cb_RecTrimestre);
            Utilidad.Util.CargarComboNumero(cb_RecNumero);
            Utilidad.Util.CargarComboEstadoConPend(cb_RecEstadoConPend);
            Utilidad.Util.CargarComboMonetario(cb_RecMonetario);
            Utilidad.Util.CargarComboPORI(cb_RecPori);
            Utilidad.Util.CargarComboTipoPersona(cb_RecTipoPersona);
            Utilidad.Util.CargarComboSexo(cb_RecSexo);
            Utilidad.Util.CargarComboEdad(cb_RecEdad);
            Utilidad.Util.CargarComboNivelAtencion(cb_RecNivelAtencion);
            Utilidad.Util.CargarComboReversa(cb_RecReversa);
            Utilidad.Util.CargarComboResolucion(cb_RecSentidoResolucion);
            txt_RecDenominacion.Text = "SAM Asset Management S.A. de C.V., Sociedad Operadora de Fondos de Inversión.";
            txt_RecSector.Text = "Sociedad Operadora de Fondos de Inversión";
            txt_RecEntidadFederativa.Text = "09";
            txt_RecCodigoPostal.Text = "5120";
            txt_RecMunicipioAlcaldia.Text = "004";
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "JSON files (*.json)|*.json",
                Title = "Seleccionar archivo JSON"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string jsonContent = File.ReadAllText(filePath);

                var reclamacionGeneral = JsonConvert.DeserializeObject<ReclamacionGeneral_Model>(jsonContent);

                if (reclamacionGeneral != null)
                {
                    var apiService = new ReclamacionesGeneral_Service();
                    bool success = await apiService.SendReclamacion(reclamacionGeneral);

                    if (success)
                    {

                        Toast.Correcto("Archivo enviado correctamente.");
                    }
                    else
                    {
                        Toast.Error("Error al enviar el archivo.");
                    }
                }
                else
                {
                    Toast.Error("El archivo JSON no es válido.");
                }
            }
        }


        private async void btn_Enviar_Click(object sender, RoutedEventArgs e)
        {
            Toast.Denegado("Acción fuera de servicio");

        }

        private void btn_Limpiar_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
