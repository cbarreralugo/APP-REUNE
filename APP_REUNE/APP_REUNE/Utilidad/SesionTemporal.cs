using APP_REUNE.Vista;
using APP_REUNE_Negocio.Modelo;
using EncryptionLibrary;
using System;
using System.Diagnostics;
using System.IO; 
using System.Windows;

namespace APP_REUNE.Utilidad
{
    public class SesionTemporal
    {
        private static string folderPath;
        private static string filePath;
        private static AESEncryptor AES;
        private static bool isInitialized = false;

        public static void Initialize()
        {
            try
            {
                AES = new AESEncryptor();
                string ruta = (Configuracion_Modelo.ruta_sesion_temporal);
                folderPath = Path.Combine("", ruta);
                filePath = Path.Combine(folderPath, "sesion.txt");
                isInitialized = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during initialization: {ex.Message}");
                isInitialized = false;
            }
        }

        public static void CreateFile(string word1, string word2)
        {
            if (!isInitialized)
            {
                Console.WriteLine("SesionTemporal is not initialized.");
                return;
            }

            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine(AES.Encrypt($"{word1}|{word2}"));
                }

                Console.WriteLine("Archivo creado con éxito en: " + filePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear el archivo: " + ex.Message);
            }
        }

        public static string ReadFile()
        {
            if (!isInitialized)
            {
                Console.WriteLine("SesionTemporal is not initialized.");
                return null;
            }

            try
            {
                if (File.Exists(filePath))
                {
                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        string content = reader.ReadToEnd();
                        return content;
                    }
                }
                else
                {
                    Console.WriteLine("El archivo no existe.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo: " + ex.Message);
                return null;
            }
        }

        public static void DeleteFile()
        {
            if (!isInitialized)
            {
                Console.WriteLine("SesionTemporal is not initialized.");
                return;
            }

            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                    Console.WriteLine("Archivo eliminado con éxito.");
                }
                else
                {
                    Console.WriteLine("El archivo no existe.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al eliminar el archivo: " + ex.Message);
            }
        }

        public static (string, string) SplitContent(string content)
        {
            if (content == null)
            {
                Console.WriteLine("El contenido es nulo.");
                return (null, null);
            }

            var parts = content.Split('|');
            if (parts.Length == 2)
            {
                return (parts[0].Trim(), parts[1].Trim());
            }
            else
            {
                Console.WriteLine("El contenido no está en el formato esperado.");
                return (null, null);
            }
        }

        public static bool GuardarPreInfo(string campos, string fileName)
        {
            string rutaFilePreInfo = Path.Combine(Configuracion_Modelo.pre_info.ToString(), fileName);
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                using (StreamWriter writer = new StreamWriter(rutaFilePreInfo))
                {
                    writer.WriteLine(AES.Encrypt(campos));
                }

                Toast.Correcto("Datos guardados correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al guardar los datos: " , ex);
                return false;
            }
        } 

        public static string ObtenerPreInfo(string fileName)
        {
            string rutaFilePreInfo = Path.Combine(Configuracion_Modelo.pre_info.ToString(), fileName);
            string campos = "";
            try
            {
                if (File.Exists(rutaFilePreInfo))
                {
                    campos = AES.Decrypt(File.ReadAllText(rutaFilePreInfo));
                }
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al obtener los datos: ", ex);
                campos = string.Empty;
            }
            return campos;
        }

        public static void RestartApplication()
        { 
            string applicationPath = System.Reflection.Assembly.GetExecutingAssembly().Location;

            Toast.CreateLog("Reinicio forzoso de app", "Se ha reiniciado la aplicación de manera inesperada.");
            ProcessStartInfo startInfo = new ProcessStartInfo(applicationPath)
            {
                WorkingDirectory = System.IO.Path.GetDirectoryName(applicationPath)
            };
             
            Process.Start(startInfo);
             
            Application.Current.Shutdown();
        }

    }
}
