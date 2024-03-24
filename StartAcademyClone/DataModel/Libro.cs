using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.DataModel
{
    internal class Libro
    {

        public string Isbn { get; set; }
        public string Autore { get; set; }
        public string NomeLibro { get; set; }
        public int Anno { get; set; }
        public double Prezzo { get; set; }
        public string Genere { get; set; }


        internal Libro(string isbn,string autore, string nomeLibro, int anno, double prezzo, string genere)
        {
            Isbn = isbn;
            Autore = autore;
            NomeLibro = nomeLibro;
            Anno = anno;
            Prezzo = prezzo;
            Genere = genere;
        }
    }
}
