using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carflix2
{
    class Cliente
    {
        private string email;
        private string clave;
        private string nombre;
        private string apellidos;
        private DateTime fechaNacimiento;
        private string DNI;

        public Cliente()
        {

        }

        public Cliente(string email, string clave, string nombre, string apellidos, DateTime fechaNacimiento, string DNI)
        {
            this.email = email;
            this.clave = clave;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.fechaNacimiento = fechaNacimiento;
            this.DNI = DNI;
        }

        //******************* GET y SET *******************
        public string GetEmail()
        {
            return email;
        }
        public string GetClave()
        {
            return clave;
        }
        public string GetNombre()
        {
            return nombre;
        }
        public string GetApellidos()
        {
            return apellidos;
        }
        public DateTime GetFechaNacimiento()
        {
            return fechaNacimiento;
        }
        public string GetDNI()
        {
            return DNI;
        }


        public void SetEmail (string email)
        {
            this.email = email;
        }
        public void Setclave(string clave)
        {
            this.clave = clave;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }
        public void SetApellidos(string apellidos)
        {
            this.apellidos = apellidos;
        }
        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            this.fechaNacimiento = fechaNacimiento;
        }
        public void SetDNI(string DNI)
        {
            this.DNI = DNI;
        }

        //***************** METODOS ***************************

        //public int SeeAge()
        //{

        //}

        //public static void Login()
        //{
        //    SqlDataReader codClave;
        //    bool correctCode = false;
        //    do
        //    {
        //        Console.WriteLine("Inserte su correo electronico:");
        //        string correo = Console.ReadLine();
        //        Console.WriteLine("Interte su clave de socio:");
        //        string clave = Console.ReadLine();

        //        conexion.Open();
        //        cadena = "SELECT * FROM CLIENTE WHERE Email LIKE '" + correo + "' AND Clave LIKE '" + clave + "'";
        //        comando = new SqlCommand(cadena, conexion);
        //        codClave = comando.ExecuteReader();

        //        if (codClave.Read())
        //        {
        //            correctCode = true;
        //        }
        //        else
        //        {
        //            Console.WriteLine("Correo electronico y clave erroneos.");
        //        }

        //    } while (!correctCode);
        //    conexion.Close();

        //    Console.WriteLine("Bienvenido Estimado socio");

        //    int choice = -1;
        //    do
        //    {
        //        Console.WriteLine("Menu de opciones para socios");
        //        Console.WriteLine("1. Ver peliculas disponibles");
        //        Console.WriteLine("2. Alquilar Pelicula");
        //        Console.WriteLine("3. Mis Películas Alquladas");
        //        Console.WriteLine("4. Atras");

        //        try
        //        {
        //            choice = Convert.ToInt32(Console.ReadLine());
        //        }
        //        catch (FormatException ex)
        //        {
        //            Console.WriteLine("No es parametro permitido");
        //        }

        //    } while (choice <= 0 || choice > 4);

        //    Menu(choice);


        //}
    }
}
