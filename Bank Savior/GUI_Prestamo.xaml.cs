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

        public struct prestamo {

            public double capital;
            public int duracionPrestamo;
            public double interes;
            public double valorFinal;

        }

        public prestamo valoresPrestamo;

        public void limpiarDatos()
        {
            txtCapitalPrestamos.Text = "";
            txtInteres.Text = "";
            txtTiempoMeses.Text = "";
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
            if (txtTiempoMeses.Text.Trim() == string.Empty)
            {
                lblErrorDuracion.Content = "Campo obligatorio";
                validTxtTiempoMeses = false;
            }
            else
            {
                if (int.TryParse(txtTiempoMeses.Text, out int tiempo))
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
                valoresPrestamo.duracionPrestamo = int.Parse(txtTiempoMeses.Text);
                valoresPrestamo.interes = double.Parse(txtInteres.Text);
                valoresPrestamo.valorFinal = ((valoresPrestamo.interes / 100) * valoresPrestamo.capital) / (1 - Math.Pow((1 + (valoresPrestamo.interes / 100)), (valoresPrestamo.duracionPrestamo * -1)));
                lblResultadoCoutaMensual.Content = "Couta Mensual: " + string.Format("{0:0.##}", (valoresPrestamo.valorFinal / valoresPrestamo.duracionPrestamo));
                lblResultadoNumeroCoutas.Content = "Numero de Cuotas: " + (valoresPrestamo.duracionPrestamo);
                lblResultadoInteresyTotal.Content = "Interes: " + string.Format("{0:0.##}", valoresPrestamo.interes) + " Total: " + string.Format("{0:0.##}", valoresPrestamo.valorFinal);
            }
        }

        private void btnCalcular_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {

                prestamo cliente=new prestamo();

                cliente.capital = int.Parse(txtCapitalPrestamos.Text);
                cliente.duracionPrestamo = (int.Parse(txtTiempoAños.Text)*12);
                cliente.interes = double.Parse(txtInteres.Text);

                double tasaMensual = (Math.Pow((1 + (cliente.interes/100)), (1 / 12)) - 1);

                double pagoMensual;
                double interes;
                double total;

                pagoMensual = (tasaMensual * cliente.capital) / (1 - (Math.Pow((1 + cliente.capital), - cliente.duracionPrestamo)));

                total = (pagoMensual * cliente.duracionPrestamo);
                interes = cliente.capital - total;

                

                lblResultadoNumeroCoutas.Content = "Numero de cuotas: " + (cliente.duracionPrestamo);
                lblResultadoCoutaMensual.Content = "Cuota mensual: " + Math.Round(pagoMensual,2);
                lblResultadoInteresyTotal.Content = "Interes: " + Math.Round(interes, 2) + " Total: "+Math.Round(total,2);





            }
            catch
            {

            }
        }
    }
}
