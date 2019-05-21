namespace ProjectReports.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ReportsModel : DbContext
    {
        public ReportsModel()
            : base("name=ModelReports")
        {
        }

        public virtual DbSet<Reports> Reports { get; set; }
        public virtual DbSet<Shifts> Shifts { get; set; }
        public virtual DbSet<Workers> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reports>()
                .Property(e => e.IncidentNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Reports>()
                .Property(e => e.ContentIncident)
                .IsUnicode(false);

            modelBuilder.Entity<Reports>()
                .Property(e => e.ActionToken)
                .IsUnicode(false);

            modelBuilder.Entity<Reports>()
                .Property(e => e.DeviceNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Reports>()
                .Property(e => e.DeviceName)
                .IsUnicode(false);

            modelBuilder.Entity<Shifts>()
                .Property(e => e.TimeRange)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Workers>()
                .Property(e => e.LastName)
                .IsUnicode(false);
        }
    }
}
