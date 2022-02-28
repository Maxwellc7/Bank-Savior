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
            txtCapitalPrestamos.Text = "";
            txtInteres.Text = "";
            txtTiempoAños.Text = "";
            lblResultadoNumeroCoutas.Content = "Numero de Cuotas: XXX";
            lblResultadoCoutaMensual.Content = "Couta Mensual: XXX";
            lblResultadoInteresyTotal.Content = "Interes: XXX Total: XXXX";
            lblErrorCapitalP.Content = "";
            lblErrorInteres.Content = "";
            lblErrorDuracion.Content = "";


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

        private void txtCapitalInicial_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtCapitalPrestamos.Text.Trim() == string.Empty)
            {
                lblErrorCapitalP.Content = "Campo obligatorio";
            }
            else
            {
                if (double.TryParse(txtCapitalPrestamos.Text, out double capital))
                {
                    if (capital < 0)
                    {
                        lblErrorCapitalP.Content = "Número no válido";
                    }
                    else
                    {
                        lblErrorCapitalP.Content = "";
                    }

                }
                else
                {
                    lblErrorCapitalP.Content = "Número no válido";
                }

            }
        }

        private void txtTiempoAños_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtTiempoAños.Text.Trim() == string.Empty)
            {
                lblErrorDuracion.Content = "Campo obligatorio";
            }
            else
            {
                if (int.TryParse(txtTiempoAños.Text, out int tiempo))
                {
                    if (tiempo < 0)
                    {
                        lblErrorDuracion.Content = "Número no válido";
                    }
                    else
                    {
                        lblErrorDuracion.Content = "";
                    }

                }
                else
                {
                    lblErrorDuracion.Content = "Número no válido";
                }

            }
        }

        private void txtInteres_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtInteres.Text.Trim() == string.Empty)
            {
                lblErrorInteres.Content = "Campo obligatorio";
            }
            else
            {
                if (double.TryParse(txtInteres.Text, out double interes))
                {
                    if (interes < 0)
                    {
                        lblErrorInteres.Content = "Número no válido";
                    }
                    else
                    {
                        lblErrorInteres.Content = "";
                    }

                }
                else
                {
                    lblErrorInteres.Content = "Número no válido";
                }

            }
        }
    }
}
