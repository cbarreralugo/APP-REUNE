namespace APP_REUNE.Vista.Forms
{
    partial class Form_Toast
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lb_Titulo = new System.Windows.Forms.Label();
            this.btn_cerrar = new System.Windows.Forms.Button();
            this.img_estatus = new System.Windows.Forms.PictureBox();
            this.lb_mensaje = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.img_estatus)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_Titulo
            // 
            this.lb_Titulo.AutoSize = true;
            this.lb_Titulo.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Titulo.ForeColor = System.Drawing.Color.White;
            this.lb_Titulo.Location = new System.Drawing.Point(90, 24);
            this.lb_Titulo.Name = "lb_Titulo";
            this.lb_Titulo.Size = new System.Drawing.Size(148, 19);
            this.lb_Titulo.TabIndex = 0;
            this.lb_Titulo.Text = "Titulo del mensaje";
            // 
            // btn_cerrar
            // 
            this.btn_cerrar.FlatAppearance.BorderSize = 0;
            this.btn_cerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cerrar.ForeColor = System.Drawing.Color.White;
            this.btn_cerrar.Image = global::APP_REUNE.Properties.Resources.cerrar;
            this.btn_cerrar.Location = new System.Drawing.Point(436, 12);
            this.btn_cerrar.Name = "btn_cerrar";
            this.btn_cerrar.Size = new System.Drawing.Size(49, 42);
            this.btn_cerrar.TabIndex = 1;
            this.btn_cerrar.UseVisualStyleBackColor = true;
            this.btn_cerrar.Click += new System.EventHandler(this.btn_cerrar_Click);
            // 
            // img_estatus
            // 
            this.img_estatus.Image = global::APP_REUNE.Properties.Resources.correcto1;
            this.img_estatus.Location = new System.Drawing.Point(12, 24);
            this.img_estatus.Name = "img_estatus";
            this.img_estatus.Size = new System.Drawing.Size(32, 32);
            this.img_estatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.img_estatus.TabIndex = 2;
            this.img_estatus.TabStop = false;
            // 
            // lb_mensaje
            // 
            this.lb_mensaje.AutoSize = true;
            this.lb_mensaje.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mensaje.ForeColor = System.Drawing.Color.White;
            this.lb_mensaje.Location = new System.Drawing.Point(89, 49);
            this.lb_mensaje.Name = "lb_mensaje";
            this.lb_mensaje.Size = new System.Drawing.Size(201, 21);
            this.lb_mensaje.TabIndex = 3;
            this.lb_mensaje.Text = "Mensaje de texto basico";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormToast
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(497, 107);
            this.Controls.Add(this.lb_mensaje);
            this.Controls.Add(this.img_estatus);
            this.Controls.Add(this.btn_cerrar);
            this.Controls.Add(this.lb_Titulo);
            this.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormToast";
            this.Text = "FormToast";
            ((System.ComponentModel.ISupportInitialize)(this.img_estatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lb_Titulo;
        private System.Windows.Forms.Button btn_cerrar;
        private System.Windows.Forms.PictureBox img_estatus;
        private System.Windows.Forms.Label lb_mensaje;
        private System.Windows.Forms.Timer timer1;
    }
}