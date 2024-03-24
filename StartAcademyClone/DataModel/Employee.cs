using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.DataModel
{
    public class Employee
    {
        [Key]
        [Required]
        public string Matricola { get; set; }
        [Required]
        public string Nominativo { get; set; }
        [Required]
        public string Ruolo { get; set; }
        [Required]
        public string Ufficio { get; set; }
        [Required]
        [Range(16,60)]
        public int Eta { get; set; }
        [Required]
        public string indirizzo { get; set; }
        [Required]
        public string Citta { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Cap { get; set; }
        [Required]
        public string Phone { get; set; }

        public List<Activity> employeeActivities { get; set; } = [];

        public Employee()
        {
            Matricola = string.Empty;
            Nominativo = string.Empty;
            Ruolo = string.Empty;
            Ufficio = string.Empty;
            Eta = 0;
            indirizzo = string.Empty;
            Citta = string.Empty;
            Provincia = string.Empty;
            Cap = string.Empty;
            Phone = string.Empty;

        }
    }
}
