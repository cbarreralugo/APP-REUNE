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
        //private readonly HttpClient _client;

        //public ApiService()
        //{
        //    _client = new HttpClient
        //    {
        //        BaseAddress = new Uri(Configuracion_Modelo.api_reune)
        //    };
        //    _client.DefaultRequestHeaders.Accept.Clear();
        //    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //}



        // Creación de Súper Usuario
        //public async Task<string> CreateSuperUser(string key, string username, string password)
        //{
        //    var data = new
        //    {
        //        key = key,
        //        username = username,
        //        password = password,
        //        confirm_password = password
        //    };
        //    try
        //    {
        //        var json = JsonConvert.SerializeObject(data);
        //        var content = new StringContent(json, Encoding.UTF8, "application/json");

        //        var response = await _client.PostAsync("auth/users/create-super-user/", content);
        //        if (response.IsSuccessStatusCode)
        //        {
        //            var result = await response.Content.ReadAsStringAsync();
        //            var tokenResponse = JsonConvert.DeserializeObject<TokenResponse>(result);
        //            return tokenResponse?.Data?.TokenAccess;
        //        }
        //        else
        //        {

        //            throw new ApplicationException("No se pudo crear el superusuario: " + response.ReasonPhrase);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error de sistema! ", ex.Message);
        //        return "No se pudo crear el superusuario, " + ex.Message;
        //    }
        //}

        //private readonly RestClient _client;

        //public ApiService()
        //{
        //    _client = new RestClient("https://api-reune-pruebas.condusef.gob.mx/");
        //}

        //public async Task<bool> CreateUser(string username, string password )
        //{
        //    var request = new RestRequest("auth/users/create-user/", Method.Post);

        //    request.AddHeader("Connection", "keep-alive");
        //    request.AddHeader("Authorization",  SesionUsuario_Modelo.token);

        //    var data = new
        //    {
        //        username = username,
        //        password = password,
        //        confirm_password = password
        //    };

        //    var json = JsonConvert.SerializeObject(data);
        //    request.AddParameter("application/json", json, ParameterType.RequestBody);

        //    try
        //    {
        //        var response = await _client.ExecuteAsync(request); 
        //        Console.WriteLine("Response StatusCode: " + response.StatusCode);
        //        Console.WriteLine("Response Body: " + response.Content);

        //        if (response.IsSuccessful)
        //        {
        //            var responseData = JsonConvert.DeserializeObject<ResponseModel>(response.Content);
        //            if (responseData != null && responseData.data != null)
        //            {
        //                Usuario_Modelo user = new Usuario_Modelo
        //                {
        //                    id_usuario = responseData.data.userid,   
        //                    nombre = responseData.data.username,
        //                    password = responseData.data.password,  
        //                    token = responseData.data.token_access,
        //                    fecha = DateTime.Now.ToString("yyyy-MM-dd"),  
        //                    perfil = responseData.data.profileid.ToString(),
        //                    esta_activo = responseData.data.is_active == "true"
        //                };
        //                Usuario_Datos datos = new Usuario_Datos();
        //                datos.CrearUsuario(user);
        //                Toast.Correcto("Usuario: " + user.nombre.ToString() + " creado", "Usuario creado");
        //                Toast.CreateLog("Usuario creado", "Usuario: " + user.nombre.ToString() + " creado");
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("Error: " + response.Content);
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Exception: " + ex.Message);
        //        return false;
        //    }
        //}
        private readonly HttpClient _client;

        public ApiService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api-reune-pruebas.condusef.gob.mx/")
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


        //public async Task<bool> CreateUser(string username, string password)
        //{ 
        //    var data = new
        //    {
        //        username = username,
        //        password = password,
        //        confirm_password = password
        //    }; 

        //    _client.DefaultRequestHeaders.Accept.Clear();
        //    _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionUsuario_Modelo.token.ToString());

        //    var json = JsonConvert.SerializeObject(data);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    try
        //    {
        //        // Imprimir detalles de la solicitud
        //        Console.WriteLine("Request URL: " + _client.BaseAddress + "auth/users/create-user/");
        //        Console.WriteLine("Authorization: " + _client.DefaultRequestHeaders.Authorization);
        //        Console.WriteLine("Request Body: " + json);

        //        var response = await _client.PostAsync("auth/users/create-user/", content);
        //        var responseBody = await response.Content.ReadAsStringAsync();

        //        // Imprimir detalles de la respuesta
        //        Console.WriteLine("Response StatusCode: " + response.StatusCode);
        //        Console.WriteLine("Response Body: " + responseBody);

        //        if (response.IsSuccessStatusCode)
        //        {
        //            var responseData = JsonConvert.DeserializeObject<ResponseModel>(responseBody);

        //            if (responseData != null && responseData.data != null)
        //            {
        //                Usuario_Modelo user = new Usuario_Modelo
        //                {
        //                    id_usuario = responseData.data.userid,  // Asumiendo que el userid es un int, necesitarás parsearlo
        //                    nombre = responseData.data.username,
        //                    password = responseData.data.password, // Considera no almacenar contraseñas en texto plano o hash visible
        //                    token = responseData.data.token_access,
        //                    fecha = DateTime.Now.ToString("yyyy-MM-dd"), // Formato de fecha como ejemplo
        //                    perfil = responseData.data.profileid.ToString(),
        //                    esta_activo = responseData.data.is_active == "true"
        //                };
        //                Usuario_Datos datos = new Usuario_Datos();
        //                datos.CrearUsuario(user);
        //                Toast.Correcto("Usuario: " + user.nombre.ToString() + " creado", "Usuario creado");
        //                Toast.CreateLog("Usuario creado", "Usuario: " + user.nombre.ToString() + " creado");
        //                return true;
        //            }
        //        }
        //        else
        //        {
        //            Toast.Error("Error al crear el usuario: " + username, "Intenta de nuevo");
        //            Toast.CreateLog("Error al crear el usuario: " + username, "Respuesta de la API: " + responseBody); 
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Toast.Error("Error al realizar la solicitud: " + ex.Message, "Error de solicitud");
        //        Toast.CreateLog("Error al realizar la solicitud: " + ex.Message, "Excepción capturada");
        //    }

        //    return false;
        //}



        //public async Task<bool> CreateUser2(string username, string password)
        //{
        //    var data = new
        //    {
        //        username = username,
        //        password = password,
        //        confirm_password = password
        //    };
        //    var json = JsonConvert.SerializeObject(data);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");
        //    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", SesionUsuario_Modelo.token);

        //    var response = await _client.PostAsync("auth/users/create-user/", content);

        //    return response.IsSuccessStatusCode;
        //}
        // Renovación de Token
        //public async Task<string> RenewToken(string username, string password)
        //{
        //    var data = new
        //    {
        //        username = username,
        //        password = password
        //    };
        //    var json = JsonConvert.SerializeObject(data);
        //    var content = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = await _client.PostAsync("auth/users/token/", content);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        var result = await response.Content.ReadAsStringAsync();
        //        var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(result);
        //        return loginResponse?.User?.TokenAccess;
        //    }
        //    return null;
        //}


    }
}

