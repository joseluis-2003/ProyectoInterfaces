using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Proyecto2TrimestreInterfaces.DB
{
    public class Db
    {

        static MySqlConnection conexion =
              new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=root;database=northwind");

        public static Boolean login(String usuario, String contrasena)
        {

            Boolean existe = false;
            try
            {
                conexion.Open();
                string consultaUser = "SELECT * FROM users WHERE User = '" + usuario + "' and Password = '" + contrasena +
                                      "'";

                MySqlCommand cmd = new MySqlCommand(consultaUser, conexion);
                // Ejecuto la consulta SQL anterior
                MySqlDataReader lector = cmd.ExecuteReader();

                if (lector.Read())
                {
                    existe = true;
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return existe;
        }

        public static String[] ObtenerCategorias()
        {
            // Crear una lista para almacenar los nombres de las categorías.
            List<string> categorias = new List<string>();

            // Establecer la consulta SQL.
            string query = "SELECT CategoryName FROM Categories";

            try
            {

                // Crear un comando SQL con la consulta y la conexión.
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    // Ejecutar la consulta y obtener un lector de datos.
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas en el resultado.
                        if (reader.HasRows)
                        {
                            // Iterar a través de las filas y obtener los nombres de las categorías.
                            while (reader.Read())
                            {
                                // Agregar el nombre de la categoría a la lista.
                                string categoryName = reader["CategoryName"].ToString();
                                categorias.Add(categoryName);
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la operación de la base de datos.
                MessageBox.Show($"Error al obtener categorías: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string[] arrayCategorias = categorias.ToArray();

            return arrayCategorias;
        }


        public static String[] ObtenerDatos(String categoria)
        {
            // Crear una lista para almacenar los nombres de las categorías.
            List<string> productos = new List<string>();

            // Establecer la consulta SQL.
            string query = "SELECT p.ProductName " +
                "FROM products p " +
                "JOIN categories c ON p.CategoryID = c.CategoryID " +
                "WHERE c.CategoryName = '" + categoria+"';";

            try
            {

                // Crear un comando SQL con la consulta y la conexión.
                using (MySqlCommand command = new MySqlCommand(query, conexion))
                {
                    // Ejecutar la consulta y obtener un lector de datos.
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Verificar si hay filas en el resultado.
                        if (reader.HasRows)
                        {
                            // Iterar a través de las filas y obtener los nombres de las categorías.
                            while (reader.Read())
                            {
                                // Agregar el nombre de la categoría a la lista.
                                string ProductName = reader["ProductName"].ToString();
                                productos.Add(ProductName);
                            }
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la operación de la base de datos.
                MessageBox.Show($"Error al obtener categorías: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            string[] arrayProductos = productos.ToArray();

            return arrayProductos;
        }
    }
}
