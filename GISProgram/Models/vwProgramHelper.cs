using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GISProgram.Models
{
    public partial class vwProgramHelper
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public string URLFriendlyName { get; set; }
        public string ProgramCategory { get; set; }
        public string ProgramName { get; set; }
        public string ProgramDescription { get; set; }
        public string MinAge { get; set; }
        public string MaxAge { get; set; }
        public string DisplayAge { get; set; }
        public string FrequencyType { get; set; }
        public string Frequency { get; set; }



    }
}