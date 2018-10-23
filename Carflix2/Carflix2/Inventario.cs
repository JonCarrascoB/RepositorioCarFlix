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
                Console.WriteLine(alquilados["IDPeliculas"].ToString() + "\t" + alquilados["FechaAlquiler"].ToString() + "\t" + alquilados["FechaDevolución"].ToString());
                
            }
            conexion.Close();
        }

    }
}
