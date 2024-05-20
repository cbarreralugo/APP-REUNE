using APP_REUNE_Negocio.Modelo;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using APP_REUNE.Vista.Pages;
using APP_REUNE.Vista;
using System.Windows;

namespace APP_REUNE.Service
{
    public class Aclaraciones_Service
    {
        private readonly HttpClient _client;

        public Aclaraciones_Service()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Configuracion_Modelo.api_reune.ToString())
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> SendAclaracion(Aclaracion_Model aclaracion)
        {
            var json = JsonConvert.SerializeObject(aclaracion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Omitir el prefijo "Bearer"
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SesionUsuario_Modelo.token);

            try
            {
                var response = await _client.PostAsync("reune/aclaraciones/general", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response StatusCode: " + response.StatusCode);
                Console.WriteLine("Response Body: " + responseBody);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Correcto:" + responseBody);
                    Toast.Correcto("Operación exitosa!!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: " + responseBody);
                    Toast.Error("Error sending aclaracion: " + responseBody);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Toast.Error("Exception sending aclaracion: " + ex.Message);
                return false;
            }
        }
    }
}
