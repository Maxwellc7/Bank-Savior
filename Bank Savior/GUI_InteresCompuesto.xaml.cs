using System;
using System.Collections.Generic;
using System.Linq;
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
        struct InteresCompuesto
        {
            public double capital;
            public double años;
            public double tasa;
            public int frecuencia;


        }
        public GUI_InteresCompuesto()
        {
            InitializeComponent();

            cmbFrecuenciaCapitalizacion.Items.Add("Anualmente");
            
            cmbFrecuenciaCapitalizacion.Items.Add("Semestralmente");
            
            cmbFrecuenciaCapitalizacion.Items.Add("Trimestral");

            cmbFrecuenciaCapitalizacion.Items.Add("Mensualmente");

            cmbFrecuenciaCapitalizacion.Items.Add("Diariamente");

        }

        public void limpiarDatos()
        {

            txtCapitalInicial.Text = "";
            txtTasaInteres.Text = "";
            txtTiempoAños.Text = "";

            cmbFrecuenciaCapitalizacion.Text = "";
            lblResultado.Content = "En un X años tendrá $XXXXXX";

            lblErrorCapital.Content = "";
            lblErrorTasa.Content = "";
            lblErrorTiempo.Content = "";

        }

        private void btnMenuPrincipal_Click(object sender, RoutedEventArgs e)
        {

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
            if (txtCapitalInicial.Text.Trim() != string.Empty && txtCapitalInicial.Text.All(Char.IsNumber))
            {

                lblErrorCapital.Content = "";

            }
            else
            {
                if (txtCapitalInicial.Text.Trim() == string.Empty)
                {
                    lblErrorCapital.Content = "Campo obligatorio";
                }
                else
                {
                    if (double.TryParse(txtCapitalInicial.Text, out double capitalInicial))
                    {
                        if (capitalInicial < 0)
                        {
                            lblErrorCapital.Content = "Número no válido";
                        }

                    }
                    else
                    {
                        lblErrorCapital.Content = "Número no válido";
                    }

                }

            }
        }

        private void txtTiempoAños_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtTiempoAños.Text.Trim() == string.Empty)
            {
                lblErrorTiempo.Content = "Campo obligatorio";
            }
            else
            {
                if (int.TryParse(txtTiempoAños.Text, out int tiempo))
                {
                    if (tiempo < 0)
                    {
                        lblErrorTiempo.Content = "Número no válido";
                    }
                    else
                    {
                        lblErrorTiempo.Content = "";
                    }

                }
                else
                {
                    lblErrorTiempo.Content = "Número no válido";
                }

            }
        }

        private void txtTasaInteres_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtTasaInteres.Text.Trim() == string.Empty)
            {
                lblErrorTasa.Content = "Campo obligatorio";
            }
            else
            {
                if (double.TryParse(txtTasaInteres.Text, out double tasaInteres))
                {
                    if (tasaInteres < 0)
                    {
                        lblErrorTasa.Content = "Número no válido";
                    }
                    else
                    {
                        lblErrorTasa.Content = "";
                    }

                }
                else
                {
                    lblErrorTasa.Content = "Número no válido";
                }

            }
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFrecuenciaCapitalizacion.SelectedIndex == -1)
            {
                MessageBox.Show("Error. Seleccione la frecuencia de capitalización");
            }
            else
            {
                try
                {

                    double capitalInicial = double.Parse(txtCapitalInicial.Text);
                    int tiempo = int.Parse(txtTiempoAños.Text);
                    double tasaInteres = double.Parse(txtTasaInteres.Text);
                    int frecuencia = cmbFrecuenciaCapitalizacion.SelectedIndex;

                    if (capitalInicial < 0 || tiempo < 0 || tasaInteres < 0)
                    {
                        MessageBox.Show("Error. Verifique los datos");
                    }
                    else
                    {



                        if (frecuencia != -1)
                        {
                            InteresCompuesto cliente = new InteresCompuesto();
                            cliente.capital = capitalInicial;
                            cliente.tasa = tasaInteres;
                            cliente.años = tiempo;
                            cliente.tasa = tasaInteres;

                            switch (frecuencia)
                            {
                                case 0:
                                    calcularInteres(cliente, 1);
                                    break;
                                case 1:
                                    calcularInteres(cliente, 2);
                                    break;
                                case 2:
                                    calcularInteres(cliente, 4);
                                    break;
                                case 3:
                                    calcularInteres(cliente, 12);
                                    break;
                                case 4:
                                    calcularInteres(cliente, 365);
                                    break;

                            }

                        }

                    }
                }

                catch
                {
                    MessageBox.Show("Error. Verifique los datos");

                }
            }
        }
        

        private void calcularInteres(InteresCompuesto cliente, int frecuencia)
        {
            double factor = (1 + (((cliente.tasa) / 100) / frecuencia));
            double capitalF = (cliente.capital) * Math.Pow(factor, (cliente.años * frecuencia));

            lblResultado.Content = "En " + cliente.años + " años tendrá $ " + Math.Round(capitalF,2);
        }

       

    }
        
}

