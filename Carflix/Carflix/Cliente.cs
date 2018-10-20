using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carflix
{
    class Cliente
    {

        private string nombre;
        private string apellidos;
        private string DNI;
        private DateTime fechaNacimiento;
        private string usuario;
        private string clave;
        private string email;

        public Cliente(string nombre, string Apellidos, string DNI, DateTime fechaNacimiento, string usuario, string clave, string email)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.DNI = DNI;
            this.fechaNacimiento = fechaNacimiento;
            this.usuario = usuario;
            this.clave = clave;
            this.email = email;
        }
        public Cliente(string usuario, string clave)
        {
            this.usuario = usuario;
            this.clave = clave;
        }

        //*********************** GET y SET *******************************************

        public string GetNombre()
        {
            return nombre;
        }
        public void SetNombre(string nombre)
        {
            this.nombre = nombre;
        }

        public string GetApellidos()
        {
            return apellidos;
        }
        public void SetApellidos(string apellidos)
        {
            this.apellidos = apellidos;
        }

        public string GetDNI()
        {
            return DNI;
        }
        public void SetDNI(string DNI)
        {
            this.DNI = DNI;
        }

        public DateTime GetFechaNacimiento()
        {
            return fechaNacimiento;
        }
        public void SetFechaNacimiento(DateTime fechaNacimiento)
        {
            this.fechaNacimiento = fechaNacimiento;
        }

        public string GetUsuario()
        {
            return usuario;
        }
        public void SetUsuario(string usuario)
        {
            this.usuario = usuario;
        }

        public string GetClave()
        {
            return clave;
        }
        public void SetClave(string clave)
        {
            this.clave = clave;
        }

        public string GetEmail()
        {
            return email;
        }
        public void SetEmail(string email)
        {
            this.email = email;
        }

        //*********************** METODOS **************************************

        //Metodo para hacer que un .
        
       


    }
}
