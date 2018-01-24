﻿using System;
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
//añadimos los import de mysql

using System.Data.Odbc;
using MySql.Data.Types;
using MySql.Data.MySqlClient;
using System.Data;



namespace pokemon_center
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            
        // este es el ejemplo que conectara con una bbdd de mysql
        // necesita 5 parametros:
        //Server: la ip o nombre del servidor 
        // Database : nombre de la base de datos 
        //Uid: usuario (OJO: no se puede dejar n blanco)
        //Pwd: clave del usuario si la tuviera
        // Port: default: 3306

        //guarda los parametros de la conexion 
        private string connStr;

        //variable que maneja la conexion
        private MySqlConnection conexion;

        //variable para almacenar la consulta a la bbdd
        private String sentenciaSQL;

        //variable que sirve para crear la conexion
        private static MySqlCommand comando;

        //guarda el resultado de la consulta
        private MySqlDataReader resultado;

        //pone el resultado de la bbdd en esta variable
        private DataTable datos = new DataTable();

        private int contadorFila = 0;
        private int numeroFilas = 0;




        public MainWindow()
        {
            InitializeComponent();
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = pokemon-center; Uid = root; Pwd =; Port = 3306");
            try
            {
                conexion.Open();
                MessageBox.Show("Conexion a la bbdd realizada");

            }
            catch (Exception ex){
                MessageBox.Show("No se pudo conectar a la bbdd" + ex.ToString());
            }
            
        }
        

        private void botonAcceder_Click(object sender, RoutedEventArgs e)
        {

            //  PARA EL NOMBRE DE USUARIO
            comando = new MySqlCommand("select nurse.username, nurse.password from nurse where username ='" + textoUsuario.Text+ "' and password ='" + textoContraseña.Text + "'", conexion);
            MySqlDataAdapter adaptaDatos = new MySqlDataAdapter(comando);
            adaptaDatos.Fill(datos);
            if (datos.Rows.Count == 1 )
            {
                this.Hide();
                new DashboardWindow().Show();
                
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectos");
            }                       
        }
    }
}
