using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP_REUNE_Negocio.Modelo;
using APP_REUNE.Vista.Forms;
using System.Net;
using System.Text.RegularExpressions;
using APP_REUNE_Negocio.Datos;

namespace APP_REUNE.Vista
{
    public static class Toast
    {
        // Usando métodos estáticos para diferentes tipos de alertas
        public static void Error(string message, string title = "Error inesperado!. ")
        {
            ShowAlert(title, message, Form_Toast.enmType.Error);
        }

        public static void Correcto(string message, string title = "Acción correcta!. ")
        {
            ShowAlert(title, message, Form_Toast.enmType.Success);
        }

        public static void Notifiacion(string message, string title = "Hey!... ")
        {
            ShowAlert(title, message, Form_Toast.enmType.Info);
        }

        public static void Denegado(string message, string title = "Acción no autorizada!. ")
        {
            ShowAlert(title, message, Form_Toast.enmType.Warning);
        }

        public static void Sistema(string message, Exception ex, string title = "Se genero un error de Sistema. ")
        {
            ShowAlert(title, message + "\n " + ex.ToString(), Form_Toast.enmType.System);
        }

        public static void Log(string message, string title = "Acción guardada en log!. ")
        {
            ShowAlert(title, message, Form_Toast.enmType.Warning);
            CreateLog(title, message);
        }

        private static void ShowAlert(string title, string message, Form_Toast.enmType type)
        {
            Task.Run(() =>
            {
                Form_Toast frm = new Form_Toast();
                frm.showAlert(title, Process(message), type);
                Application.Run(frm);
            });
        }

        private static string Process(string message)
        {
            // Primero, intenta dividir el mensaje en la clave y el valor si está en formato "clave: valor"
            var parts = message.Split(new[] { ':' }, 2);
            if (parts.Length > 1)
            {
                message = parts[1];  // Tomar solo el valor después del primer ':' 
            }

            // Decodificar HTML para asegurarse de que no haya entidades HTML
            message = System.Net.WebUtility.HtmlDecode(message);

            // Eliminar caracteres JSON específicos y espacios adicionales
            message = System.Text.RegularExpressions.Regex.Replace(message, @"[{}"",\\]", "").Trim();

            // Normalizar espacios en blanco, reemplazando secuencias de espacios con un solo espacio
            message = System.Text.RegularExpressions.Regex.Replace(message, @"\s+", " ");

            return message;
        }

        public static void CreateLog(string title, string message)
        {
            int logOption = int.Parse(ConfigurationManager.AppSettings["WriteFileLog"] ?? "0");
            string logMessage = FormatLogMessage(title, message);

            if (logOption == 1 || logOption == 2)
            {
                WriteToFile(logMessage);
            }

            if (logOption == 0 || logOption == 2)
            {
                WriteToDatabase(title,logMessage);
            }
        }

        private static string FormatLogMessage(string title, string message)
        {
            string timestamp = DateTime.Now.ToString("dd-MM-yyyy, HH:mm:ss");
            string machineName = Environment.MachineName;
            return $"===========\n**{title}**\n[{timestamp}] - Creación de log.\nMensaje: {message}\nEquipo: {machineName}\n===========";
        }

        private static void WriteToFile(string message)
        {
            // Obtiene o establece la ruta del directorio de logs desde el archivo de configuración.
            // Si no se encuentra, usa un directorio predeterminado.
            string directoryPath = ConfigurationManager.AppSettings["PathLogLocal"] ?? @"C:\Log_Reune";
            string fileName = DateTime.Now.ToString("dd_MM_yyyy") + ".log";
            string filePath = Path.Combine(directoryPath, fileName);

            // Asegurarse de que el directorio exista, si no, crearlo.
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                Toast.Notifiacion("Carpeta log creada en: " + directoryPath);
            }

            // Escribir el mensaje al archivo de log, añadiéndolo al final del archivo.
            // La función AppendAllText maneja la apertura y cierre del archivo automáticamente.
            File.AppendAllText(filePath, message + Environment.NewLine);
        }

        private static void WriteToDatabase(string title,string message)
        {
            // Simulación de escritura en base de datos
            Log_Modelo log = new Log_Modelo();
            try
            {
                log.id_usuario = SesionUsuario_Modelo.id_usuario;
                log.fecha = (DateTime.Now.ToString("dd-MM-yyyy, HH:mm:ss")).ToString();
                log.mensaje = message;
                log.equipo = Environment.MachineName;
                log.nombreUsuario = (SesionUsuario_Modelo.nombre ==null  ? log.equipo : SesionUsuario_Modelo.nombre);
                log.titulo = title;

                Log_Datos datos = new Log_Datos();
                datos.CrearLog(log);
            }
            catch (Exception ex)
            {
                Toast.Sistema("Error al crear log en BD",ex);
            }


            // Aquí se insertaría el log en la base de datos 
        }
    }
}