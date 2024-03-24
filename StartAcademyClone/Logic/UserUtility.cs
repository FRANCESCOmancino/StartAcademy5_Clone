using LibraryFile;
using StartAcademyClone.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace StartAcademyClone.Logic
{
    internal class UserUtility
    {
        internal void Register()
        {
            Console.Clear();
            Console.WriteLine("REGISTRAZIONE");
            Console.WriteLine(new string('-', 100));
            Console.WriteLine();
            User user = new();

            //NAME
            bool isName = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Inserisci NOME e COGNOME:");
                string? inputName = Console.ReadLine();

                if (inputName != null)
                {
                    if (inputName.Length < 6 || inputName.Length > 50)
                    {
                        Console.Clear();
                        Console.WriteLine("Il nome ed il cognome devono contenere dai 6 ai 50 caratteri");
                        Console.ReadKey();
                    }
                    else
                    {
                        user.Name = inputName;
                        isName = true;                       
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Inserisci un NOME o COGNOME valido.");
                    Console.ReadKey();
                }

            } while (isName == false);
            //END NAME


            //USERNAME
            bool isUsername = false;
            do
            {
                Console.Clear();
                Console.WriteLine("Inserisci Username:");
                string? inputUsername = Console.ReadLine();

                if (inputUsername != null )
                {
                    if (inputUsername.Length < 5 || inputUsername.Length > 35 || !inputUsername.Contains('@'))
                    {
                        Console.Clear();
                        Console.WriteLine("L'Username deve contenere dai 5 ai 35 caratteri e deve contenere almeno una @.");
                        Console.ReadKey();
                    }
                    else
                    {
                        user.Username = inputUsername;
                        isUsername = true;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Inserisci un username valida.");
                    Console.ReadKey();
                }

            } while (isUsername == false);
            //END USERNAME

            //PASSWORD
            bool isPassword = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Inserisci password:");
                string? inputPassword = Console.ReadLine();
                if (inputPassword != null)
                {
                    if (inputPassword.Length > 8)
                    {
                        KeyValuePair<string, string> password = PasswordSalt.SaltEncrypt(inputPassword);
                        user.PasswordHash = password.Key; 
                        user.PasswordSalt = password.Value;
                        isPassword = true;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Inserisci una password che contiene almeno 8 caratteri.");
                        Console.ReadKey();
                    }
                }
            } while (isPassword == false);

            //END PASSWORD

            //SALVATAGGIO USER IN FILE XML
            if (isPassword == true)
            {

                User.users.Add(user);

                //creazione file XML con tutti gli users
                XmlSerializer serializer = new XmlSerializer(typeof(List<User>));
                var writer = new StreamWriter(ConfigurationManager.AppSettings["pathXmlUser"]);

                serializer.Serialize(writer, User.users);
                writer.Close();
            }
        }

        internal void Login()
        {
            Console.Clear();
            Console.WriteLine("LOGIN");
            Console.WriteLine(new string('-', 100));
            Console.WriteLine();


            Console.Write("INSERISCI IL TUO USERNAME: ");
            string? inputUsername = Console.ReadLine();

           
            var user = User.users.Find(x => x.Username == inputUsername);
            if (user != null)
            {
                bool isPassword = false;
                do
                {
                    //PASSWORD
                    Console.Clear();
                    Console.WriteLine("LOGIN");
                    Console.WriteLine(new string('-', 100));
                    Console.WriteLine();


                    Console.Write("INSERISCI la tua password: ");
                    string? inputPassword = Console.ReadLine();
                    if (inputPassword != null)
                    {
                        if (PasswordSalt.encrypted(user.PasswordSalt, user.PasswordHash, inputPassword))
                        {
                            Console.Clear() ;
                            Console.WriteLine("Login effettuato.");
                            Console.ReadKey();
                            isPassword = true;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Password errata riprova.");
                            Console.ReadKey();
                        }                      
                    }
                } while (isPassword == false);
            }else
            {
                Console.Clear();
                Console.WriteLine("Usurname errato riprova ad accedere.");
                Console.ReadKey();
            }
        }
    }
}
