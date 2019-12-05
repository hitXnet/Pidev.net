namespace Solution.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Conext : DbContext
    {
        public Conext()
            : base("name=Conext")
        {
        }

        public virtual DbSet<familyskill> familyskills { get; set; }
        public virtual DbSet<reference> references { get; set; }
        public virtual DbSet<skill> skills { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<familyskill>()
                .Property(e => e.FamilyName)
                .IsUnicode(false);

            modelBuilder.Entity<reference>()
                .Property(e => e.nomref)
                .IsUnicode(false);

            modelBuilder.Entity<reference>()
                .Property(e => e.backing)
                .IsUnicode(false);

            modelBuilder.Entity<reference>()
                .HasMany(e => e.familyskills)
                .WithOptional(e => e.reference)
                .HasForeignKey(e => e.reference_idref);

            modelBuilder.Entity<skill>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<skill>()
                .Property(e => e.backing)
                .IsUnicode(false);

           // modelBuilder.Entity<skill>()
               // .HasMany(e => e.familyskills)
              //  .WithOptional(e => e.skill)
              //  .HasForeignKey(e => e.skills_Idskill);
        }
    }
}
