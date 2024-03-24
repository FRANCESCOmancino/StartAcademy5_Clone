using StartAcademyClone.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.Logic
{
    internal class StudentMenager
    {
        internal List<Student> students = [];
        internal void Insert()
        {

            Student student = new Student();


            //Nome 
            Console.Clear();
            bool isName = false;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(new string('*', 100));
                Console.Write("Inserisci il tuo nome: ");
                string? Name = Console.ReadLine();


                if (Name.Length < 3 || Name.Length > 35)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Il nome è obbligatorio e deve contenere dai 3 ai 35 caratteri.");
                    Console.ReadKey();
                    isName = false;
                }
                else
                {
                    student.Name = Name;
                    isName = true;
                }
            } while (isName == false);


            //id
            student.Id = student.CounterId();

            //LastName
            bool isLastName = false;
            do
            {
                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("Inserisci il Cognome:");
                string inputLastName = Console.ReadLine();

                if ((inputLastName.Length < 3) || (inputLastName.Length > 35))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Cognome obbligatorio, compreso tra 3 e 35 caratteri.");
                    Console.WriteLine("Premi un tasto per proseguire");
                    Console.ReadKey();

                }
                else
                {
                    student.LastName = inputLastName;
                    isLastName = true;
                }

            } while (isLastName == false);


            //Age
            bool isAge = false;
            do
            {

                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("Inserisci la tua età:");

                int inputAge;
                string inputAgeStr = Console.ReadLine();
                int.TryParse(inputAgeStr, out inputAge);

                if ((inputAge < 18) || (inputAge > 120))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Devi essere maggiorenne.");
                    Console.WriteLine("Premi un tasto per proseguire");
                    Console.ReadKey();

                }
                else
                {
                    student.Age = inputAge;
                    isAge = true;
                }

            } while (isAge == false);


            //Phone
            bool isPhone = false;
            do
            {

                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("Inserisci il tuo numero di telefono (Facoltativo):");


                string? inputPhone = Console.ReadLine();


                if (inputPhone.Length != 10)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Il numero di telefono deve contenere 10 cifre.");
                    Console.WriteLine("Premi un tasto per proseguire");
                    Console.ReadKey();

                }
                else
                {
                    student.Phone = inputPhone;
                    isPhone = true;
                }

            } while (isPhone == false);


            //email
            bool isEmail = false;
            do
            {

                Console.Clear();
                Console.WriteLine("");
                Console.WriteLine(new string('*', 100));
                Console.WriteLine("Inserisci la tua email:");
                string inputEmail = Console.ReadLine();

                if (inputEmail.Contains('@'))
                {
                    student.Email = inputEmail;
                    isEmail = true;

                }
                else
                {
                    Console.WriteLine("");
                    Console.WriteLine("Non é presente alcuna @.");
                    Console.WriteLine("Premi un tasto per proseguire");
                    Console.ReadKey();
                }



            } while (isEmail == false);



            Console.Clear();
            Console.WriteLine("Dati inseriti");
            Console.WriteLine(new string('*', 100));
            Console.WriteLine($"Id: {student.Id}");
            Console.WriteLine($"Nome: {student.Name}");
            Console.WriteLine($"Cognome: {student.LastName}");
            Console.WriteLine($"Età: {student.Age}");
            Console.WriteLine($"Numero di telefono: {student.Phone}");
            Console.WriteLine($"Email: {student.Email}");
            Console.WriteLine(new string('*', 100));

            Console.WriteLine($"Y) per confermare.");
            Console.WriteLine($"N) per annullare.");

            ConsoleKeyInfo letteraScelta;

            letteraScelta = Console.ReadKey();

            switch (letteraScelta.Key.ToString().ToUpper())
            {
                case "Y":
                    Console.Clear();

                    students.Add(student);
                    Console.WriteLine("Inserimento confermato, premi un tasto per continuare.");
                    Console.ReadKey();

                    break;

                case "N":
                    Console.Clear();

                    Console.WriteLine("Inserimento annullato, premi un tasto per continuare.");
                    Console.ReadKey();



                    break;

            }
        }
        internal void Views()
        {
            Console.Clear();
            if (students.Count() == 0)
            {
                Console.WriteLine("non ci sono studenti");
            }
            else
            {
                foreach (Student st in students)
                {
                    Console.WriteLine($"id: {st.Id}, Name: {st.Name}, cognome: {st.LastName}, età: {st.Age}, telefono: {st.Phone}, email: {st.Email}, ");
                }

            }
            Console.ReadKey();

        }
        internal void Delete(int? Num)
        {
            Student? studentDelete = students.Find(x => x.Id == Num);
            if (studentDelete != null) 
            {
                students.Remove(studentDelete);
            }
        }
        internal void Search(int Num, bool isId)
        {
            if (isId)
            {
                List<Student> studentsSearch = students.FindAll(x => x.Id == Num);
                Console.Clear();
                if (studentsSearch.Count() != 0)
                {
                    foreach (Student st in studentsSearch)
                    {
                        Console.WriteLine($"id: {st.Id}, Name: {st.Name}, cognome: {st.LastName}, età: {st.Age}, telefono: {st.Phone}, email: {st.Email}, ");

                    }          
                }
                else
                {
                    Console.WriteLine("Nessun Risultato della ricerca.");
                }
                Console.ReadKey();       
            }
            else
            {
                List<Student> studentsSearch = students.FindAll(x => x.Age == Num);
                Console.Clear();
                if (studentsSearch.Count() != 0)
                {
                    foreach (Student st in studentsSearch)
                    {
                        Console.WriteLine($"id: {st.Id}, Name: {st.Name}, cognome: {st.LastName}, età: {st.Age}, telefono: {st.Phone}, email: {st.Email}, ");

                    }
                }
                else
                {
                    Console.WriteLine("Nessun Risultato della ricerca.");
                }
                Console.ReadKey();
            }
        }
        internal void Search(string Name, string Lastname)
        {
            Console.Clear();

            List<Student> studentsSearch = students.FindAll(x => x.Name.ToUpper() == Name);

            studentsSearch.FindAll(x => x.LastName.ToUpper() == Lastname);

            if (studentsSearch.Count != 0)
            {
                foreach (Student st in studentsSearch)
                {
                    Console.WriteLine($"id: {st.Id}, Name: {st.Name}, cognome: {st.LastName}, età: {st.Age}, telefono: {st.Phone}, email: {st.Email}, ");
                }
            }
            else
            {
                Console.WriteLine("Nessun risultato");
            }
            Console.ReadKey();


        }
    }
}
