using APP_REUNE.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace APP_REUNE.Vista.Forms
{
    public partial class Form_Toast : Form
    {
        public Form_Toast()
        {
            InitializeComponent();
        }

        // Usando métodos estáticos para diferentes tipos de alertas
        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info,
            System,
            Log
        }

        private enmAction action;
        private int x, y;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;
                    this.Left -= 3;
                    if (this.Opacity == 0.0)
                    {
                        this.Close();
                    }
                    break;
            }
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        public void showAlert(string title, string msg, enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            this.TopMost = true; // Asegura que el formulario esté siempre encima

            string fname;
            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                Form_Toast frm = (Form_Toast)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }

            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.img_estatus.Image = Resources.correcto;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Error:
                    this.img_estatus.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.img_estatus.Image = Resources.notificacion;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Warning:
                    this.img_estatus.Image = Resources.accesoDenegado;
                    this.BackColor = Color.DarkOrange;
                    break;
                case enmType.System:
                    this.img_estatus.Image = Resources.errorAPI;
                    this.BackColor = Color.DimGray;
                    break;
                case enmType.Log:
                    this.img_estatus.Image = Resources.errorSistemaLog;
                    this.BackColor = Color.Gray;
                    break;
            }

            this.lb_mensaje.Text = msg;
            this.lb_Titulo.Text = title;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }
    }
}
