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
                

                db.Servicios.Add(ser);
                db.SaveChanges();
            }
            else { MessageBox.Show("Solo letras y numero"); }
        }

        private void bors_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(idse.Text, @"^\d+$"))
            {

                index db = new index();
                int id = int.Parse(idse.Text);
                var ser = db.Servicios.SingleOrDefault(x => x.IdServicio == id);

                if (ser != null)
                {
                    db.Servicios.Remove(ser);
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros en #id "); }
        }

        private void Mods_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(nomser.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(precio.Text, @"^\d+$"))
            {

                index db = new index();
                int id = int.Parse(idse.Text);
                var ser = db.Servicios.SingleOrDefault(x => x.IdServicio == id);

                if (ser != null)
                {
                    ser.NombreServicio = nomser.Text;
                    ser.Precio = int.Parse(precio.Text);
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros en #id "); }
        }

        private void cons_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(idse.Text, @"^\d+$"))
            {
                index db = new index();
                int id = int.Parse(idse.Text);
                var registros = from s in db.Servicios
                                where s.IdServicio == id
                                select new
                                {
                                    s.IdServicio,
                                    s.NombreServicio,
                                    s.Precio,
                                };
                dbser.ItemsSource = registros.ToList();
            }
            else { MessageBox.Show("Solo numeros"); }
        }
    }
}
