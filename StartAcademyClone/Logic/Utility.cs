using StartAcademyClone.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;
using LibraryFile;
using System.Text.RegularExpressions;
using Manager;

namespace StartAcademyClone.Logic
{
    internal static class Utility
    {
        internal static List<Employee> Crea()
        {
            List<Employee> employees = new();

            //List<string> myLinesEmployees = File.ReadAllLines(@"C:\Users\user\Desktop\zio cocco\Employees (1).txt").ToList();
            //List<string> myLinesActivities = File.ReadAllLines(@"C:\Users\user\Desktop\zio cocco\EmployeesActivities (1).txt").ToList();
            try
            {
                List<string> myLinesEmployees = UtilityLibrary.creaListString("C:\\Users\\manci\\Downloads\\Employees.txt");
                List<string> myLinesActivities = UtilityLibrary.creaListString("C:\\Users\\manci\\Downloads\\EmployeesActivities.txt");

                foreach (string str in myLinesEmployees)
                {
                    Employee employee = new();
                    employee.Matricola = str.Split(';')[0];
                    employee.Nominativo = str.Split(';')[1];
                    employee.Ruolo = str.Split(';')[2];
                    employee.Ufficio = str.Split(';')[3];
                    //eta
                    int etaProva = Convert.ToInt16(str.Split(";")[4]);
                    employee.Eta = etaProva;

                    employee.indirizzo = str.Split(';')[5];
                    employee.Citta = str.Split(';')[6];
                    employee.Provincia = str.Split(';')[7];
                    employee.Cap = str.Split(';')[8];
                    employee.Phone = str.Split(';')[9];

                    foreach (string activityStr in myLinesActivities)
                    {

                        if (employee.Matricola == activityStr.Split(";")[3])
                        {

                            Activity activity = new();
                            activity.Id = activity.Counter();
                            //Data con tryparse e parse
                            DateTime dt = DateTime.Now;
                            DateTime.TryParse(activityStr.Split(";")[0], out dt);
                            activity.Data = dt;
                            //activity.Data = DateTime.Parse(activityStr.Split(';')[0]);

                            activity.Attivita = activityStr.Split(';')[1];

                            //ore
                            int oreProva = Convert.ToInt16(activityStr.Split(";")[2]);
                            activity.Ore = oreProva;

                            activity.Matricola = activityStr.Split(';')[3];


                            //Validation activity
                            var context = new ValidationContext(activity, serviceProvider: null, items: null);
                            var validationResults = new List<ValidationResult>();

                            bool isValid = Validator.TryValidateObject(activity, context, validationResults, validateAllProperties: true);

                            if (isValid)
                            {
                                employee.employeeActivities.Add(activity);
                            }
                            else
                            {
                                Console.WriteLine("Dati ATTIVITA' non validi");
                                foreach (var validationResult in validationResults)
                                {
                                    Console.WriteLine(validationResult.ErrorMessage);
                                }
                            }
                        }
                    }

                    var context2 = new ValidationContext(employee, serviceProvider: null, items: null);
                    var validationResults2 = new List<ValidationResult>();

                    bool isValid2 = Validator.TryValidateObject(employee, context2, validationResults2, validateAllProperties: true);

                    if (isValid2)
                    {
                        employees.Add(employee);
                    }
                    else
                    {
                        Console.WriteLine("Dati Dipendente non validi");
                        foreach (var validationResult in validationResults2)
                        {
                            Console.WriteLine(validationResult.ErrorMessage);
                        }
                    }
                }
                
            }
            catch (Exception ex) 
            {
                ExManager.ErrorsEx(ex);
            }


            return employees;
        }

        internal static void  ConvertInJson(List<Employee>list)
        {
            List<Employee> employees = list;
            //Creazione file JSON
            string strFileJson = JsonSerializer.Serialize(employees, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"C:\Users\user\Desktop\zio cocco\EmployeesActivities.json", strFileJson);

            //Creazione file XML
            //XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Employee>));
            //TextWriter writer = new StreamWriter(@"C:\Users\manci\Downloads\EmployeesActivities.xml");

            //xmlSerializer.Serialize(writer, employees);

            //usare streamReader per file di grosse dimensioni
            //StreamReader streamReader = new StreamReader(pathJson);
            //string sReader=streamReader.ReadToEnd();

        }

        internal static void Search(List<Employee> employees)
        {
            bool isvalid = true;
            List<Employee> listResults = new();
            do
            {
                Console.Clear();
                Console.Write("Cerca per Ruolo e città: ");
                string? resultSearch = Console.ReadLine();



                if (resultSearch != string.Empty && resultSearch != null)
                {
                    
                    listResults = employees.FindAll(e => e.Ruolo.ToLower().Contains(resultSearch.ToLower()) || e.Citta.ToLower().Contains(resultSearch.ToLower()));

                    if (listResults.Count() == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Nessun risultato della ricerca");
                        Console.ReadKey();
                    }
                    else
                    {
                        foreach (Employee employee in listResults)
                        {
                            Console.WriteLine($"MATRICOLA: {employee.Matricola}");
                            Console.WriteLine($"NOME E COGNOME: {employee.Nominativo}");
                            Console.WriteLine($"RUOLO: {employee.Ruolo}");
                            Console.WriteLine($"UFFICIO: {employee.Ufficio}");
                            Console.WriteLine($"ETÀ: {employee.Eta}");
                            Console.WriteLine($"INDIRIZZO: {employee.indirizzo}");
                            Console.WriteLine($"CITTA': {employee.Citta}");
                            Console.WriteLine($"PROVINCIA: {employee.Provincia}");
                            Console.WriteLine($"CAP: {employee.Cap}");
                            Console.WriteLine($"TELEFONO: {employee.Phone}");
                            Console.WriteLine("----------------------------------------------------------");
                            Console.WriteLine("");

                        }
                        isvalid = false;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Nessun risultato della ricerca.");
                   
                }
                Console.ReadKey();


            } while (isvalid);
        }

        internal static void group(List<Employee> employees)
        {
            Console.Clear ();
            Console.WriteLine("Raggruppamento per città.");
            Console.WriteLine("******************************************************");
            Console.WriteLine("");

            var cityGroup = employees.GroupBy(e => e.Citta).ToList();

            foreach (var city in cityGroup)
            {
                Console.WriteLine("******************************************************");
                Console.WriteLine($"Città: {city.Key}");
                Console.WriteLine("******************************************************");
                Console.WriteLine("");

                foreach (Employee employee in city.OrderBy(e => e.Nominativo))
                {
                    Console.WriteLine($"NOME E COGNOME: {employee.Nominativo}");
                    Console.WriteLine($"RUOLO: {employee.Ruolo}");
                    Console.WriteLine($"ETÀ: {employee.Eta}");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("");
                }
            }
            Console.ReadKey ();

        }

        internal static void groupRoleOffice(List<Employee> employees)
        {
            Console.Clear();
            Console.WriteLine("Raggruppamento per ruolo e ufficio di impiegati con più di 45 anni.");
            Console.WriteLine("******************************************************");
            Console.WriteLine("");

            var group = employees.Where(e => e.Eta > 45).GroupBy(e => (e.Ruolo, e.Ufficio)).ToList();

            foreach (var g in group)
            {
                Console.WriteLine("******************************************************");
                Console.WriteLine($"Ruolo e ufficio : {g.Key}");
                Console.WriteLine("******************************************************");
                Console.WriteLine("");

                foreach (Employee employee in g)
                {
                    Console.WriteLine($"MATRICOLA: {employee.Matricola}");
                    Console.WriteLine($"NOME E COGNOME: {employee.Nominativo}");
                    Console.WriteLine($"RUOLO: {employee.Ruolo}");
                    Console.WriteLine($"UFFICIO: {employee.Ufficio}");
                    Console.WriteLine($"ETÀ: {employee.Eta}");
                    Console.WriteLine($"INDIRIZZO: {employee.indirizzo}");
                    Console.WriteLine($"CITTA': {employee.Citta}");
                    Console.WriteLine($"PROVINCIA: {employee.Provincia}");
                    Console.WriteLine($"CAP: {employee.Cap}");
                    Console.WriteLine($"TELEFONO: {employee.Phone}");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();

        }

        internal static void groupNameActivity()
        {
            List<Employee> employees = Utility.Crea();
            Console.Clear();
            Console.WriteLine("Raggruppamento per nome e attività.");
            Console.WriteLine("******************************************************");
            Console.WriteLine("");

            var group = from emp in employees
                        from act in emp.employeeActivities
                        group new
                        {
                            emp.Nominativo,
                            act.Attivita
                        } by act.Attivita into empgroup
                        select empgroup;


            foreach (var act in group)
            {
                Console.WriteLine("******************************************************");
                Console.WriteLine($"Attivita : {act.Key}");
                Console.WriteLine("******************************************************");
                Console.WriteLine("");

                foreach (var r in act)
                {
                    
                    Console.WriteLine($"Nome e cognome: {r.Nominativo}");
                    Console.WriteLine($"Attività: {r.Attivita}");
                    Console.WriteLine("----------------------------------------------------------");
                    Console.WriteLine("");
                }
            }
            Console.ReadKey();
        }
    }
}
