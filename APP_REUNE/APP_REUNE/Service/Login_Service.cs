using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using APP_REUNE.Modelo;
using System.Windows;
using System.Configuration;
using APP_REUNE.Vista;

namespace APP_REUNE.Service
{
    public class ApiServiceLogin
    {
        private readonly HttpClient _client;

        public ApiServiceLogin()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api-reune-pruebas.condusef.gob.mx/")
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> IniciarSesion(string username, string password)
        {
            bool ValidaLogin = false;

            try
            {
                ValidaLogin = bool.Parse(ConfigurationManager.AppSettings["login"].ToString());
                if (ValidaLogin)
                {
                    var builder = new UriBuilder($"{_client.BaseAddress}auth/users/token/");
                    builder.Query = $"username={Uri.EscapeDataString(username)}&password={Uri.EscapeDataString(password)}";

                    HttpResponseMessage response = await _client.GetAsync(builder.Uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(result);
                        return loginResponse?.User?.TokenAccess;
                    }
                    else
                    {
                        var errorResult = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Error de autenticación: " + errorResult);
                        return null;
                    }
                }
                else
                {
                    return  "Logeo exitoso!";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión con la API: " + ex.Message);
                return null;
            }
        }









    } 

}
