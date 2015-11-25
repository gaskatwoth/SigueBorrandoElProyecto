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
    /// Interaction logic for Asistentes.xaml
    /// </summary>
    public partial class Asistentes : Window
    {
        //private string Nombre;
        //private string Apellido;
        //private string Telefono;
        public Asistentes()
        {
            InitializeComponent();
        }

        private void enviarasis_Click(object sender, RoutedEventArgs e)
        {

            if (Regex.IsMatch(noma.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(apela.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(tela.Text, @"^\d+$"))
            {
            index db = new index();
            Asistente Asi = new Asistente();
            Asi.Nombre=noma.Text;
           Asi.Apellido=apela.Text;
            Asi.Telefono=tela.Text;

            //db.Asistentes.Add(asi);
            db.Asistentes.Add(Asi);
            db.SaveChanges();
        }
             else {MessageBox.Show("Solo letras y numero");}

        
        }

        private void Elimi_Click(object sender, RoutedEventArgs e)
        {
            //eliminar
            if (Regex.IsMatch(idasis.Text, @"^\d+$"))
            {

                index db = new index();
                int id = int.Parse(idasis.Text);
                var Asi = db.Asistentes.SingleOrDefault(x => x.IdAsistente == id);

                if (Asi != null)
                {
                    db.Asistentes.Remove(Asi);
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros en #id "); }
        }

        private void modi_Click(object sender, RoutedEventArgs e)
        {//Modificar
            if (Regex.IsMatch(noma.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(apela.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(tela.Text, @"^\d+$"))
            {
                index db = new index();
                int id = int.Parse(idasis.Text);
                var Asi = db.Asistentes.SingleOrDefault(x => x.IdAsistente == id);

                if (Asi != null)
                {
                    Asi.Nombre = noma.Text;
                    Asi.Apellido = apela.Text;
                    Asi.Telefono = tela.Text;
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo letras y numeros"); }
        }

        private void cons_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(idasis.Text, @"^\d+$"))
            {
                index db = new index();
                int id = int.Parse(idasis.Text);
                var registros = from s in db.Asistentes
                                where s.IdAsistente == id
                                select new
                                {
                                    s.IdAsistente,
                                    s.Nombre,
                                    s.Apellido,
                                    s.Telefono
                                };
                dbasi.ItemsSource = registros.ToList();
            }
            else { MessageBox.Show("Solo numeros"); }
        }
    }
}
