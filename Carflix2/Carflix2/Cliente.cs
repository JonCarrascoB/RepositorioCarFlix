using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;



namespace Carflix2
{
    class Cliente
    {
        //static String connectionString = ConfigurationManager.ConnectionStrings["conexionCARFLIX"].ConnectionString;
        //static SqlConnection conexion = new SqlConnection(connectionString);
        //static string cadena;
        //static SqlCommand comando;



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


        public void SetEmail(string email)
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



        //public void Registro()
        //{
        //    SqlDataReader emailIn;
        //    Console.WriteLine("Inserte su correo electronico, por favor");
        //    string email = Console.ReadLine();
        //    conexion.Open();
        //    cadena = "SELECT Email FROM Cliente WHERE Email LIKE '" + email + "'";
        //    comando = new SqlCommand(cadena, conexion);
        //    emailIn = comando.ExecuteReader();


        //    conexion.Close();

        //    if (!emailIn.Read())
        //    {

        //        Console.WriteLine("Inserte su clave de acceso, se requiere una clave de 8 a 10 caracteres con dos numero incluidos");
        //        string clave = Console.ReadLine();
        //        Console.WriteLine("Inserte su nombre, por favor");
        //        string nombre = Console.ReadLine();
        //        Console.WriteLine("Inserte sus apellidos, por favor");
        //        string apellidos = Console.ReadLine();
        //        Console.WriteLine("Inserte fecha de nacimiento, por favor");
        //        DateTime fechaNacimiento = Convert.ToDateTime(Console.ReadLine());
        //        Console.WriteLine("Inserte su DNI, por favor");
        //        string DNI = Console.ReadLine();

        //        conexion.Open();
        //        cadena = "INSERT INTO Clientes (Email, Clave, Nombre, Apellidos, FechaNacimiento, DNI) VALUES ('" + emailIn + "','" + clave + "','" + nombre + "','" + apellidos + "','" + fechaNacimiento + "','" + DNI + "')";
        //        comando = new SqlCommand(cadena, conexion);
        //        comando.ExecuteNonQuery();
        //        conexion.Close();
        //        Console.WriteLine("Ha sido registrado en CarFlix");
        //    }
        //    else
        //    {
        //        Console.WriteLine("El correo electronico ya existe, introduzca otro");
        //    }

        //}




        //public void Login()
        //{
        //    SqlDataReader codClave;
        //    bool correctCode = false;
        //    Peliculas peliculas = new Peliculas();
        //    Inventario inventario = new Inventario();

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

        //    Menu(choice, peliculas, inventario);


        //}

        //public void Menu(int menuChoice, Peliculas peliculas, Inventario inventario)
        //{
        //    bool exit = false;
        //    do
        //    {
        //        switch (menuChoice)
        //        {
        //            case 1:
        //                peliculas.VerPeliculas();
        //                exit = true;
        //                break;
        //            case 2:
        //                peliculas.AlquilarPeliculas();
        //                exit = true;
        //                break;
        //            case 3:
        //                inventario.MisPeliculas();
        //                exit = true;
        //                break;
        //            case 4:

        //                exit = true;
        //                break;
        //            default:

        //                break;
        //        }
        //    } while (exit == false);
        //    return;
        //}
    }
}
