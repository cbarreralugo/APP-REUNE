using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using APP_REUNE.Modelo;

namespace APP_REUNE.Service
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("api-reune-pruebas.condusef.gob.mx/auth/users/create-super-user/")
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // Creación de Súper Usuario
        public async Task<string> CreateSuperUser(string key, string username, string password)
        {
            var data = new
            {
                key = key,
                username = username,
                password = password,
                confirm_password = password
            };
            try
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _client.PostAsync("auth/users/create-super-user/", content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);
                    return tokenResponse?.Data?.TokenAccess;
                }
                else
                {

                    throw new ApplicationException("No se pudo crear el superusuario: " + response.ReasonPhrase);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de sistema! ", ex.Message);
                return "No se pudo crear el superusuario, " + ex.Message;
            }
        }
        // Creación de Usuario
        public async Task<bool> CreateUser(string token, string username, string password)
        {
            var data = new
            {
                username = username,
                password = password,
                confirm_password = password
            };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.PostAsync("auth/users/create-user/", content);
            return response.IsSuccessStatusCode;
        }
        // Renovación de Token
        public async Task<string> RenewToken(string username, string password)
        {
            var data = new
            {
                username = username,
                password = password
            };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("auth/users/token/", content);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(result);
                return loginResponse?.User?.TokenAccess;
            }
            return null;
        }
    }
}
