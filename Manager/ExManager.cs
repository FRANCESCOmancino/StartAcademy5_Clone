using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{

    public class ExManager
    {
        //Lista Statica degli errori
        public static List<ExManager> list = new();


        
        //Creazione  file di testo della lista(public static List<ExManager> list = new();)
        public static void CreaFileErrors()
        {
            List<string> listOfString = new();

            foreach (ExManager ex in list)
            {
                string strEx = $"Data: {ex.Date}, Messaggio di errore: {ex.ExMessage}, Tipo di eccezione: {ex.TypeEx}, Sorgente: {ex.SourceEx}, Classe dell'errore: {ex.ClassEx}, Metodo dell'errore: {ex.MethodEx}\n";
                listOfString.Add(strEx);
            }
            string str = string.Join("; ", listOfString);

            File.WriteAllText("C:\\Users\\manci\\Downloads\\Errors.txt", str);
        }
        //FIne Creazione  file di testo della lista(public static List<ExManager> list = new();)


        //Funzione per la creazione dell'ogetto e per il salvataggio dell'errore e creazione di file.txt
        public static void ErrorsEx(Exception ex)
        {
            ExManager exManager = new(
                    DateTime.Now,
                    ex.Message,
                    ex.GetType().ToString(),
                    ex.Source,
                    ex.GetType().Name,
                    System.Reflection.MethodBase.GetCurrentMethod().Name
                );

            ExManager.list.Add(exManager);
            ExManager.CreaFileErrors();
        }
        //FINE Funzione per la creazione dell'ogetto e per il salvataggio dell'errore e creazione di file.txt



        public DateTime Date { get; set; }
        public string ExMessage { get; set; }
        public string TypeEx { get; set; }
        public string? SourceEx { get; set; }
        public string? ClassEx { get; set; }
        public string? MethodEx { get; set; }


        public ExManager(DateTime date, string exMessage, string typeEx, string? sourceEx, string classEx, string? methodEx)
        {
            Date = date;
            ExMessage = exMessage;
            TypeEx = typeEx;
            SourceEx = sourceEx;
            ClassEx = classEx;
            MethodEx = methodEx;
        }
    }
}
