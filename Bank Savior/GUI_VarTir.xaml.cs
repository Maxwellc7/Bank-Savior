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
     
        public GUI_VarTir()
        {
            InitializeComponent();

            cmbFlujoCaja.Items.Add("1");
            cmbFlujoCaja.Items.Add("2");
            cmbFlujoCaja.Items.Add("3");
            cmbFlujoCaja.Items.Add("4");
            
          
           
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
                        lblErrorInversion.Content = "Introducir un número positivo";
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
                        if (tasaInteres < 0 || tasaInteres > 100)
                        {
                            lblErrorTasa.Content = "Introducir un número de 0 a 100";
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
            if (texto.Trim()==String.Empty)
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
                    if(int.TryParse(texto,out int anio))
                    {
                        if(anio > 0)
                        {
                            lblErrorAnios.Content = "";

                        }
                    }
                    else
                    {
                        lblErrorAnios.Content = "Años no válidos";
                        
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
                //sacar VAR
            }
            catch
            {
                MessageBox.Show("Error. Verifique los datos");
            }
        }

        

       
    }

    
            
}
    
