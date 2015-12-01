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
        private Servicio tempServicio = null;
        private List<Servicio> AgregarAlGrid;

        public Facturas()
        {
            InitializeComponent();
        }

        private void actualizaGrid()
        {
         
            var registros = from s in AgregarAlGrid
                            select new
                            {
                                s.IdServicio,
                                s.NombreServicio,
                                s.Precio,
                                s.ProveedorIdProveedor,
                                
                            };
            gridfat.ItemsSource = null;
            gridfat.ItemsSource = registros;


            total.Content = string.Format("Total: {0} ", AgregarAlGrid.Sum(x => x.Precio).ToString("C"));
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            index db = new index();
            //var registros = from s in db.Proveedores
            //                select s;

            cbprov.ItemsSource = db.Proveedores.ToList();
            cbprov.DisplayMemberPath = "NombreProveedor";
            cbprov.SelectedValuePath = "IdProveedor";

            //var registro = from s in db.Servicios
            //                select s;
            cbser.ItemsSource = db.Servicios.ToList();
            cbser.DisplayMemberPath = "IdServicio";
            cbser.SelectedValuePath = "IdServicio";
        }

        private void envfac_Click(object sender, RoutedEventArgs e)
        {
            if (cbprov.SelectedIndex > -1 && cbser.SelectedIndex > -1)
            {
                index db = new index();
                
                int id =  int.Parse(cbser.Text);
                Servicio p = db.Servicios.SingleOrDefault(x => x.IdServicio == id);

                if (p != null)
                {
                    tempServicio = p;

                }

                AgregarAlGrid.Add(new Servicio()
                {
                    IdServicio = tempServicio.IdServicio,
                    NombreServicio = tempServicio.NombreServicio,
                    Precio = tempServicio.Precio,
                    ProveedorIdProveedor = tempServicio.ProveedorIdProveedor,
                });

                actualizaGrid();
                tempServicio = null;
             
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar al menos un opcion en cada campo", "precaucion", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }
    }
}
