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
        public PeriscoleContext(DbContextOptions<PeriscoleContext> options)
            : base(options)
        {
        }

        public DbSet<EleveClasse> EleveClasses { get; set; }
        public DbSet<AnneeSco> AnneesScolaires { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            // Configure the relationships and other settings here
            base.OnModelCreating(modelBuilder);
        }
    }

}
