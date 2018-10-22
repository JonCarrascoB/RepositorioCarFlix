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

            int elec = -1;

            do
            {
                Console.WriteLine("Elija la opción deseada");
                Console.WriteLine("1. Unase a CarFlix como nuevo cliente");
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

            Console.ReadLine();
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
            SqlDataReader emailIn;
            Console.WriteLine("Inserte su correo electronico, por favor");
            string email = Console.ReadLine();
            conexion.Open();
            cadena = "SELECT Email FROM Cliente WHERE Email LIKE '" + email + "'";
            comando = new SqlCommand(cadena, conexion);
            emailIn = comando.ExecuteReader();

            if (!emailIn.Read())
            {
                conexion.Close();

                Console.WriteLine("Inserte su clave de acceso, se requiere una clave de 8 a 10 caracteres con dos numero incluidos");
                string clave = Console.ReadLine();
                Console.WriteLine("Inserte su nombre, por favor");
                string nombre = Console.ReadLine();
                Console.WriteLine("Inserte sus apellidos, por favor");
                string apellidos = Console.ReadLine();
                Console.WriteLine("Inserte fecha de nacimiento, por favor");
                DateTime fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Inserte su DNI, por favor");
                string DNI = Console.ReadLine();

                conexion.Open();
                cadena = "INSERT INTO Clientes (Email, Clave, Nombre, Apellidos, FechaNacimiento, DNI) VALUES ('" + emailIn + "','" + clave + "','" + nombre + "','" + apellidos + "','" +fechaNacimiento+ "','"+DNI+ "')";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                Console.WriteLine("Ha sido registrado en CarFlix");
            }
            else
            {
                Console.WriteLine("El correo electronico ya existe, introduzca otro");
            }


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
                cadena = "SELECT * FROM CLIENTE WHERE Email LIKE '" + correo + "' AND Clave LIKE '" + clave + "'";
                comando = new SqlCommand(cadena, conexion);
                codClave = comando.ExecuteReader();

                if (codClave.Read())
                {
                    correctCode = true;
                }
                else
                {
                    Console.WriteLine("Correo electronico y clave erroneos.");
                }

            } while (!correctCode);
            conexion.Close();

            Console.WriteLine("Bienvenido Estimado socio");

            int choice = -1;
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
                catch (FormatException ex)
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
            conexion.Open();
            cadena = "SELECT * FROM Peliculas";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Console.WriteLine(registros["IDPeliculas"].ToString() + "\t" + registros["Titulo"].ToString());
                Console.WriteLine();
            }
            conexion.Close();

            Console.WriteLine("Eliga una Pelicula");
            int elecPeli = Convert.ToInt32(Console.ReadLine());
            conexion.Open();
            cadena = "SELECT * From Peliculas Where IDPeliculas like '" + elecPeli + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader pelic = comando.ExecuteReader();
            while (pelic.Read())
            {
                Console.WriteLine(pelic["IDPeliculas"].ToString() + "\t" + pelic["Titulo"].ToString() + "\t"+ pelic["Genero"].ToString()+ "\t" +pelic["Clasificacion"].ToString() + "\t" +pelic["Estado"].ToString());
                Console.WriteLine();
            }
            conexion.Close();

        }

        public static void AlquilarPeliculas()
        {
            conexion.Open();
            cadena = "SELECT DATEDIFF (year,Cliente.FechaNacimiento,GETDATE()) AS Dif FROM Cliente where Email = '"+correo+"'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader edadR = comando.ExecuteReader();
            int edad = Convert.ToInt32(edadR.Read());
            conexion.Close();


            conexion.Open();
            cadena = "SELECT * FROM Peliculas WHERE Estado LIKE 'Disponible' AND Clasificacion <= '" + edad + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader disponibles = comando.ExecuteReader();
            while (disponibles.Read())
            {
                Console.WriteLine(disponibles["IDPeliculas"].ToString() + "\t" + disponibles["Titulo"].ToString() + "\t" + disponibles["Genero"].ToString() + "\t" + disponibles["Clasificacion"].ToString());
                Console.WriteLine();
            }
            conexion.Close();

            Console.WriteLine("Eliga una Pelicula");
            int elecPeli = Convert.ToInt32(Console.ReadLine());
            conexion.Open();
            cadena = "SELECT * From Peliculas Where IDPeliculas like '" + elecPeli + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader pelicR = comando.ExecuteReader();
            conexion.Close();

            conexion.Open();
            cadena = "UPDATE Peliculas SET Estado = 'Alquilada' WHERE IDPeliculas LIKE'" + elecPeli + "'";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();

            conexion.Open();
            cadena = "INSERT INTO Inventario (IDPeliculas, FechaAlquiler, FechaDevolución) VALUES ('" + elecPeli + "','" + DateTime.Today + "','" + DateTime.Today+ "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            Console.WriteLine("El alquiler de la pelicula elegida ha sido registrada");
            Console.ReadLine();


        }

        public static void MisPeliculas()
        {

        }
        
        //public static void Return()
        //{

        //}
       
    }
}
