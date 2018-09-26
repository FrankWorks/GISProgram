using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GISProgram.Models
{
    public class programViewModel
    {
        [Required]
        public string name { get; set; }
        [Required]
        public string parkName { get; set; }
        [Required]
        public long locationID { get; set; }
        [Key]
        public Nullable<int> programID { get; set; }
        //[Required]
        //public string programName { get; set; }
        public string type { get; set; }
        [Required]
        public string description { get; set; }
        [Required]
        public string displayAge { get; set; }
        
        public string feeStructure { get; set; }
        
        public Nullable<bool> registrationRequired { get; set; }
        [Required]
        public string registrationFee { get; set; }
        [Required]
        public string frequencyType { get; set; }
        [Required]
        public string frequency { get; set; }

        public string specialCriteria { get; set; }
        [Required]
        public string programCategoryName { get; set; }
    }
}