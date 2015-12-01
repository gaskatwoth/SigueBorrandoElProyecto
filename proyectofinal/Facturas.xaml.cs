using proyectofinal.mibd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            AgregarAlGrid = new List<Servicio>();
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
          
            cbprov.ItemsSource = db.Proveedores.ToList();
            cbprov.DisplayMemberPath = "NombreProveedor";
            cbprov.SelectedValuePath = "IdProveedor";

            cbasist.ItemsSource = db.Asistentes.ToList();
            cbasist.DisplayMemberPath = "Nombre";
            cbasist.SelectedValuePath = "IdAsistente";

            //var registro = from s in db.Servicios
            //               select s;
            cbser.ItemsSource = db.Servicios.ToList();
            cbser.DisplayMemberPath = "IdServicio";
            cbser.SelectedValuePath = "IdServicio";
        }

        private void envfac_Click(object sender, RoutedEventArgs e)
        {
            if (cbprov.SelectedIndex > -1 && cbser.SelectedIndex > -1 && cbasist.SelectedIndex > -1)
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("El monto " + total.Content + "\nEl ID del proveedor que le atendio fue: " + cbprov.SelectedValue, "Gracias por su compra", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }

        private void guardafac_Click(object sender, RoutedEventArgs e)
        {
            if (cbprov.SelectedIndex > -1 && cbser.SelectedIndex > -1 && cbasist.SelectedIndex > -1)
            {
                index db = new index();
                Factura prov = new Factura();

                prov.ServicioIdServicio = (int)cbser.SelectedValue;
                prov.Fecha = DateTime.Now;
                prov.AsistenteIdAsistente = (int)cbasist.SelectedValue;
                prov.ProveedorIdProveedor = (int)cbprov.SelectedValue;

                //actualizaGrid();
                db.Facturas.Add(prov);
                db.SaveChanges();
                MessageBox.Show("Se Guardaron los datos");
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar al menos un opcion en cada campo", "precaucion", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
            
            
        
        }
        }
    }

