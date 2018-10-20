using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace Carflix2
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

            Console.WriteLine("Bienvenido a CarFlix, su Repositorio de Peliculas.");

            int elec;

            do
            {
                Console.WriteLine("Eliga la opción deseada");
                Console.WriteLine("1. Unase a Carfix como nuevo cliente");
                Console.WriteLine("2. Log In para socios");
                Console.WriteLine("3. Salir");

                try
                {
                    elec = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("No es un parametro permitido");
                }

            } while (elec <= 0 || elec > 3);

            Logeo(elec);

        }

        public static void Logeo(int menuElec)
        {
            bool exit = false;
            do
            {
                switch (menuElec)
                {
                    case 1:
                        Registro();
                        exit = true;
                        break;
                    case 2:
                        Login();
                        exit = true;
                        break;
                    case 3:
                        Salir();
                        Console.WriteLine("Que tenga usted un buen día");
                        exit = true;
                        break;
                }
            } while (exit == false);
            return;
        }

        public static void Registro()
        {

            Console.WriteLine("Inserte su correo electronico, por favor");
            string email = Console.ReadLine();

        }

        public static void Login()
        {
            SqlDataReader codClave;
            bool correctCode = false;
            do
            {
                Console.WriteLine("Inserte su correo electronico:");
                string correo = Console.ReadLine();
                Console.WriteLine("Interte su clave de socio:");
                string clave = Console.ReadLine();

                conexion.Open();
                cadena = "SELECT * FROM CLIENTE WHERE Email LIKE '" +correo+ "' AND Clave LIKE '" +clave+ "'";
                comando = new SqlCommand(cadena, conexion);
                codClave = comando.ExecuteReader();

                if (codClave.Read())
                {
                    correctCode = true;
                }
                else
                {
                    Console.WriteLine("Clave erronea.");
                }

            } while (!correctCode);
            conexion.Close();

            Console.WriteLine("Bienvenido Estimado socio");

            int choice;
            do
            {
                Console.WriteLine("Menu de opciones para socios");
                Console.WriteLine("1. Ver peliculas disponibles");
                Console.WriteLine("2. Alquilar Pelicula");
                Console.WriteLine("3. Mis Películas Alquladas");
                Console.WriteLine("4. Atras");

                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch(FormatException ex)
                {
                    Console.WriteLine("No es parametro permitido");
                }

            } while (choice <= 0 || choice > 4);

            Menu(choice);


        }

        public static void Salir()
        {

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
                    case 2:
                        AlquilarPeliculas();
                        exit = true;
                        break;
                    case 3:
                        MisPeliculas();
                        exit = true;
                        break;
                    case 4:
                        Return();
                        Console.WriteLine("Que tenga usted un buen día");
                        exit = true;
                        break;
                    default:

                        break;
                }
            } while (exit == false);
            return;
        }

        public static void VerPeliculas()
        {

        }

        public static void AlquilarPeliculas()
        {

        }

        public static void MisPeliculas()
        {

        }


    }
}
