using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace GISProgram.Models
{
    public class programLocationViewModel
    {
        public string name { get; set; }
        //public string parkName { get; set; }
        [Key]
        public Nullable<long> locationID { get; set; }
    }
}