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
    /// Lógica de interacción para GUI_PuntoEquilibrio.xaml
    /// </summary>
    public partial class GUI_PuntoEquilibrio : Window
    {
        public GUI_PuntoEquilibrio()
        {
            InitializeComponent();
        }

        private void btnMenuPrincipal_Click(object sender, RoutedEventArgs e)
        {

            //Para ocultar la pagina y enlazar con la otra

            this.Hide();

            GUIMenu VentanaMenu = new GUIMenu();

            VentanaMenu.Show();
        }
    }
}
