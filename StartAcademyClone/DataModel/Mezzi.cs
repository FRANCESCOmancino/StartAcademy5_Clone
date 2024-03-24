using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.DataModel
{
    public abstract class Mezzi
    {
        public string Name { get; set; }
        public int NumeroRuote { get; set; }
        public Price PrezzoRange { get; set; }
        public Moving Movimento { get; set; }
        public int Prezzo { get; set; }

        //ENUMERATORI
        public enum Price
        {
            Chip,
            Medium,
            Expensive
        }
        public enum Moving
        {
            Terra,
            Mare,
            Aria
        }
        //FINE ENUMERATORI

        public abstract void Sali();
        public abstract void Scendi();
        public abstract void Paga(int Prezzo);
    }


    public class Bike : Mezzi
    {
        public override void Sali()
        {
            Console.WriteLine("Sei salito.");
        }
        public override void Scendi()
        {
            Console.WriteLine("Sei sceso.");
        }
        public override void Paga(int Prezzo)
        {
            Console.WriteLine($"Hai pagato {Prezzo}.");
        }

        public Bike()
        {
            Name = string.Empty;
            NumeroRuote = 0;
            Movimento = Moving.Terra;
            PrezzoRange = Price.Chip;
            Prezzo = Prezzo;
        }
    }

    public class MountainBike:Bike
    {
        public MountainBike()
        {
            Name = string.Empty;
            NumeroRuote = 0;
            Movimento = Moving.Terra;
            PrezzoRange = Price.Chip;
            Prezzo = Prezzo;
        }

        public override void Paga(int Prezzo)
        {
            Console.WriteLine($"Hai pagato la mounteinBike = {Prezzo}.");
        }
    }
}
