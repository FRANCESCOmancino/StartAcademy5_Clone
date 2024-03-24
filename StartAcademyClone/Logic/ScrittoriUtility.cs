using LibraryFile;
using StartAcademyClone.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.Logic
{
    internal static class ScrittoriUtility
    {
        internal static void creaListScrittori()
        {

            List<string> myLines = UtilityLibrary.creaListString(ConfigurationManager.AppSettings["pathLibri"]);

            List<string> myLinesScrittori = new();

            foreach (string s in myLines)
            {
                if (!s.Contains('*'))
                {
                    myLinesScrittori.Add(s);
                }
            }

            List<Libro> libri = new List<Libro>();

            //PARAMETRI FITTIZZI
            string isbn = string.Empty;
            string autore = string.Empty;
            string libro = string.Empty;
            int anno = 0;
            double prezzo = 0;
            string genere = string.Empty;
            //FINE PARAMETRI FITTIZZI

            //creazione lista di scrittori
            foreach (string s in myLinesScrittori)
            {
                //ISBN
                if (s.Split(':')[0].ToLower() == "isbn")
                {
                    isbn = s.Split(':')[1];
                }

                //AUTORE
                if (s.Split(':')[0].ToLower() == "autore")
                {
                    autore = s.Split(':')[1];
                }

                //LIBRO
                if (s.Split(':')[0].ToLower() == "libro")
                {
                    libro = s.Split(':')[1];
                }

                //ANNO
                if (s.Split(':')[0].ToLower() == "anno publicazione")
                {
                    anno = Convert.ToInt16(s.Split(':')[1]);
                }

                //PREZZO
                if (s.Split(':')[0].ToLower() == "prezzo")
                {
                    prezzo = (Convert.ToDouble(s.Split(':')[1]) / 100);
                }

                //GENERE
                if (s.Split(':')[0].ToLower() == "genere")
                {
                    genere = s.Split(':')[1];

                    Libro libroNew = new(isbn, autore, libro, anno, prezzo, genere);
                    libri.Add(libroNew);
                }
            }
        }
    }
}
