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
    /// Interaction logic for Cuentas.xaml
    /// </summary>
    public partial class Cuentas : Window
    {
        public Cuentas()
        {
            InitializeComponent();
        }

        private void elmc_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(idc.Text, @"^\d+$"))
            {
                //borrar
                index db = new index();
                int id = int.Parse(idc.Text);
                var Cuenta = db.CuentaProverdores.SingleOrDefault(x => x.IdCuenta == id);

                if (Cuenta != null)
                {
                    db.CuentaProverdores.Remove(Cuenta);
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo Numeros en #id "); }
        }

        private void envc_Click(object sender, RoutedEventArgs e)
        {
            //enviar
            if (Regex.IsMatch(usuarios.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(contra.Text, @"^[a-zA-Z]+$") )
            {
                index db = new index();
                CuentaProveedor Cuenta = new CuentaProveedor();
                Cuenta.Usuario = usuarios.Text;
                Cuenta.contrasena = contra.Text;


                db.CuentaProverdores.Add(Cuenta);
                db.SaveChanges();
            }
            else { MessageBox.Show("Solo letras y numero"); }
        }

        private void modc_Click(object sender, RoutedEventArgs e)
        {
            //modificar
            if (Regex.IsMatch(usuarios.Text, @"^[a-zA-Z]+$") && Regex.IsMatch(contra.Text, @"^[a-zA-Z]+$") )
            {
                index db = new index();
                int id = int.Parse(idc.Text);
                var Cuenta = db.CuentaProverdores.SingleOrDefault(x => x.IdCuenta == id);

                if (Cuenta != null)
                {
                    Cuenta.Usuario = usuarios.Text;
                    Cuenta.contrasena = contra.Text;
                    db.SaveChanges();

                }
            }
            else { MessageBox.Show("Solo letras y numeros"); }
        }

        private void conc_Click(object sender, RoutedEventArgs e)
        {
            //consultaporId
            if (Regex.IsMatch(idc.Text, @"^\d+$"))
            {
                index db = new index();
                int id = int.Parse(idc.Text);
                var registros = from s in db.CuentaProverdores
                                where s.IdCuenta == id
                                select new
                                {
                                   s.IdCuenta,
                                   s.Usuario,
                                   s.contrasena,
                                };
                dbcon.ItemsSource = registros.ToList();
            }
            else { MessageBox.Show("Solo numeros"); }
        }
    }
}
