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

            string usuario, clave;
            SqlDataReader codClave;
            Console.WriteLine("Bienvenido a CarFlix, su Repositorio de Peliculas.");
            do
            {
                Console.WriteLine("Inserte su nombre de Usuario:");
                usuario = Console.ReadLine();
                Console.WriteLine("Interte su clave de socio:");
                clave = Console.ReadLine();

                conexion.Open();
                cadena = "SELECT * FROM CLIENTE WHERE Usuario LIKE '"+usuario+"' AND Clave LIKE '"+clave+"'";
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

        //public static void VerPeliculas()
        //{

        //    conexion.Open();
        //    cadena = "SELECTED DATEDIFF (year, Cliente.FechaNacimiento,GETDATE())";
        //    comando = new SqlCommand(cadena, conexion);
        //    SqlDataReader edad = comando.ExecuteReader();
        //    conexion.Close();


        //    conexion.Open();
        //    cadena = "SELECT * FROM Películas WHERE Estado LIKE 'Disponible' AND Clasificación <= '"+edad+"'";
        //    comando = new SqlCommand(cadena, conexion);
        //    SqlDataReader disponibles = comando.ExecuteReader();
            
        //    while (disponibles.Read())
        //    {
        //        Console.WriteLine(disponibles["Título"].ToString() + "\t" + disponibles["Genero"].ToString());
        //        Console.WriteLine();
        //    }
        //    Console.ReadLine();
        //    disponibles.Close();
        //    conexion.Close();
        //    return;
            
        //}

        public static void AlquilarPeliculas()
        {
            Console.WriteLine("Inserte el titulo de la Película elegida");
            string título = Console.ReadLine();
            conexion.Open();
            cadena = "UPDATE Películas SET Estado = 'Alquilada' WHERE Título LIKE '"+título+"'";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

            conexion.Open();
            cadena = "INSERT INTO Inventario (DNI, Título, FechaAlquiler, FechaDevolución) VALUES ('Cliente.DNI','" + título + "','" + DateTime.Today.ToString("dd/MM/yyyy") + "','" + DateTime.Today.ToString("dd + 15/MM/yyyy") + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            Console.WriteLine("Su habitación ha sido reservada");
            Console.ReadLine();

            return;
        }


        public static void Menu(int menuChoice)
        {
            bool exit = false;
            do
            {
                switch (menuChoice)
                {
                    //case 1:
                    //    VerPeliculas();
                    //    exit = true;
                    //    break;
                    case 2:
                        AlquilarPeliculas();
                        exit = true;
                        break;
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
