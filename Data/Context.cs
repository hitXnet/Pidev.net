namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<employe> employes { get; set; }
        public virtual DbSet<frai> frais { get; set; }
        public virtual DbSet<fraisprevu> fraisprevus { get; set; }
        public virtual DbSet<mission> missions { get; set; }
        public virtual DbSet<notefrai> notefrais { get; set; }
        public virtual DbSet<notefraisemploye> notefraisemployes { get; set; }

        public virtual DbSet<Facture> factures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<employe>()
                .Property(e => e.bio)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.cv)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.prenom)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.frais)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.employe_emp_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.missions)
                .WithMany(e => e.employes)
                .Map(m => m.ToTable("employe_mission", "pidev"));

            modelBuilder.Entity<frai>()
                .HasMany(e => e.notefrais)
                .WithOptional(e => e.frai)
                .HasForeignKey(e => e.frais_idFrais);

            modelBuilder.Entity<mission>()
                .Property(e => e.LieuMission)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .Property(e => e.NomMission)
                .IsUnicode(false);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.frais)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_idMission);

            modelBuilder.Entity<mission>()
                .HasMany(e => e.fraisprevus)
                .WithOptional(e => e.mission)
                .HasForeignKey(e => e.mission_idMission);

            modelBuilder.Entity<notefrai>()
                .Property(e => e.description)
                .IsUnicode(false);

            modelBuilder.Entity<notefrai>()
                .Property(e => e.facture)
                .IsUnicode(false);

            modelBuilder.Entity<notefraisemploye>()
                .Property(e => e.descriptionem)
                .IsUnicode(false);
        }
    }
}
