using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskProject.Entities
{
    public class PatientRecord
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]    
        public string DiseaseName { get; set; }

        [MaxLength(200)]
        public string Description { get; set; }

        public double AmountBill { get; set; }

        public DateTime TimeEntry { get; set; }

        public int PatientID { get; set; }

        public Patient Patient { get; set; }
    }
}
