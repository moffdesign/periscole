
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Periscole.Bdd.Domaine;

namespace Periscole.Bdd
{
    public class PeriscoleContext : DbContext
    {
        public PeriscoleContext(DbContextOptions<PeriscoleContext> options) : base(options) { }

        public DbSet<EleveClasse> EleveClasses { get; set; }
        public DbSet<AnneeSco> AnneesScolaires { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /*
            // Configuration de l'entité Professeur
            modelBuilder.Entity<Professeur>()
                .HasKey(p => p.ProfesseurId);

            modelBuilder.Entity<Professeur>()
                .Property(p => p.Nom)
                .IsRequired()
                .HasMaxLength(100);

            // Relation avec Employe
            modelBuilder.Entity<Professeur>()
                .HasOne(p => p.Employe)
                .WithMany(e => e.Professeurs)
                .HasForeignKey(p => p.EmployeId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuration de l'entité Employe
            modelBuilder.Entity<Employe>()
                .HasKey(e => e.EmployeId);

            modelBuilder.Entity<Employe>()
                .Property(e => e.Nom)
                .IsRequired()
                .HasMaxLength(50);

            // Exemple d'index unique sur le nom de l'employé
            modelBuilder.Entity<Employe>()
                .HasIndex(e => e.Nom)
                .IsUnique();
            */

            // Ajout des tables
            modelBuilder.Entity<EleveClasse>().ToTable("Eleve_Classe");
            modelBuilder.Entity<Matiere>().ToTable("Program_Matiere");
            modelBuilder.Entity<Enseigner>().ToTable("Program_Enseigner");
            modelBuilder.Entity<Cours>().ToTable("Program_Cours");
            modelBuilder.Entity<EmploiDuTemps>().ToTable("Program_EmploiDuTemps");

            //Déclaration des PK clés
            //modelBuilder.Entity<EleveClasse>().HasKey(ec => new { ec.EleveId, ec.AnneeScoId, ec.ClasseId });

            // Déclaration des Foreign Key
            //modelBuilder.Entity<EleveClasse>()
            //    .HasOne(ec => ec.AnneeSco)
            //    .WithMany(a => a.EleveClasses)
            //    .HasForeignKey(ec => ec.AnneeScoID);

            //Transformation des enum en code

            // Enregistre automatiquement toutes les class qui implémente l'interface IEntityTypeConfiguration
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }
    }

}
