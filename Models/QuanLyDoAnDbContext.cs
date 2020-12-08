namespace QuanLyDoAnLastest.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QuanLyDoAnDbContext : DbContext
    {
        public QuanLyDoAnDbContext()
            : base("name=QuanLyDoAnDbContext")
        {
        }

        public virtual DbSet<Accounts> Accounts { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Faculties> Faculties { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Industries> Industries { get; set; }
        public virtual DbSet<Specializations> Specializations { get; set; }
        public virtual DbSet<Classes> Classes { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Subjects> Subjects { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Accounts>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
