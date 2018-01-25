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
//SQL
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows;

namespace pokemon_center
{
    /// <summary>
    /// Lógica de interacción para RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {

        private MySqlConnection conexion;
        private MySqlCommand comando;
        public RegisterWindow()
        {
            InitializeComponent();
            conexion = new MySqlConnection("Server = 127.0.0.1; Database = pokemon-center; Uid = root; Pwd =; Port = 3306");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //limpieza de los textos
            textoNombre.Text = "";
            textoIdCentro.Text = "";
            textoContrasena.Text = "";
            textoConfirmaContrasena.Text = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Registro

            try
            {
                conexion.Open();
                if (textoContrasena.Text.Equals(textoConfirmaContrasena.Text))
                {
                    try
                    {
                        comando = new MySqlCommand("INSERT INTO nurse(id_center, username, password) VALUES (" + textoIdCentro.Text + ",'" + textoNombre.Text + "','" + textoContrasena.Text + "'", conexion);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Usuario registrado");
                    }
                    catch (Exception ex) { MessageBox.Show("No ha sido posible registrar al usuario" + ex.ToString()); }

                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden");
                }

                   
            }

            catch (Exception ex)
            {
                MessageBox.Show("No se pudo conectar a la bbdd" + ex.ToString() + ex.HResult);
            }
            conexion.Close();
        }
    }
}
