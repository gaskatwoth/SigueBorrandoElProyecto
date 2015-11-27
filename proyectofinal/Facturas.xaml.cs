using proyectofinal.mibd;
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
using System.Windows.Shapes;

namespace proyectofinal
{
    /// <summary>
    /// Interaction logic for Facturas.xaml
    /// </summary>
    public partial class Facturas : Window
    {
        public Facturas()
        {
            InitializeComponent();
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            index db = new index();
            var registros = from s in db.Proveedores
                            select s;

            cbprov.ItemsSource = registros.ToList();
            cbprov.DisplayMemberPath = "NombreProveedor";
            cbprov.SelectedValuePath = "IdProveedor";

            var registro = from s in db.Servicios
                            select s;
            cbser.ItemsSource = registro.ToList();
            cbser.DisplayMemberPath = "NombreServicio";
            cbser.SelectedValuePath = "IdServicio";
        }
    }
}
