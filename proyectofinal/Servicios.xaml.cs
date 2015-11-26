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
    /// Interaction logic for Servicios.xaml
    /// </summary>
    public partial class Servicios : Window
    {
        public Servicios()
        {
            InitializeComponent();
        }

        private void envs_Click(object sender, RoutedEventArgs e)
        {
            //enviar
            if (Regex.IsMatch(nomser.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(precio.Text, @"^\d+$"))
            {
                index db = new index();
                Servicio ser = new Servicio();
                ser.NombreServicio = nomser.Text;
                ser.Precio = int.Parse(precio.Text);
                ser.ProveedorIdProveedor = int.Parse(proveID.SelectedValue.ToString());

                db.Servicios.Add(ser);
                db.SaveChanges();

                //var registros = from s in db.Servicios
                //                select s;
                //dbser.ItemsSource = registros.ToList();
            }
               

            else { MessageBox.Show("Solo letras y numero"); }
            nomser.Clear();
            precio.Clear();
            
            MessageBox.Show("Se guardaron los datos con exito");
        }

        private void bors_Click(object sender, RoutedEventArgs e)
        {
            //borrar
            if (Regex.IsMatch(idse.Text, @"^\d+$"))
            {

                index db = new index();
                int id = int.Parse(idse.Text);
                var ser = db.Servicios.SingleOrDefault(x => x.IdServicio == id);

                if (ser != null)
                {
                    db.Servicios.Remove(ser);
                    db.SaveChanges();
                    idse.Clear();

                }
            }
            else { MessageBox.Show("Solo Numeros en #id "); }
        }

        private void Mods_Click(object sender, RoutedEventArgs e)
        {//modificar
            if (Regex.IsMatch(nomser.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(precio.Text, @"^\d+$"))
            {

                index db = new index();
                int id = int.Parse(idse.Text);
                var ser = db.Servicios.SingleOrDefault(x => x.IdServicio == id);

                if (ser != null)
                {
                    ser.NombreServicio = nomser.Text;
                    ser.Precio = int.Parse(precio.Text);
                    ser.ProveedorIdProveedor = int.Parse(proveID.SelectedValue.ToString());
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros en #id "); }
            nomser.Clear();
            precio.Clear();
        }

        private void cons_Click(object sender, RoutedEventArgs e)
        {//consultar
            //if (Regex.IsMatch(idse.Text, @"^\d+$"))
            //{
                index db = new index();
                //int id = int.Parse(idse.Text);
                var registros = from s in db.Servicios
                                select s;
                                //where s.IdServicio == id
                                //select new
                                //{
                                //    s.IdServicio,
                                //    s.NombreServicio,
                                //    s.Precio,
                                //    s.ProveedorIdProveedor,
                                //};
                dbser.ItemsSource = registros.ToList();
            //}
            //else { MessageBox.Show("Solo numeros"); }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            index db = new index();
            var registros = from s in db.Proveedores
                            select s;


            proveID.ItemsSource=registros.ToList();
            proveID.DisplayMemberPath="NombreProveedor";
            proveID.SelectedValuePath="IdProveedor";

        }
    }
}
