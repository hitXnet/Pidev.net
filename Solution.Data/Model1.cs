namespace Solution.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<employe> employe { get; set; }
        public virtual DbSet<project> project { get; set; }
        public virtual DbSet<ticket> ticket { get; set; }
        public virtual DbSet<timesheet> timesheet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employe>()
                .Property(e => e.bio)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.cv)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<project>()
                .Property(e => e.projectName)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.etat)
                .IsUnicode(false);

            modelBuilder.Entity<ticket>()
                .Property(e => e.tache)
                .IsUnicode(false);
        }
    }
}
