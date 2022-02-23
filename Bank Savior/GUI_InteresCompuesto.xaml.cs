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
    /// Lógica de interacción para GUI_InteresCompuesto.xaml
    /// </summary>
    public partial class GUI_InteresCompuesto : Window
    {
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
    }
}
