using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Carflix2
{
    class Inventario
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["conexionCARFLIX"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;

        private DateTime FechaAlquiler;
        private DateTime FechaDevolución;

        public Inventario()
        {

        }

        //***************** GET y SET *********************************
        public DateTime GetFechaAlquiler()
        {
            return FechaAlquiler;
        }
        public DateTime GetFechaDevolución()
        {
            return FechaDevolución;
        }
        public void SetFechaAlquiler(DateTime FechaAlquiler)
        {
            this.FechaAlquiler = FechaAlquiler;
        }
        public void SetFechaDevolucion(DateTime FechaDevoulución)
        {
            this.FechaDevolución = FechaDevolución;
        }


        //************************ METODOS *****************************

        public void MisPeliculas(string Email)
        {
            conexion.Open();
            cadena = "SELECT * FROM Inventario WHERE Email LIKE +'"+Email+"'";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader alquilados = comando.ExecuteReader();
            while (alquilados.Read())
            {
                int dayAlq = alquilados["FechaDevolución"].ToString().CompareTo(DateTime.Today.ToString());
                if (dayAlq > 0)
                {
                    Console.WriteLine(alquilados["IDPeliculas"].ToString() + "\t" + alquilados["FechaAlquiler"].ToString() + "\t" + alquilados["FechaDevolución"].ToString());

                }
                else if (dayAlq <= 0)
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(alquilados["IDPeliculas"].ToString() + "\t" + alquilados["FechaAlquiler"].ToString() + "\t" + alquilados["FechaDevolución"].ToString());
                    System.Console.ForegroundColor = ConsoleColor.White;
                }

            }
            conexion.Close();

            string resp;
            do
            {
                Console.WriteLine("Quiere devolver alguna pelicula, indique SI o NO");
                string respuesta = Console.ReadLine();
                resp = respuesta.ToUpper();
                if (resp == "SI")
                {
                    Console.WriteLine("Eliga el numero de la pelicula a devolver");

                    int elecPeli = Convert.ToInt32(Console.ReadLine());

                    conexion.Open();
                    cadena = "SELECT * From Peliculas Where IDPeliculas like '" + elecPeli + "'";
                    comando = new SqlCommand(cadena, conexion);
                    SqlDataReader pelicR = comando.ExecuteReader();
                    conexion.Close();

                    conexion.Open();
                    cadena = "UPDATE Peliculas SET Estado = 'Disponible' WHERE IDPeliculas LIKE'" + elecPeli + "'";
                    comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();

                    conexion.Open();
                    cadena = "DELETE From Inventario WHERE IDPeliculas LIKE '" + elecPeli + "'";
                    comando = new SqlCommand(cadena, conexion);
                    comando.ExecuteNonQuery();
                    conexion.Close();
                    Console.WriteLine("La pelicula devuelta ha sido retirada del registro");

                }
                else if (resp == "NO")
                {
                    return;
                }
            } while (resp != "SI" || resp != "NO");
            return;
        }

    }
}
