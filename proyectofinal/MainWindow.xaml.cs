using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using proyectofinal.mibd;
namespace proyectofinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Proveedor temProv = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            nuevaVentana vta = new nuevaVentana();
            vta.Show();

        }

        private void envioser_Click(object sender, RoutedEventArgs e)
        {
            index db = new index();
            if (db.Proveedores.Count() > 0)
            {


                Servicios vta = new Servicios();
                vta.Show();
            }
            else
            {
                MessageBox.Show("No hay proveedores");
            }
        }

        private void enviarasi_Click(object sender, RoutedEventArgs e)
        {
            
            Asistentes vta = new Asistentes();
            vta.Show();
        }

        private void enviocue_Click(object sender, RoutedEventArgs e)
        {
            Cuentas vta = new Cuentas();
            vta.Show();
        }

        private void enviarfac_Click(object sender, RoutedEventArgs e)
        {
            Facturas vta = new Facturas();
            vta.Show();
        }
    }
}
