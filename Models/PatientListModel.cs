using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Models
{
    public class PatientListModel
    {
        public int ID { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }

        public string DateOfBirth { get; set; }

        public DateTime? TimeEntry { get; set; }
    }
}
