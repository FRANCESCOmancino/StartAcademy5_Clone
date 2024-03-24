using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartAcademyClone.DataModel
{
    internal class Student
    {
        //Creazione ID
        private static int counter = 0;

        internal int CounterId() 
        {
            counter++;
            return counter;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        internal Student()
        {
            Id = 0;     
            Name = string.Empty;
            LastName = string.Empty;    
            Age = 0;    
            Phone = string.Empty;
            Email = string.Empty;
        }
    }
}
