namespace GISProgram.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Infrastructure;

    public partial class ParkProgram : DbContext
    {
        public ParkProgram()
            : base("name=ParkProgram")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public virtual DbSet<vwProgramHelper> vwProgramHelpers { get; set; }
    }
}
