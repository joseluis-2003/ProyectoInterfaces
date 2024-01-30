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
using Proyecto2TrimestreInterfaces.DB;

namespace Proyecto2TrimestreInterfaces
{
    /// <summary>
    /// Lógica de interacción para PorductsPage.xaml
    /// </summary>
    public partial class PorductsPage : Page
    {
        public PorductsPage()
        {
            InitializeComponent();
            RellenarComboBox();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RellenarComboBox()
        {
            String[] categorias = Db.ObtenerCategorias();

            // Limpiar el ComboBox antes de agregar nuevos elementos.
            comboBox.Items.Clear();

            // Verificar si hay elementos para agregar.
            if (categorias != null && categorias.Length > 0)
            {
                // Iterar a través del array y agregar cada elemento al ComboBox.
                foreach (string elemento in categorias)
                {
                    comboBox.Items.Add(elemento);
                }

                // Opcional: Seleccionar el primer elemento por defecto.
                comboBox.SelectedIndex = 0;
            }
            else
            {
                // Opcional: Mostrar un mensaje si no hay elementos.
                MessageBox.Show("No hay elementos para mostrar en el ComboBox.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ListView.Items.Clear();
            String tabla = (String)comboBox.SelectedItem;
            String[] productos = Db.ObtenerDatos(tabla);

            if (productos != null && productos.Length > 0)
            {
                // Iterar a través del array y agregar cada elemento al ComboBox.
                foreach (string elemento in productos)
                {
                    ListView.Items.Add(elemento);
                }
            }
            else
            {
                // Opcional: Mostrar un mensaje si no hay elementos.
                MessageBox.Show("No hay elementos para mostrar en el ComboBox.", "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
