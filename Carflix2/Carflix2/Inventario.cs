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

        //public Inventario(DateTime FechaAlquiler, DateTime FechaDevolución)
        //{
        //    this.FechaAlquiler = FechaAlquiler;
        //    this.FechaDevolución = FechaDevolución;
        //}

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
                if (alquilados["FechaDevolución"].ToString() != DateTime.Today.ToString())
                {
                    Console.WriteLine(alquilados["IDPeliculas"].ToString() + "\t" + alquilados["FechaAlquiler"].ToString() + "\t" + alquilados["FechaDevolución"].ToString());

                }
                else if (alquilados["FechaDevolución"].ToString() == DateTime.Today.ToString())
                {
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(alquilados["IDPeliculas"].ToString());
                    System.Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(alquilados["FechaAlquiler"].ToString() + "\t" + alquilados["FechaDevolución"].ToString());
                }

            }
            conexion.Close();

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
            cadena = "DELETE From Inventario WHERE IDPeliculas LIKE '"+elecPeli+"'";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            Console.WriteLine("La pelicula devuelta ha sido retirada del registro");
            Console.ReadLine();

            return;
        }

    }
}
