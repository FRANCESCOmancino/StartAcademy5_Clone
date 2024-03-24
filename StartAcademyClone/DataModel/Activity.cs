using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.DataModel
{
    public class Activity
    {
        //ID
        private static int counter = 0;
        internal int Counter()
        {
            counter++;
            return counter;
        }

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public string? Attivita { get; set; }

        [Required]
        public int Ore { get; set; }

        [Required]
        public string? Matricola { get; set; }


        public Activity()
        {
            Id = 0;
            Data = new DateTime();
            Attivita = string.Empty;
            Ore = 0;
            Matricola = string.Empty;
        }
    }
}
