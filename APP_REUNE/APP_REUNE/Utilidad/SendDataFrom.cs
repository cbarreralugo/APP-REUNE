using APP_REUNE.Vista.Pages;
using APP_REUNE.Vista;
using APP_REUNE_Negocio.Modelo;
using ClosedXML.Excel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace APP_REUNE.Utilidad
{
    public static class SendDataFrom
    {
        public static async Task<bool> SendDataFromJson<TModel>(string endpoint)
        {
            try
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

                    var data = JsonConvert.DeserializeObject<List<TModel>>(jsonContent);

                    if (data != null)
                    {
                        var success = await SendData(data, endpoint);
                        return success;
                    }
                    else
                    {
                        Toast.Error("El archivo JSON no es válido.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema($"Error al leer archivo de JSON:", ex);
            }
            return false;
        }

        public static async Task<bool> SendDataFromTxt<TModel>(string endpoint)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Text files (*.txt)|*.txt",
                    Title = "Seleccionar archivo de texto"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;
                    string[] lines = File.ReadAllLines(filePath);

                    if (lines.Length > 1)
                    {
                        var headers = lines[0].Split('|');
                        var data = new List<TModel>();

                        foreach (var line in lines.Skip(1))
                        {
                            var values = line.Split('|');
                            var json = new StringBuilder("{");
                            for (int i = 0; i < headers.Length; i++)
                            {
                                json.Append($"\"{headers[i]}\":\"{values[i]}\"");
                                if (i < headers.Length - 1) json.Append(",");
                            }
                            json.Append("}");
                            data.Add(JsonConvert.DeserializeObject<TModel>(json.ToString()));
                        }

                        var success = await SendData(data, endpoint);
                        return success;
                    }
                    else
                    {
                        Toast.Error("El archivo no contiene datos válidos.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema($"Error al leer archivo de texto:", ex);
            }
            return false;
        }

        public static async Task<bool> SendDataFromExcel<TModel>(string endpoint)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel files (*.xlsx)|*.xlsx",
                    Title = "Seleccionar archivo de Excel"
                };

                if (openFileDialog.ShowDialog() == true)
                {
                    string filePath = openFileDialog.FileName;
                    var workbook = new XLWorkbook(filePath);
                    var worksheet = workbook.Worksheets.First();
                    var rows = worksheet.RowsUsed().Skip(1); // Skip header row

                    var headers = worksheet.Row(1).Cells().Select(c => c.Value.ToString()).ToArray();
                    var data = new List<TModel>();

                    foreach (var row in rows)
                    {
                        var json = new StringBuilder("{");
                        for (int i = 0; i < headers.Length; i++)
                        {
                            var value = row.Cell(i + 1).Value.ToString();
                            json.Append($"\"{headers[i]}\":\"{value}\"");
                            if (i < headers.Length - 1) json.Append(",");
                        }
                        json.Append("}");
                        data.Add(JsonConvert.DeserializeObject<TModel>(json.ToString()));
                    }

                    var success = await SendData(data, endpoint);
                    return success;
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema($"Error al leer archivo de Excel:",ex);
            }
            return false;
        }

        public static async Task<bool> SendData<TModel>(List<TModel> data, string endpoint)
        { 
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Configuracion_Modelo.api_reune.ToString());
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(SesionUsuario_Modelo.token.ToString());

                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await client.PostAsync(endpoint, content);
                    var responseBody = await response.Content.ReadAsStringAsync();

                    Console.WriteLine("Response StatusCode: " + response.StatusCode);
                    Console.WriteLine("Response Body: " + responseBody);

                    if (response.IsSuccessStatusCode)
                    {
                        ResponseAPI aPI = new ResponseAPI(); 
                        Toast.Correcto("Response Body: " + responseBody, "Operación exitosa!!");
                        aPI.LoadResponse(responseBody);
                        aPI.Show();
                        return true;
                    }
                    else
                    {
                        Toast.Error("Error: " + responseBody,"Verifica los campos, intenta de nuevo.");
                        Toast.CreateLog("Error sending data", responseBody);
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    Toast.Sistema("Exception sending data", ex);
                    return false;
                }
            }
        }
    }
}
