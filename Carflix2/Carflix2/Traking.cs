using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Carflix2
{
    class Traking
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["conexionCARFLIX"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;
        string em;
        //private string email;

        public string GetEmail()
        {
            return em;
        }
        public void SetEmail(string em)
        {
            this.em = em;
        }


        public void Registro()
        {
            Cliente cliente = new Cliente();
            
            string email;
            do
            {
                Console.WriteLine("Inserte su correo electronico, por favor");
                email = Console.ReadLine();

            } while (!email.Contains("@") || !email.Contains("."));
            
            conexion.Open();
            cadena = "SELECT Email FROM Cliente WHERE Email LIKE '" + email + "'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader emailIn = comando.ExecuteReader();
            

            if (!emailIn.Read())
            {
                conexion.Close();

                bool correcto = false;
                string clave;
                int  contador = 0;
                do
                {
                    Console.WriteLine("Inserte su clave de acceso, se requiere una clave de 8 caracteres con dos numeros incluidos");
                    clave = Console.ReadLine();
                    if (clave.Length > 7)
                    {
                        for (int i = 0; i < clave.Length; i++)
                        {
                            if (char.IsDigit(clave[i]))
                            {
                                contador++;
                                if (contador >= 2)
                                {
                                    correcto = true;
                                }
                            }
                        }
                    }
                } while (correcto == false);


                Console.WriteLine("Inserte su nombre, por favor");
                string nombre = Console.ReadLine();
                Console.WriteLine("Inserte sus apellidos, por favor");
                string apellidos = Console.ReadLine();
                Console.WriteLine("Inserte fecha de nacimiento, por favor");
                DateTime fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Inserte su DNI, por favor");
                string DNI = Console.ReadLine();

                conexion.Open();
                cadena = "INSERT INTO Cliente (Email, Clave, Nombre, Apellidos, FechaNacimiento, DNI) VALUES ('" + email + "','" + clave + "','" + nombre + "','" + apellidos + "','" + fechaNacimiento + "','" + DNI + "')";
                comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();

                Console.WriteLine("Ha sido registrado en CarFlix");
               
            }
            else
            {
                Console.WriteLine("El correo electronico ya existe, introduzca otro");
            }


            return;
        }


        // Aqui se inicia el metodo Login, donde el cliente introducira el correo electronico y su clave, estos los revisara con los
        // introducidos

        public void Login()
        {
            bool correctCode = false;
            //Peliculas peliculas = new Peliculas();
            //Inventario inventario = new Inventario();
            Cliente cliente = new Cliente();

            do
            {
                Console.WriteLine("Inserte su correo electronico:");
                string email = Console.ReadLine();
                Console.WriteLine("Interte su clave de socio:");
                string clave = Console.ReadLine();

                conexion.Open();
                cadena = "SELECT Email FROM CLIENTE WHERE Email LIKE '" + email + "' AND Clave LIKE '" + clave + "'";
                comando = new SqlCommand(cadena, conexion);
          
                SqlDataReader codClave=comando.ExecuteReader();

                if (codClave.Read())
                {
                    correctCode = true;
                    em=codClave[0].ToString();
                }
                else
                {
                    Console.WriteLine("Correo electronico y clave erroneos.");
                }

            } while (!correctCode);
            conexion.Close();

            Console.WriteLine("Bienvenido Estimado socio");

            Menu();
            return;
        }

        public void Menu()
        {
            Peliculas peliculas = new Peliculas();
            Inventario inventario = new Inventario();
            Cliente cliente = new Cliente();
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

                switch (choice)
                {
                    case 1:
                        peliculas.VerPeliculas(GetEmail());

                        break;
                    case 2:
                        peliculas.AlquilarPeliculas(GetEmail());

                        break;
                    case 3:
                        inventario.MisPeliculas(GetEmail());

                        break;
                    case 4:

                        ;
                        break;
                    default:
                        Console.WriteLine("opcion no disponible, eliga otra");
                        break;
                }

            } while (choice != 4);

            return;
        }


    }
}
