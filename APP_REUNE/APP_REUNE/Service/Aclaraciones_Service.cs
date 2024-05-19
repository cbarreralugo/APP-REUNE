﻿using APP_REUNE_Negocio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using APP_REUNE.Vista;
using APP_REUNE.Vista.Pages; // Asegúrate de tener esta referencia para la serialización

namespace APP_REUNE.Service
{
    public class Aclaraciones_Service
    {
        private readonly HttpClient _client;

        public Aclaraciones_Service()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Configuracion_Modelo.api_reune)
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> SendAclaracion(Aclaracion_Model aclaracion)
        {
            var json = JsonConvert.SerializeObject(aclaracion);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SesionUsuario_Modelo.token);

            try
            {
                var response = await _client.PostAsync("reune/aclaraciones/general", content);
                var responseContent = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response StatusCode: " + response.StatusCode);
                Console.WriteLine("Response Body: " + responseContent);

                if (response.IsSuccessStatusCode)
                {
                    ResponseAPI apiWindow = new ResponseAPI();
                    apiWindow.LoadResponse(responseContent);
                    apiWindow.Show();
                    Toast.Correcto("Operación exitosa!!");
                    return responseContent;
                }
                else
                {
                    Toast.Error("Error sending aclaracion: " + responseContent);
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                Toast.Error("Exception sending aclaracion: " + ex.Message);
                return null;
            }
        }


    }
}
