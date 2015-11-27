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
    /// Interaction logic for nuevaVentana.xaml
    /// </summary>
    public partial class nuevaVentana : Window
    {
        public nuevaVentana()
        {
            InitializeComponent();
        }

        private void enviarbd_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(txtnom.Text, @"^[a-zA-Z\s]+$") && Regex.IsMatch(txtdir.Text, @"^[a-zA-Z\s]+$") && Regex.IsMatch(gg.Text, @"^[a-zA-Z\s]+$"))
            {
            index db = new index();
            Proveedor prov = new Proveedor();
            prov.NombreProveedor=txtnom.Text;
            prov.Direccion = txtdir.Text;
            prov.Giro = gg.Text;


            db.Proveedores.Add(prov);
            db.SaveChanges();
            //var registros = from s in db.Proveedores
            //                select s;
            //dbgrid.ItemsSource = registros.ToList();
        }
             else {MessageBox.Show("Solo letras y numero");}
            txtnom.Clear();
            txtdir.Clear();
          

            MessageBox.Show("Se Guardaron los datos");
        
        }

        private void borrarP_Click(object sender, RoutedEventArgs e)
        {//Borrar

            
            if (Regex.IsMatch(Actualizar.Text, @"^\d+$"))
            {

                index db = new index();
                int id = int.Parse(Actualizar.Text);
                var prov = db.Proveedores.SingleOrDefault(x => x.IdProveedor == id);

                if (prov != null)
                {
                    db.Proveedores.Remove(prov);
                    Actualizar.Clear();
                    db.SaveChanges();
                    MessageBox.Show("Se borraron los datos");
                }
            }
            else { MessageBox.Show("Solo Numeros en #id "); }
          
        }

        private void ModP_Click(object sender, RoutedEventArgs e)
        {//actualizar
            if (Regex.IsMatch(txtnom.Text, @"^[a-zA-Z\s]+$") && Regex.IsMatch(txtdir.Text, @"^[a-zA-Z\s]+$") && Regex.IsMatch(gg.Text, @"^[a-zA-Z]+$"))
            {
                index db = new index();
                int id = int.Parse(Actualizar.Text);
                var prov = db.Proveedores.SingleOrDefault(x => x.IdProveedor == id);
               
                if (prov != null)
                {
                    prov.NombreProveedor = txtnom.Text;
                    prov.Direccion = txtdir.Text;
                    prov.Giro = gg.Text;
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo letras y numeros"); }
            txtnom.Clear();
            txtdir.Clear();
            Actualizar.Clear();
            MessageBox.Show("Modificacion con exito");
        }

        private void conp_Click(object sender, RoutedEventArgs e)
        {
            //if (Regex.IsMatch(Actualizar.Text, @"^\d+$"))
            //{
                index db = new index();
                //int id = int.Parse(Actualizar.Text);
                var registros = from s in db.Proveedores
                                select
                                s;

                                //where s.IdProveedor == id
                                //select new
                                //{
                                //    s.NombreProveedor,
                                //    s.Direccion,
                                //    s.Giro
                                //};
                dbgrid.ItemsSource = registros.ToList();
            //}
            //else { MessageBox.Show("Solo numeros"); }
        }


        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            //index db = new index();
            //var registros = from s in db.Proveedores
            //                select s;

            //gg.ItemsSource = registros.ToList();
            //gg.DisplayMemberPath = "Giro";
            //gg.SelectedValuePath = "Giro";

        }
    }
  }
    
