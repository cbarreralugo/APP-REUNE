﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace APP_REUNE.Vista.Pages
{
    /// <summary>
    /// Lógica de interacción para ComoFunciona.xaml
    /// </summary>
    public partial class ComoFunciona : Window
    {
        public ComoFunciona()
        {
            InitializeComponent();
        }

        private void btn_Aceptar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}