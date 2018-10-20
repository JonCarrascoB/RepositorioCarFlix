using System;
using System.Collections.Generic;
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

        public int SeeAge()
        {

        }

    }
}
