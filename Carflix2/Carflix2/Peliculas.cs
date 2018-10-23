﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Carflix2
{
    class Peliculas
    {
        static String connectionString = ConfigurationManager.ConnectionStrings["conexionCARFLIX"].ConnectionString;
        static SqlConnection conexion = new SqlConnection(connectionString);
        static string cadena;
        static SqlCommand comando;


        private int IDPeliculas;
        private string Titulo;
        private string Genero;
        private int Clasificacion;

        public Peliculas()
        {

        }

        //public Peliculas(int IDPeliculas, string Titulo, string Genero, int Clasificacion)
        //{
        //    this.IDPeliculas = IDPeliculas;
        //    this.Titulo = Titulo;
        //    this.Genero = Genero;
        //    this.Clasificacion = Clasificacion;
        //}

        //******************* GET y SET ************************
        public int GetIDPeliculas()
        {
            return IDPeliculas;
        }
        public string GetTitulo()
        {
            return Titulo;
        }
        public string GetGenero()
        {
            return Genero;
        }
        public int GetClasificacion()
        {
            return Clasificacion;
        }

        public void SetIDPeliculas (int IDPeliculas)
        {
            this.IDPeliculas = IDPeliculas;
        }
        public void SetTitulo(string Titulo)
        {
            this.Titulo = Titulo;
        }
        public void SetGenero(string Genero)
        {
            this.Genero = Genero;
        }
        public void SetClasificación(int Clasificacion)
        {
            this.Clasificacion = Clasificacion;
        }

        //************************ METODOS ************************

        //public 

        public void VerPeliculas()
        {
            conexion.Open();
            cadena = "SELECT * FROM Peliculas";
            comando = new SqlCommand(cadena, conexion);
            SqlDataReader registros = comando.ExecuteReader();
            while (registros.Read())
            {
                Console.WriteLine(registros["IDPeliculas"].ToString() + "\t" + registros["Titulo"].ToString());
               
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
                Console.WriteLine(pelic["IDPeliculas"].ToString() + "\t" + pelic["Titulo"].ToString() + "\t" + pelic["Genero"].ToString() + "\t" + pelic["Clasificacion"].ToString() + "\t" + pelic["Estado"].ToString());
                
            }
            conexion.Close();
            return;
        }

        public void AlquilarPeliculas(string email)
            {
            conexion.Open();
            cadena = "SELECT DATEDIFF (year,Cliente.FechaNacimiento,GETDATE()) AS Dif FROM Cliente where Email = '" + email + "'";
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
            cadena = "INSERT INTO Inventario (IDPeliculas, FechaAlquiler, FechaDevolución) VALUES ('" + elecPeli + "','" + DateTime.Today + "','" + DateTime.Today.AddDays(20) + "')";
            comando = new SqlCommand(cadena, conexion);
            comando.ExecuteNonQuery();
            conexion.Close();
            Console.WriteLine("El alquiler de la pelicula elegida ha sido registrada");
            Console.ReadLine();

            return;
        }




    }
}
