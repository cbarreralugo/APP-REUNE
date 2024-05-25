using APP_REUNE.Vista;
using APP_REUNE_Negocio.Modelo;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Windows;
using APP_REUNE.Vista.Pages;

public class ReclamacionesSeguros_Service
{
    private readonly HttpClient _client;

    public ReclamacionesSeguros_Service()
    {
        _client = new HttpClient
        {
            BaseAddress = new Uri(Configuracion_Modelo.api_reune.ToString())
        };
        _client.DefaultRequestHeaders.Accept.Clear();
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<bool> SendReclamacionesSeguros(List<ReclamacionSeguros_Model> reclamaciones)
    {
        var json = JsonConvert.SerializeObject(reclamaciones);  
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SesionUsuario_Modelo.token);

        try
        {
            var response = await _client.PostAsync("reune/reclamaciones/seguros", content);
            var responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Response StatusCode: " + response.StatusCode);
            Console.WriteLine("Response Body: " + responseBody);

            if (response.IsSuccessStatusCode)
            {
                ResponseAPI aPI = new ResponseAPI();
                Toast.Correcto("Operación exitosa!!");
                Toast.Correcto("Response Body: " + responseBody);
                aPI.LoadResponse(responseBody);
                aPI.Show();
                return true;
            }
            else
            {
                Console.WriteLine("Error: " + responseBody);
                Toast.CreateLog("Error sending reclamaciones seguros", responseBody);
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
            Toast.CreateLog("Exception sending reclamaciones seguros", ex.Message);
            return false;
        }
    }
}
