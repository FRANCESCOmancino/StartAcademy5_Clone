using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.DataModel
{
    internal class Scrittore
    {
        public static List<Scrittore> scrittori = new();

        //Creazione ID
        private static int counter = 0;

        internal int CounterId()
        {
            counter++;
            return counter;
        }

        public int Id {  get; set; }
        public string Autore {  get; set; }
        public List<Libro> Libri { get; set; }



        internal Scrittore( string autore, List<Libro> libri)
        {
            Id =CounterId();
            Autore = autore; 
            Libri = libri;
        }
    }
}
