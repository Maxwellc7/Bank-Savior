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

        public bool validTxtCapitalPrestamos = false;
        public bool validTxtTiempoMeses = false;
        public bool validTxtInteres = false;
        public double valorPrestamoFinal = 0;
        public double interesTotal = 0;
        public struct prestamo {

            public double capital;
            public int duracionPrestamo;
            public double interes;
            public double valorFinal;
            public double interesMensual;
            public double cuotas;

        }

        public prestamo valoresPrestamo;

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

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {

            limpiarDatos();
        
        }

        private void txtCapitalInicial_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(txtCapitalPrestamos.Text.Trim() == string.Empty)
            {
                lblErrorCapitalP.Content = "Campo obligatorio";
                validTxtCapitalPrestamos = false;
            }
            else
            {
                if (double.TryParse(txtCapitalPrestamos.Text, out double capital))
                {
                    if (capital < 0)
                    {
                        lblErrorCapitalP.Content = "Número no válido";
                        validTxtCapitalPrestamos = false;
                    }
                    else
                    {
                        lblErrorCapitalP.Content = "";
                        validTxtCapitalPrestamos = true;
                    }

                }
                else
                {
                    lblErrorCapitalP.Content = "Número no válido";
                    validTxtCapitalPrestamos = false;
                }

            }
        }

        private void txtTiempoMeses_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtTiempoAños.Text.Trim() == string.Empty)
            {
                lblErrorDuracion.Content = "Campo obligatorio";
                validTxtTiempoMeses = false;
            }
            else
            {
                if (int.TryParse(txtTiempoAños.Text, out int tiempo))
                {
                    if (tiempo < 0)
                    {
                        lblErrorDuracion.Content = "Número no válido";
                        validTxtTiempoMeses = false;
                    }
                    else
                    {
                        lblErrorDuracion.Content = "";
                        validTxtTiempoMeses = true;
                    }

                }
                else
                {
                    lblErrorDuracion.Content = "Número no válido";
                    validTxtTiempoMeses = false;
                }

            }
        }

        private void txtInteres_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtInteres.Text.Trim() == string.Empty)
            {
                lblErrorInteres.Content = "Campo obligatorio";
                validTxtInteres = false;
            }
            else
            {
                if (double.TryParse(txtInteres.Text, out double interes))
                {
                    if (interes < 0)
                    {
                        lblErrorInteres.Content = "Número no válido";
                        validTxtInteres = false;
                    }
                    else
                    {
                        lblErrorInteres.Content = "";
                        validTxtInteres = true;
                    }

                }
                else
                {
                    lblErrorInteres.Content = "Número no válido";
                    validTxtInteres = false;
                }

            }
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (validTxtInteres && validTxtCapitalPrestamos && validTxtTiempoMeses)
            {
                valoresPrestamo.capital = double.Parse(txtCapitalPrestamos.Text);
                valoresPrestamo.duracionPrestamo = int.Parse(txtTiempoAños.Text);
                valoresPrestamo.interes = double.Parse(txtInteres.Text);

                valoresPrestamo.interesMensual = (valoresPrestamo.interes/100/12);
                valoresPrestamo.cuotas = ((valoresPrestamo.interesMensual)*valoresPrestamo.capital)/(1- Math.Pow((1+ (valoresPrestamo.interesMensual)), (valoresPrestamo.duracionPrestamo*-1)));
                valoresPrestamo.valorFinal = valoresPrestamo.cuotas * valoresPrestamo.duracionPrestamo;

                lblResultadoCoutaMensual.Content = "Couta Mensual: " + Math.Round(valoresPrestamo.cuotas,2);
                lblResultadoNumeroCoutas.Content = "Numero de Cuotas: " + (valoresPrestamo.duracionPrestamo);
                lblResultadoInteresyTotal.Content = "Interes: " + Math.Round((valoresPrestamo.valorFinal - valoresPrestamo.capital),2) + " Total: " + Math.Round (valoresPrestamo.valorFinal,2);
            }
            else
            {
                MessageBox.Show("Error. Verifique los datos");
            }
        }

    }
}
