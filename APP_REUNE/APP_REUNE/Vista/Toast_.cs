using System;
using System.Configuration;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP_REUNE.Modelo;
using APP_REUNE.Vista.Forms; 

namespace APP_REUNE.Vista
{
    public static class Toast_
    {
        // Usando métodos estáticos para diferentes tipos de alertas
        public static void Error(string message, string title = "Fatal error!. ")
        {
            ShowAlert(title,message, Form_Toast.enmType.Error);
        }

        public static void Correcto(string message, string title = "Acción correcta!. ")
        {
            ShowAlert(title, message, Form_Toast.enmType.Success);
        }

        public static void Notifiacion(string message, string title = "Hey!... ")
        {
            ShowAlert(title,message, Form_Toast.enmType.Info);
        }

        public static void Denegado(string message, string title = "Acción no autorizada!. ")
        {
            ShowAlert(title, message, Form_Toast.enmType.Warning);
        }

        public static void System(string message,Exception ex, string title = "Se genero un error de Sistema")
        {
            ShowAlert(title, message + "\n "+ex.ToString(), Form_Toast.enmType.System);
        }

        public static void Log(string message, string title = "Acción guardada en log!. ")
        {
            ShowAlert(title, message, Form_Toast.enmType.Warning);
            CreateLog(title, message);
        }

        private static void ShowAlert(string title,string message, Form_Toast.enmType type)
        {
            Task.Run(() =>
            {
                Form_Toast frm = new Form_Toast();
                frm.showAlert(title,message, type);
                Application.Run(frm);
            });
        }

        public static void CreateLog(string title,string message)
        {
            int logOption = int.Parse(ConfigurationManager.AppSettings["WriteFileLog"] ?? "0");
            string logMessage = FormatLogMessage(title,message);

            if (logOption == 1 || logOption == 2)
            {
                WriteToFile(logMessage);
            }

            if (logOption == 0 || logOption == 2)
            {
                WriteToDatabase(logMessage);
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

            string directoryPath =  @""+ConfigurationManager.AppSettings["PathLogLocal"].ToString();
            string fileName = DateTime.Now.ToString("dd_MM_yyyy") + ".log";
            string filePath = Path.Combine(directoryPath, fileName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            File.AppendAllText(filePath, message + Environment.NewLine);
        }

        private static void WriteToDatabase(string message)
        {
            // Simulación de escritura en base de datos
            Log_Modelo log = new Log_Modelo();
            
                log.Fecha = DateTime.Now.ToString("dd-MM-yyyy, HH:mm:ss");
                log.Mensaje = message;
                log.Equipo = Environment.MachineName;
            

            // Aquí se insertaría el log en la base de datos 
        }
    }
}