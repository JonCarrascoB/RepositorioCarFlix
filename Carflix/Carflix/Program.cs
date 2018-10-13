using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Carflix
{
    class Program
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["conexionCARFLIX"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;

        static void Main(string[] args)
        {

            //Se crea un bucle para logear al cliente. El cliente debera meter su clave y el programa la validara con la clave
            // de la base de datos "Cliente". Si la clave coincide, se pasara al menu de socio. En el caso contrario el programa
            // entra en bucle hasta obtener una clave registrada. (NOTA: da error tras dos claves errones)

            string clave;
            SqlDataReader codClave;
            Console.WriteLine("Bienvenido a CarFlix, su Repositorio de Peliculas.");
            do
            {
                Console.WriteLine("Interte su clave de socio:");
                clave = Console.ReadLine();

                conexion.Open();
                cadena = "SELECT * FROM CLIENTE WHERE Clave LIKE '" + clave + "'";
                comando = new SqlCommand(cadena, conexion);
                codClave = comando.ExecuteReader();

                Console.WriteLine("Clave erronea.");

            } while (codClave.Read() == false);
                conexion.Close();

            Console.WriteLine("Bienvenido Estimado socio");

            //Se introduce un menu de socio cuando la clave introducida es correcta. El cliente debera meter el numero de la elección 
            //deseada. En este punto se introduce un metodo enlazado a un switch con los metodos de cada sección. Cualquir numero ya
            // sea negativo o positivo que no sea 1,2,3,4, provoca que siga entrando el menu.

            int choice;
            do
            {
                Console.WriteLine("Menu de opciones para socios");
                Console.WriteLine("1. Ver peliculas disponibles");
                Console.WriteLine("2. Alquilar Pelicula");
                Console.WriteLine("3. Mis Películas Alquladas");
                Console.WriteLine("4. Log Out");

                choice = Convert.ToInt32(Console.ReadLine());

            } while (choice <= 0 || choice > 4);

            Menu(choice);



            
            Console.ReadLine();
        }

        //Con este metodo el cliente podra ver que peliculas del repositorio puede alquilar, segun la edad del cliente y que las 
        // peliculas no esten alquiladas ya.

        public static void VerPeliculas()
        {
            //conexion.Open();
            //cadena = "SELECT FechaNacimiento FROM Clientes WHERE Clave LIKE'" + codClave + "'";
            //comando = new SqlCommand(cadena, conexion);
            //comando.ExecuteNonQuery();
            //conexion.Close();
            //conexion.Open();
            //cadena = "SELECTED DATEDIFF (year, Cliente.FechaNacimiento,GETDATE()) AS dateDif";
            //comando = new SqlCommand(cadena, conexion);
            //SqlDataReader edad = comando.ExecuteReader();
            //while (edad.Read())
            //{
            //    Console.WriteLine(edad["dateDif"].ToString);
            //        }
            //conexion.Close();
            conexion.Open();
            cadena = "SELECT * FROM Películas WHERE Estado LIKE 'Disponible' UNION WHERE Clasificación = DATEDIFF (year, Cliente.FechaNacimiento, GETDATE())";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader disponibles = comando.ExecuteReader();
            //if ()
            while (disponibles.Read())
            {
                Console.WriteLine(disponibles["Título"].ToString() + "\t" + disponibles["Genero"].ToString());
                Console.WriteLine();
            }
            Console.ReadLine();
            disponibles.Close();
            conexion.Close();
            return;
            //if ()


            return;
        }


        public static void Menu(int menuChoice)
        {
            bool exit = false;
            do
            {
                switch (menuChoice)
                {
                    case 1:
                        VerPeliculas();
                        exit = true;
                        break;
                    //case 2:
                    //    AlquilarPeliculas();
                    //    exit = true;
                    //    break;
                    //case 3:
                    //    MisPeliculas();
                    //    exit = true;
                    //    break;
                    //case 4:
                    //    LogOut();
                    //    Console.WriteLine("Que tenga usted un buen día");
                    //    exit = true;
                    //    break;
                    //default:

                    //    break;
                }
            } while (exit == false);
            return;
        }
    }
}
