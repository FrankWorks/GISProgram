namespace GISProgram.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCode : DbContext
    {
        public ModelCode()
            : base("name=ModelCode")
        {
        }

        public virtual DbSet<tblPark> tblParks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblPark>()
                .Property(e => e.ParkName)
                .IsFixedLength();

            modelBuilder.Entity<tblPark>()
                .Property(e => e.Agency)
                .IsFixedLength();
        }

        public virtual DbSet<vwProgramHelper> vwProgramHelpers { get; set; }
    }
}
