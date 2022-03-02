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

        public bool validTxtCostosFijos = false;
        public bool validTxtCostosVariables = false;
        public bool validTxtPrecioVenta = false;

        public struct puntoEquilibrio
        {

            public double costosFijos;
            public double costosVariables;
            public double precioDeVenta;
            public double valorFinal;

        }

        public puntoEquilibrio valoresPuntoEquilibrio;

        public void limpiarDatos()
        {
            txtCostosFijos.Text = "";
            txtCostosVariables.Text = "";
            txtPrecioVenta.Text = "";

            lblResultado.Content = "EL PEQ ES IGUAL A XXXXXX";

            lblCostosFijosWarning.Content = "";
            lblCostosPrecioVentaWarning.Content = "";
            lblCostosVariablesWarning.Content = "";



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

            if (validTxtCostosFijos && validTxtCostosVariables && validTxtPrecioVenta)
            {
                
                valoresPuntoEquilibrio.costosFijos = double.Parse(txtCostosFijos.Text);
                valoresPuntoEquilibrio.costosVariables = (double.Parse(txtCostosVariables.Text));
                valoresPuntoEquilibrio.precioDeVenta = double.Parse(txtPrecioVenta.Text);

                valoresPuntoEquilibrio.valorFinal = valoresPuntoEquilibrio.costosFijos / (1 - (valoresPuntoEquilibrio.costosVariables / valoresPuntoEquilibrio.precioDeVenta));
                lblResultado.Content = "EL PEQ ES IGUAL A "+ string.Format("{0:0.##}", valoresPuntoEquilibrio.valorFinal);
            }
            else
            {
                MessageBox.Show("Error. Verifique los datos");
            }

        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            limpiarDatos();
        }

        private void txtCostosFijos_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCostosFijos.Text.Trim() == string.Empty)
            {
                lblCostosFijosWarning.Content = "Campo obligatorio";
                validTxtCostosFijos = false;
            }
            else
            {
                if (double.TryParse(txtCostosFijos.Text, out double capital))
                {
                    if (capital < 0)
                    {
                        lblCostosFijosWarning.Content = "Número no válido";
                        validTxtCostosFijos = false;
                    }
                    else
                    {
                        lblCostosFijosWarning.Content = "";
                        validTxtCostosFijos = true;
                    }

                }
                else
                {
                    lblCostosFijosWarning.Content = "Número no válido";
                    validTxtCostosFijos = false;
                }

            }
        }

        private void txtCostosVariables_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtCostosVariables.Text.Trim() == string.Empty)
            {
                lblCostosVariablesWarning.Content = "Campo obligatorio";
                validTxtCostosVariables = false;
            }
            else
            {
                if (double.TryParse(txtCostosVariables.Text, out double capital))
                {
                    if (capital < 0)
                    {
                        lblCostosVariablesWarning.Content = "Número no válido";
                        validTxtCostosVariables = false;
                    }
                    else
                    {
                        lblCostosVariablesWarning.Content = "";
                        validTxtCostosVariables = true;
                    }

                }
                else
                {
                    lblCostosVariablesWarning.Content = "Número no válido";
                    validTxtCostosVariables = false;
                }

            }
        }

        private void txtPrecioVenta_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPrecioVenta.Text.Trim() == string.Empty)
            {
                lblCostosPrecioVentaWarning.Content = "Campo obligatorio";
                validTxtPrecioVenta = false;

            }
            else
            {
                if (double.TryParse(txtPrecioVenta.Text, out double capital))
                {
                    if (capital < 0)
                    {
                        lblCostosPrecioVentaWarning.Content = "Número no válido";
                        validTxtPrecioVenta = false;
                    }
                    else
                    {
                        lblCostosPrecioVentaWarning.Content = "";
                        validTxtPrecioVenta = true;
                    }

                }
                else
                {
                    lblCostosPrecioVentaWarning.Content = "Número no válido";
                    validTxtPrecioVenta = false;
                }

            }
        }
    }
}
