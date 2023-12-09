using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBD
{
    internal class Contenido
    {
        public int Id_Con;
        public string Titulo;
        public string Tipo;
        public string Genero;
        public int Temporadas;
        public int Capitulos;
        public int Duracion;

        public Contenido() //constructores
        {
            Id_Con = 0;
            Titulo = "Nombre";
            Tipo = "Pelicula";
            Genero = "Accion";
            Temporadas = 0;
            Capitulos = 0;
            Duracion = 100;
        }

        public Contenido(int id)
        {
            Id_Con = id;
        }

        public Contenido(string tit)
        {
            Titulo = tit;

        }

        public bool Guardar(int id, string tit, string tip, string gen, int tem, int cap, int dur)
        {
            Id_Con = id;
            Titulo = tit;
            Tipo = tip;
            Genero = gen;
            Temporadas = tem;
            Capitulos = cap;
            Duracion=dur;
            return true;
        }

        public bool Actualizar(string tit, string tip, string gen, int tem, int cap, int dur)
        {
            Titulo = tit;
            Tipo = tip;
            Genero = gen;
            Temporadas = tem;
            Capitulos = cap;
            Duracion = dur;
            return true;
        }

        public bool Eliminar()
        {
            Id_Con = 0;
            Titulo = "";
            Tipo = "";
            Genero = "";
            Temporadas = 0;
            Capitulos = 0;
            Duracion = 0;
            return true;
        }
        public int VerId()
        {
            return Id_Con;
        }

        public string VerTitulo()
        {
            return Titulo;
        }

        public string VerTipo()
        {
            return Tipo;
        }

        public string VerGenero()
        {
            return Genero;
        }

        public int VerTemporadas()
        {
            return Temporadas;
        }

        public int VerCapitulos()
        {
            return Capitulos;
        }

        public int VerDuracion()
        {
            return Duracion;
        }
    }
}

//hacer una nueva clase clic derecho en bdoo> 
