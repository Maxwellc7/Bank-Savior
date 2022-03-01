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
    /// Lógica de interacción para GUIMenu.xaml
    /// </summary>
    public partial class GUIMenu : Window
    {
        public GUIMenu()
        {
            InitializeComponent();
        }
        private void btnInteresCompuesto_Click(object sender, RoutedEventArgs e)
        {
            //Para ocultar la pagina y enlazar con la otra

            this.Hide();

            GUI_InteresCompuesto VentanaInteresCompuesto = new GUI_InteresCompuesto();

            VentanaInteresCompuesto.Show();
        }

        private void btnPrestamo_Click(object sender, RoutedEventArgs e)
        {
            //Para ocultar la pagina y enlazar con la otra

            this.Hide();

            GUI_Prestamo VentanaPrestamo = new GUI_Prestamo();

            VentanaPrestamo.Show();
        }

        private void btnVAR_TIR_Click(object sender, RoutedEventArgs e)
        {
            //Para ocultar la pagina y enlazar con la otra

            this.Hide();

            GUI_VarTir VentanaVanTir = new GUI_VarTir();

            VentanaVanTir.Show();
        }

        private void btnPuntoEquilibrio_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            GUI_PuntoEquilibrio VentanaPuntoEquilibrio = new GUI_PuntoEquilibrio();

            VentanaPuntoEquilibrio.Show();
        }

        private void BtnCerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();

            MainWindow VentanaLogin = new MainWindow();

            VentanaLogin.Show();
        }

        private void BtnCreadores_Click_1(object sender, RoutedEventArgs e)
        {
            this.Hide();

            GUICreadores VentanaCreadores = new GUICreadores();

            VentanaCreadores.Show();
        }
    }
}
