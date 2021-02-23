using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Entities
{
    public class Patient
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int OfficialID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<PatientRecord> PatientRecords { get; set; }
    }
}
