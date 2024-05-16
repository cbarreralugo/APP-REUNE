using System;
using System.IO;
using System.Web.UI.WebControls;

namespace APP_REUNE.Utilidad
{
    public class SesionTemporal
    {
        private static readonly string folderPath = @"C:\Temp_File\Reune\SesionTemporal";
        private static readonly string filePath = Path.Combine(folderPath, "sesion.txt");

        public static void CreateFile(string word1, string word2)
        {
            try
            {
                // Validar y crear la carpeta si no existe
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // Crear y escribir en el archivo
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    writer.WriteLine($"{word1}|{word2}");
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
    }

}
