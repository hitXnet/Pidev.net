namespace Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
   //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]

    public partial class Context : DbContext
    {
        public Context()  : base("name=Context")
        {
        }

        public virtual DbSet<commentaire> commentaires { get; set; }
        public virtual DbSet<conversation> conversations { get; set; }
        public virtual DbSet<employe> employes { get; set; }
        public virtual DbSet<forum> fora { get; set; }
        public virtual DbSet<likecom> likecoms { get; set; }
        public virtual DbSet<likepost> likeposts { get; set; }
        public virtual DbSet<message> messages { get; set; }
        public virtual DbSet<post> posts { get; set; }
        public virtual DbSet<Conge> conges { get; set; }
        public virtual DbSet<Absence> absences { get; set; }
        public virtual DbSet<forums> form { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<commentaire>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<commentaire>()
                .HasMany(e => e.likecoms)
                .WithOptional(e => e.commentaire)
                .HasForeignKey(e => e.fk_com_id);

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
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.commentaires)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.fk_emp_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.posts)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.fk_emp_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.messages)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.fk_emp_sender_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.likecoms)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.fk_emp_id);

            modelBuilder.Entity<employe>()
                .HasMany(e => e.likeposts)
                .WithOptional(e => e.employe)
                .HasForeignKey(e => e.fk_emp_id);

            modelBuilder.Entity<forum>()
                .Property(e => e.sujet)
                .IsUnicode(false);

            modelBuilder.Entity<forum>()
                .HasMany(e => e.posts)
                .WithOptional(e => e.forum)
                .HasForeignKey(e => e.fk_forum_id);

            modelBuilder.Entity<message>()
                .Property(e => e.contenu)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.photo)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.text)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .Property(e => e.video)
                .IsUnicode(false);

            modelBuilder.Entity<post>()
                .HasMany(e => e.commentaires)
                .WithOptional(e => e.post)
                .HasForeignKey(e => e.fk_post_id);

            modelBuilder.Entity<post>()
                .HasMany(e => e.likeposts)
                .WithOptional(e => e.post)
                .HasForeignKey(e => e.fk_post_id);
            Database.SetInitializer<Context>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
