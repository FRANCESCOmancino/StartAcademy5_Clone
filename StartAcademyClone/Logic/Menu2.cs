using StartAcademyClone.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.Logic
{
    internal static class Menu2
    {
        internal static void menu2()
        {
            ConsoleKeyInfo chioice;

            do
            {
                List<Employee> list = Utility.Crea();

                Console.Clear();
                Console.WriteLine("Scegli funzionalità:");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("A) Ricerca impiegato per ruolo e città");
                Console.WriteLine("B) Ragruppamento per città con i dati nome, ruolo, età in ordine alfabetico.");
                Console.WriteLine("C) Ragruppamento per ruolo e ufficio degli impiegati che hanno più di 45 anni.");
                Console.WriteLine("D) Ragruppamento per nome, attività in modo da sapere che attività sono state svolte.");
                Console.WriteLine("E) Esci.");
                chioice = Console.ReadKey();

                switch (chioice.Key.ToString().ToUpper())
                {

                    case "A":
                        //ricerca per città e ruolo
                        Utility.Search(list);
                        break;
                    case "B":
                        //ragruppamentoo per città
                        Utility.group(list);
                        break;
                    case "C":
                        //ricerca per città/Ragruppamento per ruolo e ufficio
                        
                        Utility.groupRoleOffice(list);
                        break;
                    case "D":
                        //ricerca per città/Ragruppamento per ruolo e ufficio

                        Utility.groupNameActivity();
                        break;
                }

            } while (chioice.Key.ToString().ToUpper() != "E");
        }
    }
}
