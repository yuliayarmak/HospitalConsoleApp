using DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EF
{
    public class HospitalModel : DbContext
    {
        public HospitalModel()
            : base("name=HospitalModel")
        {
            Database.SetInitializer(new Initializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>().HasOptional(p => p.Card).WithRequired(c => c.Patient).WillCascadeOnDelete(false);
            modelBuilder.Entity<Doctor>().HasOptional(d => d.Schedule).WithRequired(s => s.Doctor).WillCascadeOnDelete(false);
        }

        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<Record> Records { get; set; }
        public virtual DbSet<Registry> Registries { get; set; }
        public virtual DbSet<Schedule> Schedules { get; set; }
    }
}