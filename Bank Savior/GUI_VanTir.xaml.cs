using Microsoft.VisualBasic;
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
    /// Lógica de interacción para GUI_VarTir.xaml
    /// </summary>
    
    public partial class GUI_VarTir : Window
    {
        struct VanTir
        {
            public double inversion;
            public double tasaDeInteres;
            public años FlujoDeCaja;
            
        }
        struct años
        {
            public double año1;
            public double año2;
            public double año3;
            public double año4;
        }
     
        public GUI_VarTir()
        {
            InitializeComponent();

            cmbFlujoCaja.Items.Add("1");
            cmbFlujoCaja.Items.Add("2");
            cmbFlujoCaja.Items.Add("3");
            cmbFlujoCaja.Items.Add("4");

            txtaño1.IsEnabled = false;
            txtaño2.IsEnabled = false;
            txtaño3.IsEnabled = false;
            txtaño4.IsEnabled = false;



        }

        public void limpiarDatos()
        {

            txtInversionInicial.Text = "";
            txtTasaInteres.Text = "";
            txtaño1.Text = "";
            txtaño2.Text = "";
            txtaño3.Text = "";
            txtaño4.Text = "";
            cmbFlujoCaja.Text = "";
            lblResultado.Content = "VAR: $XXX  TIR: XX%";
            lblErrorAnios.Content = "";
            lblErrorInversion.Content = "";
            lblErrorTasa.Content = "";
            txtaño1.IsEnabled = false;
            txtaño2.IsEnabled = false;
            txtaño3.IsEnabled = false;
            txtaño4.IsEnabled = false;
            
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

        private void txtInversionInicial_TextChanged(object sender, TextChangedEventArgs e)
        {
            
         if (txtInversionInicial.Text.Trim() != string.Empty&&txtInversionInicial.Text.All(Char.IsNumber))
         {
            
            lblErrorInversion.Content = "";
            
            
         }
            else
            {
                if (txtInversionInicial.Text.Trim() ==string.Empty)
                {
                    lblErrorInversion.Content = "Campo obligatorio";
                }
                else
                {
                    if(double.TryParse(txtInversionInicial.Text,out double inversionInicial))
                    {
                        if (inversionInicial < 0)
                        {
                        lblErrorInversion.Content = "Número no válido";
                        }
                        
                    }
                    else
                    {
                        lblErrorInversion.Content = "Número no válido";
                    }
                    
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
                        if(tasaInteres < 0)
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
        private void lblAnios(string texto)
        {
            if (texto.Trim() == String.Empty)
            {
                lblErrorAnios.Content = "Campos obligatorios";

            }
            else
            {
                if (texto.All(Char.IsLetter))
                {
                    lblErrorAnios.Content = "Años no válidos";

                }
                else
                {
                    if (double.TryParse(texto, out double anio))
                    {
                        lblErrorAnios.Content = "";

                    }

                }
            }
        }

        private void txtaño1_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblAnios(txtaño1.Text);
        }

        private void txtaño3_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblAnios(txtaño3.Text);
        }

        private void txtaño2_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblAnios(txtaño2.Text);
        }

        private void txtaño4_TextChanged(object sender, TextChangedEventArgs e)
        {
            lblAnios(txtaño4.Text);
        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            try
            {
           
            double inversionInicial = double.Parse(txtInversionInicial.Text);
            double tasaInteres = double.Parse(txtTasaInteres.Text);
            int nAños = cmbFlujoCaja.SelectedIndex;
            validaciones();
            
                if (nAños != -1)
                {
  
                    VanTir usuario=new VanTir();
                 
                    usuario.inversion = inversionInicial; 
                    usuario.tasaDeInteres= tasaInteres;

                    if (inversionInicial < 0||tasaInteres<0)
                    {
                        MessageBox.Show("Error. Verifique los datos");
                    }
                    else
                    {
                        switch (nAños)
                        {
                            case 0:
                                usuario.FlujoDeCaja.año1 = double.Parse(txtaño1.Text); ;
                                usuario.FlujoDeCaja.año2 = 0;
                                usuario.FlujoDeCaja.año3 = 0;
                                usuario.FlujoDeCaja.año4 = 0;

                                break;
                            case 1:
                                usuario.FlujoDeCaja.año1 = double.Parse(txtaño1.Text); ;
                                usuario.FlujoDeCaja.año2 = double.Parse(txtaño2.Text);
                                usuario.FlujoDeCaja.año3 = 0;
                                usuario.FlujoDeCaja.año4 = 0;
                                break;
                            case 2:
                                usuario.FlujoDeCaja.año1 = double.Parse(txtaño1.Text); ;
                                usuario.FlujoDeCaja.año2 = double.Parse(txtaño2.Text);
                                usuario.FlujoDeCaja.año3 = double.Parse(txtaño3.Text);
                                usuario.FlujoDeCaja.año4 = 0;
                                break;
                            case 3:
                                usuario.FlujoDeCaja.año1 = double.Parse(txtaño1.Text); ;
                                usuario.FlujoDeCaja.año2 = double.Parse(txtaño2.Text);
                                usuario.FlujoDeCaja.año3 = double.Parse(txtaño3.Text);
                                usuario.FlujoDeCaja.año4 = double.Parse(txtaño4.Text);
                                break;

                        }

                        CalcularVanTir(usuario);
                            
                        

                        
                    }
 
                }
                
            }
            catch
            {
                MessageBox.Show("Error. Verifique los datos");
            }
        }

        private void cmbFlujoCaja_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbFlujoCaja.SelectedIndex != -1)
            {
                int nAños=cmbFlujoCaja.SelectedIndex;
                if (nAños == 0)          // un año
                {
                    lblaño1.IsEnabled = true;
                    lblaño2.IsEnabled= false;
                    lblIaño3.IsEnabled = false;
                    lblaño4.IsEnabled = false;
                    txtaño1.IsEnabled = true;
                    txtaño2.IsEnabled = false;
                    txtaño3.IsEnabled=false;
                    txtaño4.IsEnabled=false;
                }
                if (nAños == 1)
                {
                    lblaño1.IsEnabled = true;
                    lblaño2.IsEnabled = true;
                    lblIaño3.IsEnabled = false;
                    lblaño4.IsEnabled = false;
                    txtaño1.IsEnabled = true;
                    txtaño2.IsEnabled = true;
                    txtaño3.IsEnabled = false;
                    txtaño4.IsEnabled = false;
                }
                if (nAños == 2)
                {
                    lblaño1.IsEnabled = true;
                    lblaño2.IsEnabled = true;
                    lblIaño3.IsEnabled = true;
                    lblaño4.IsEnabled = false;
                    txtaño1.IsEnabled = true;
                    txtaño2.IsEnabled = true;
                    txtaño3.IsEnabled = true;
                    txtaño4.IsEnabled = false;
                }
                if (nAños == 3)
                {
                    lblaño1.IsEnabled = true;
                    lblaño2.IsEnabled = true;
                    lblIaño3.IsEnabled = true;
                    lblaño4.IsEnabled = true;
                    txtaño1.IsEnabled = true;
                    txtaño2.IsEnabled = true;
                    txtaño3.IsEnabled = true;
                    txtaño4.IsEnabled = true;
                }
            }

        }

        private void validaciones()
        {
            if(cmbFlujoCaja.SelectedIndex == -1)
            {
                MessageBox.Show("Error. Seleccione el flujo de caja");
            }
            
        }

         private void CalcularVanTir(VanTir cliente1)
        {
            //Cálculo del VAN
            double valorFuturo = (1 + (cliente1.tasaDeInteres / 100));
            double primerAño = (cliente1.FlujoDeCaja.año1 / (valorFuturo));
            double segundoAño = (cliente1.FlujoDeCaja.año2 / (Math.Pow(valorFuturo,2)));
            double tercerAño = (cliente1.FlujoDeCaja.año3 / (Math.Pow(valorFuturo, 3)));
            double cuartoAño = (cliente1.FlujoDeCaja.año4 / (Math.Pow(valorFuturo, 4)));

            double totalVar = primerAño + segundoAño + tercerAño + cuartoAño - cliente1.inversion;

            lblResultado.Content = "VAN: $ " + Math.Round(totalVar,2);


            //Cálculo del TIR

            if (cliente1.FlujoDeCaja.año1<0|| cliente1.FlujoDeCaja.año2 < 0|| cliente1.FlujoDeCaja.año2 < 0|| cliente1.FlujoDeCaja.año3 < 0|| cliente1.FlujoDeCaja.año4 < 0)
            {
                lblResultado.Content += "   TIR: -- %";
            }
            else
            {
                double inversionNegativa = (cliente1.inversion * -1);
                double[] años = new double[5] { inversionNegativa, cliente1.FlujoDeCaja.año1, cliente1.FlujoDeCaja.año2, cliente1.FlujoDeCaja.año3, cliente1.FlujoDeCaja.año4 };

                double TIR = Financial.IRR(ref años) * 100;

                lblResultado.Content += "   TIR: " + Math.Round(TIR, 2) + " %";
            }
           
            

            

        }
        
        }
    }

    
            

    
