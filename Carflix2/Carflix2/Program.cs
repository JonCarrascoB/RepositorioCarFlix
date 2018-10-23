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

            Cliente cliente = new Cliente();
            Peliculas peliculas = new Peliculas();
            Inventario inventario = new Inventario();
            Traking traking = new Traking();

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

                switch (elec)
                {
                    case 1:
                        traking.Registro();

                        break;
                    case 2:
                        traking.Login();

                        break;
                    case 3:
                        Console.WriteLine("Que tenga usted un buen día");

                        break;
                }

            } while (elec != 3);
        }

       

    }
}
