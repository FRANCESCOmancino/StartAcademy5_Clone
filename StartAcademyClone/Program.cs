using StartAcademyClone.DataModel;
using StartAcademyClone.Logic;
using LibraryFile;
using System.Runtime.InteropServices;

namespace StartAcademy5;

internal class Program
{
    static void Main(string[] args)
    {
        //Menu.show();

        //Utility.Crea();

        //Creazione file JSON
        //Utility.ConvertInJson(Utility.CreateListEA());

        //Menu2.menu2();

        //Registrazione e login user
        //MenuUser.Show();


        //SCRITORI
        //CREAZIONE LISTA Scrittori
        //ScrittoriUtility.creaListScrittori();

        //ClassInterfaceAttribute ASTRATTE BIKE
        MountainBike mountainBike = new();
        mountainBike.Name = "Mounteinbike";
        mountainBike.Paga(mountainBike.Prezzo = 1000);
    }
}
