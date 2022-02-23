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
    /// Lógica de interacción para GUI_Prestamo.xaml
    /// </summary>
    public partial class GUI_Prestamo : Window
    {
        public GUI_Prestamo()
        {
            InitializeComponent();
        }

        public struct prestamo {

            int capital;
            int duracionPrestamo;
            int interes;


        }

        public void limpiarDatos()
        {
            txtCapitalInicial.Text = "";
            txtTasaInteres.Text = "";
            txtTiempoAños.Text = "";
            lblResultadoNumeroCoutas.Content = "Numero de Cuotas: XXX";
            lblResultadoCoutaMensual.Content = "Couta Mensual: XXX";
            lblResultadoInteresyTotal.Content = "Interes: XXX Total: XXXX";
            
        }

        private void btnMenuPrincipal_Click(object sender, RoutedEventArgs e)
        {
            //Para ocultar la pagina y enlazar con la otra

            this.Hide();

            GUIMenu VentanaMenu = new GUIMenu();

            VentanaMenu.Show();
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {

            

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

            limpiarDatos();
        
        }
    }
}
