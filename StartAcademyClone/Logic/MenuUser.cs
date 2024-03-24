using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.Logic
{
    internal static class MenuUser
    {
        internal static void Show()
        {
            ConsoleKeyInfo letter;
            UserUtility userUtility = new();

            do
            {
                Console.Clear();
                Console.WriteLine("Registrati oppure effettua il login.");
                Console.WriteLine(new string('-',100));
                Console.WriteLine();
                Console.WriteLine("A) per registrarti.");
                Console.WriteLine("B) per accedere.");
                Console.WriteLine("F) per uscire.");

                letter = Console.ReadKey();

                switch (letter.Key.ToString().ToUpper())
                {
                    case "A":
                        userUtility.Register();
                        break;
                    case "B":
                        userUtility.Login();
                        break;
                }

            } while (letter.Key.ToString().ToUpper() != "F");

        }
       
    }
}
