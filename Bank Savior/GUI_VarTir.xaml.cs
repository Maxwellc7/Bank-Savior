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

        public void limpiarDatos() {

            txtInversionInicial.Text = "";
            txtTasaInteres.Text = "";
            txtaño1.Text = "";
            txtaño2.Text = "";
            txtaño3.Text = "";
            txtaño4.Text = "";
            cmbFlujoCaja.Text = "";
            lblResultado.Content = "VAR: $XXX  TIR: XX%";

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
    }
}
