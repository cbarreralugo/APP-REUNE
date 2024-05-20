using Newtonsoft.Json;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using APP_REUNE_Negocio.Modelo;
using APP_REUNE_Negocio.Datos;
using APP_REUNE.Vista;
using System.IO;
using System.Net;
using RestSharp;


namespace APP_REUNE.Service
{
    public class ApiService
    {
        
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri(Configuracion_Modelo.api_reune.ToString())
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<bool> CreateUser(string username, string password)
        {
            var data = new
            {
                username = username,
                password = password,
                confirm_password = password
            };

            // Omitir el prefijo "Bearer"
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SesionUsuario_Modelo.token);

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("auth/users/create-user/", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response StatusCode: " + response.StatusCode);
                Console.WriteLine("Response Body: " + responseBody);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<ResponseModel>(responseBody);
                    if (responseData != null && responseData.data != null)
                    {
                        Usuario_Modelo user = new Usuario_Modelo
                        { 
                            nombre = username,
                            password = password,
                            token = responseData.data.token_access.ToString(),
                            fecha = DateTime.Now.ToString("yyyy-MM-dd"), 
                            esta_activo = responseData.data.is_active.ToString(),
                            userid_api = responseData.data.userid.ToString(),
                            username_api = responseData.data.username.ToString(),
                            password_api = responseData.data.password.ToString(),
                            institucionid_api = responseData.data.institucionid.ToString(),
                            is_active_api = responseData.data.is_active.ToString(),
                            profileid_api = responseData.data.profileid.ToString(),
                            date_api = responseData.data.date.ToString(),
                            system_api = responseData.data.system.ToString()
                        };
                        Usuario_Datos datos = new Usuario_Datos();
                        datos.CrearUsuario(user);
                        Toast.Correcto("Usuario: " + user.nombre + " creado", "Usuario creado");
                        return true;
                    }
                    else
                    {
                        Toast.Log("Usuario creado con errores", "El Usuario se creo con exito, pero se genero un error al obtener los datos de respuesta de la API");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + responseBody);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }



        public async Task<bool> RenewToken(string username, string password)
        {
            var data = new
            {
                username = username,
                password = password
            };

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("auth/users/token/", content);
                var responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Response StatusCode: " + response.StatusCode);
                Console.WriteLine("Response Body: " + responseBody);

                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject<TokenResponseModel>(responseBody);
                    if (responseData != null && responseData.user != null)
                    {
                        Usuario_Modelo user = new Usuario_Modelo
                        {
                            nombre = username,
                            token = responseData.user.TokenAccess.ToString(),
                            fecha = DateTime.Now.ToString("yyyy-MM-dd"),
                            username_api = responseData.user.Username.ToString()
                        };

                        // Aquí guardas el usuario con el token renovado en la base de datos
                        Usuario_Datos datos = new Usuario_Datos();
                        datos.Actualizar(user); 
                        Toast.Correcto("Token renovado correctamente para el usuario: " + user.nombre, "Token renovado");
                        return true;
                    }
                    else
                    {
                        Toast.Log("Error al renovar el token", "Se obtuvo una respuesta pero sin los datos esperados.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("Error: " + responseBody);
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
        }


    }
}

