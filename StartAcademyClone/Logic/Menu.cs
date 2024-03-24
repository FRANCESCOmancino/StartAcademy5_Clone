using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.Logic
{
    internal static class Menu
    {
        internal static void show()
        {

            StudentMenager studentMenager = new StudentMenager();
            ConsoleKeyInfo letter;
            do
            {
                Console.Clear();
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("**************** Gestione Academy ****************");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("");

                Console.WriteLine("Gestione Studente");
                Console.WriteLine("A) Inserimento");
                Console.WriteLine("B) Visualizzazione");
                Console.WriteLine("C) Ricerca");
                Console.WriteLine("D) Eliminazione");
                Console.WriteLine("");

                Console.Write("Scegli una opzione: ");
                letter = Console.ReadKey();

                switch (letter.Key.ToString().ToUpper())
                {
                    case "A":
                        studentMenager.Insert();
                        break;
                    case "B":
                        studentMenager.Views();
                        break;
                    case "C":

                        ConsoleKeyInfo chioice;

                        do
                        {

                            Console.Clear();
                            Console.WriteLine("Premi A per ricercare con ID.");
                            Console.WriteLine("Premi B per ricercare con Nome e cognome.");
                            Console.WriteLine("Premi C per ricercare con l'età.");

                            chioice = Console.ReadKey();
                            switch (chioice.Key.ToString().ToUpper())
                            {
                                case "A":

                                    Console.Clear();
                                    Console.Write("Inserisci ID: ");
                                    bool boolId = true;
                                    string? Id = Console.ReadLine();
                                    int IdDef = 0;
                                    if (int.TryParse(Id, out IdDef))
                                    {
                                        studentMenager.Search(IdDef, boolId);
                                    }
                                    break;
                                case "B":
                                    Console.Clear();
                                    Console.Write("Inserisci il nome: ");
                                    string? nameWrite = Console.ReadLine();

                                    Console.Write("Inserisci il cognomeome: ");
                                    string? lastNameWrite = Console.ReadLine();
                                    studentMenager.Search(nameWrite.ToUpper(), lastNameWrite.ToUpper());
                                    break;
                                case "C":
                                    Console.Clear();
                                    Console.Write("Inserisci ID: ");
                                    bool boolAge = false;
                                    string? age = Console.ReadLine();
                                    int ageDef = 0;
                                    if (int.TryParse(age, out ageDef))
                                    {
                                        studentMenager.Search(ageDef, boolAge);
                                    }
                                    break;
                            }

                        } while (chioice.Key.ToString().ToUpper() != "F");
                        break;

                    case "D":
                        bool exit = false;
                        do
                        {
                            Console.Clear();
                            Console.Write("inserisci l'ID dell'utente da eliminare: ");
                            int Id;
                            if (int.TryParse(Console.ReadLine(), out Id))
                            {
                                studentMenager.Delete(Id);
                                exit = false;

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Inserisci un numero.");
                                Console.ReadKey();
                                exit = true;

                            }

                        } while (exit);
                        break;
                }

            } while (letter.Key.ToString().ToUpper() != "F");


        }
    }
}
