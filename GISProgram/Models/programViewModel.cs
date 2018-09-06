using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GISProgram.Models
{
    public class programViewModel
    {
        public string name { get; set; }
        public string parkName { get; set; }
        [Key]
        public Nullable<int> programID { get; set; }
        public string programName { get; set; }
        public string type { get; set; }
        public string description { get; set; }
        public string displayAge { get; set; }
        public string feeStructure { get; set; }
        public Nullable<bool> registrationRequired { get; set; }
        public string registrationFee { get; set; }
        public string frequencyType { get; set; }
        public string frequency { get; set; }
        public string specialCriteria { get; set; }
        public string programCategoryName { get; set; }
    }
}