﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using APP_REUNE_Negocio.Modelo;
using APP_REUNE_Negocio.Datos;
using APP_REUNE.Vista;

namespace APP_REUNE.Service
{
    public class ApiService
    {
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Configuracion_Modelo.api_reune)
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
        public async Task<bool> CreateUser(string username, string password)
        {
            var data = new
            {
                username = username,
                password = password,
                confirm_password = password
            };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionUsuario_Modelo.token);

            var response = await _client.PostAsync("auth/users/create-user/", content);

            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                var responseData = JsonConvert.DeserializeObject<ResponseModel>(responseString);

                if (responseData != null && responseData.data != null)
                {
                    Usuario_Modelo user = new Usuario_Modelo
                    {
                        id_usuario = responseData.data.userid,  // Asumiendo que el userid es un int, necesitarás parsearlo
                        nombre = responseData.data.username,
                        password = responseData.data.password, // Considera no almacenar contraseñas en texto plano o hash visible
                        token = responseData.data.token_access,
                        fecha = DateTime.Now.ToString("yyyy-MM-dd"), // Formato de fecha como ejemplo
                        perfil = responseData.data.profileid.ToString(),
                        esta_activo = responseData.data.is_active == "true"
                    };
                    Usuario_Datos datos = new Usuario_Datos();
                    datos.CrearUsuario(user);
                    Toast.Correcto("Usuario: " + user.nombre.ToString() + " creado".ToString(), "Usuario creado");
                    Toast.CreateLog("Usuario creado","Usuario: " + user.nombre.ToString() + " creado".ToString()); 
                    return true;
                }
            }
            Toast.Error("Error al crear el usuario: "+username.ToString(), "Intenta de nuevo");
            Toast.CreateLog("Error al crear el usuario: " + username.ToString(), "Verifica que el token de super usuario sea valido y cuente con los permisos necesarios\n No se logro crear el usuario.");
            return false;
        }

       
        public async Task<bool> CreateUser2(string username, string password)
        {
            var data = new
            {
                username = username,
                password = password,
                confirm_password = password
            };
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionUsuario_Modelo.token);

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
