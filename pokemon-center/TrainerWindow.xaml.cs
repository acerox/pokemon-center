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
//añadimos los import de mysql

using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace pokemon_center
{
    /// <summary>
    /// Lógica de interacción para TrainerWindow.xaml
    /// </summary>
    public partial class TrainerWindow : Window
    {
        private MySqlConnection conexion = new MySqlConnection("Server = 127.0.0.1; Database = pokemon-center; Uid = root; Pwd =; Port = 3306");
        private MySqlCommand comando;
        private DataTable datos = new DataTable();
        private MySqlDataAdapter resultadoAdapter;
        public TrainerWindow()
        {
            InitializeComponent();
            conexion.Open();
            
        }

        private void botonEntrenador_Click(object sender, RoutedEventArgs e)
        {
            //esto es para que no se anden superponiendo los regisros cada vez
            menuTodo.ItemsSource = null;
            menuTodo.Items.Clear();
            menuTodo.Columns.Clear();
            datos.Clear();
            menuTodo.Items.Refresh();

            //string de la consulta
            comando = new MySqlCommand("Select * from nurse", conexion);
            //ejecucion/lectua de esta
            resultadoAdapter = new MySqlDataAdapter(comando);
            //carga de la consulta en forma de tabla (en la variable)
            resultadoAdapter.Fill(datos);
            menuTodo.ItemsSource = datos.DefaultView;
        }

        private void botonPokemon_Click(object sender, RoutedEventArgs e)
        {
            //esto es para que no se anden superponiendo los regisros cada vez
            menuTodo.ItemsSource = null;
            menuTodo.Items.Clear();
            menuTodo.Columns.Clear();
            datos.Clear();
            menuTodo.Items.Refresh();

            //string de la consulta
            comando = new MySqlCommand("Select * from pokemon", conexion);
            //ejecucion/lectua de esta
            resultadoAdapter = new MySqlDataAdapter(comando);
            //carga de la consulta en forma de tabla (en la variable)
            resultadoAdapter.Fill(datos);
            menuTodo.ItemsSource = datos.DefaultView;
        }

        private void botonTienda_Click(object sender, RoutedEventArgs e)
        {
            //esto es para que no se anden superponiendo los regisros cada vez
            menuTodo.ItemsSource = null;
            menuTodo.Items.Clear();
            menuTodo.Columns.Clear();
            datos.Clear();
            menuTodo.Items.Refresh();

            //string de la consulta
            comando = new MySqlCommand("Select * from tienda", conexion);
            //ejecucion/lectua de esta
            resultadoAdapter = new MySqlDataAdapter(comando);
            //carga de la consulta en forma de tabla (en la variable)
            resultadoAdapter.Fill(datos);
            menuTodo.ItemsSource = datos.DefaultView;
        }
    }
}
