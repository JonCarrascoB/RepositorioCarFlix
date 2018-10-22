using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carflix2
{
    class Peliculas
    {

        private int IDPeliculas;
        private string Titulo;
        private string Genero;
        private int Clasificacion;

        public Peliculas()
        {

        }

        public Peliculas(int IDPeliculas, string Titulo, string Genero, int Clasificacion)
        {
            this.IDPeliculas = IDPeliculas;
            this.Titulo = Titulo;
            this.Genero = Genero;
            this.Clasificacion = Clasificacion;
        }

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


            
            
            

    }
}
