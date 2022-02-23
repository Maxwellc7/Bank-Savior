using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bank_Savior
{
    /// <summary>
    /// Lógica de interacción para GUI_InteresCompuesto.xaml
    /// </summary>
    public partial class GUI_InteresCompuesto : Window
    {
        public GUI_InteresCompuesto()
        {
            InitializeComponent();
        }

        private void btnMenuPrincipal_Click(object sender, RoutedEventArgs e)
        {

            this.Hide();

            GUIMenu VentanaMenu = new GUIMenu();

            VentanaMenu.Show();

        }
    }
}
