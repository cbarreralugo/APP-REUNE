using APP_REUNE.Vista;
using APP_REUNE_Negocio.Modelo;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace APP_REUNE.Service
{
    public class ReclamacionCredito_Service
    {
        private readonly HttpClient _client;

        public ReclamacionCredito_Service()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Configuracion_Modelo.api_reune.ToString())
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> SendReclamacion(ReclamacionCredito_Model reclamacion)
        {
            var json = JsonConvert.SerializeObject(reclamacion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Omitir el prefijo "Bearer"
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SesionUsuario_Modelo.token);

            try
            {
                var response = await _client.PostAsync("reune/reclamaciones/institucionescredito", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response StatusCode: " + response.StatusCode);
                Console.WriteLine("Response Body: " + responseBody);

                if (response.IsSuccessStatusCode)
                {
                    Toast.Correcto("Operación exitosa!!");
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: " + responseBody);
                    Toast.Error("Error sending reclamacion: " + responseBody);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Toast.Error("Exception sending reclamacion: " + ex.Message);
                return false;
            }
        }
    }
}
