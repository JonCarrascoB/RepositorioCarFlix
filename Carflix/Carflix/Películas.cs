using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carflix
{
    class Películas
    {

        private int codPel;
        private string título;
        private string genero;
        private int clasificación;
        private string estado;

        //************* Constructores ******************
        public Películas()
        {

        }

        public Películas(int codPel, string título, string genero, int clasificación, string estado)
        {
            this.codPel = codPel;
            this.título = título;
            this.genero = genero;
            this.clasificación = clasificación;
            this.estado = estado;
        }
        //******************** GET y SET *****************************


        public int GetCodPel()
        {
            return codPel;
        }
        public void SetCodPel(int codPel)
        {
            this.codPel = codPel;
        }

        public string GetTitulo()
        {
            return título;
        }
        public void SetTitulo(string título)
        {
            this.título = título;
        }

        public string GetGenero()
        {
            return genero;
        }
        public void SetGenero(string genero)
        {
            this.genero = genero;
        }

        public int GetClasificación()
        {
            return clasificación;
        }
        public void SetClasificación(int clasificación)
        {
            this.clasificación = clasificación;
        }

        public string GetEstado()
        {
            return estado;
        }
        public void SetEstado(string estado)
        {
            this.estado = estado;
        }

        //************************ METODOS ************************************





    }

}
}
