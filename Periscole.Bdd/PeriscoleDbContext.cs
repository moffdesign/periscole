﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Periscole.Bdd.Domaine;

namespace Periscole.Bdd
{
    public class PeriscoleDbContext : DbContext
    {
        public PeriscoleDbContext(DbContextOptions<PeriscoleDbContext> options) : base(options) { }

        public DbSet<AnneeSco> AnneesSco { get; set; }
        public DbSet<Parametre> Parametres { get; set; }
        public DbSet<Eleve> Eleves { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Professeur> Professeurs { get; set; }

        public DbSet<ClasseEleve> ClassesEleves { get; set; }

        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<GroupeMatiere> GroupesMatieres { get; set; }
        public DbSet<Enseigner> Enseigner { get; set; }
        public DbSet<Cours> Cours { get; set; }


        public DbSet<Controle> Controles { get; set; }
        public DbSet<NoteEleve> NotesEleves { get; set; }
        public DbSet<NoteClasse> NotesClasses { get; set; }
        public DbSet<Sequence> Sequences { get; set; }
        public DbSet<NoteSequence> NotesSequences { get; set; }
        public DbSet<Bulletin> Bulletins { get; set; }
        public DbSet<LigneBulletin> LignesBulletins { get; set; }

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
            modelBuilder.Entity<Eleve>().ToTable("Eleve","Eleve").UseTpcMappingStrategy();

            modelBuilder.Entity<Classe>().ToTable("Classe","Classe").UseTpcMappingStrategy();
            modelBuilder.Entity<ClasseEleve>().ToTable("ClasseEleve", "Classe");     // Affectation élèves à une classe pour l'AnneeSco
            
            
            modelBuilder.Entity<Matiere>().ToTable("Matiere", "Program").UseTpcMappingStrategy();
            modelBuilder.Entity<GroupeMatiere>().ToTable("MatiereGroupe", "Program");  //GroupeMatiere
            modelBuilder.Entity<Enseigner>().ToTable("Enseigner", "Program");
            modelBuilder.Entity<Cours>().ToTable("Cours", "Program");
            modelBuilder.Entity<EmploiDuTemps>().ToTable("EmploiDuTemps", "Program");

            modelBuilder.Entity<Controle>().ToTable("Controle", "Note");
            modelBuilder.Entity<NoteEleve>().ToTable("NoteEleve", "Note");
            modelBuilder.Entity<NoteClasse>().ToTable("NoteClasse", "Note");
            modelBuilder.Entity<Bulletin>().ToTable("Bulletin", "Note");
            modelBuilder.Entity<LigneBulletin>().ToTable("LigneBulletin", "Note");
            modelBuilder.Entity<Sequence>().ToTable("Sequence", "Note");
            modelBuilder.Entity<NoteSequence>().ToTable("NoteSequence", "Note");

            modelBuilder.Entity<AnneeSco>().ToTable("AnneeSco", "Referentiel");
            modelBuilder.Entity<Parametre>().ToTable("Parametre", "Referentiel");
            modelBuilder.Entity<Historique>().ToTable("Historique", "Referentiel").UseTpcMappingStrategy();
            modelBuilder.Entity<Salle>().ToTable("Salle", "Referentiel").UseTpcMappingStrategy();

            //Déclaration des PK clés: pas nécessaire, déjà déclaré dans BaseEntity.
            //modelBuilder.Entity<Eleve>().HasKey(e => e.Id);

            //les indexes
            modelBuilder.Entity<Eleve>().HasIndex(eleve => eleve.Matricule).IsUnique();

            // cles composées.
            modelBuilder.Entity<ClasseEleve>().HasKey(ec => new { ec.AnneeScoId, ec.ClasseId, ec.EleveId });
            modelBuilder.Entity<Enseigner>().HasKey(e => new { e.AnneeScoId, e.ClasseId, e.MatiereId, e.ProfesseurId });

            // Déclaration des Foreign Key
            modelBuilder.Entity<Controle>().HasOne(s => s.AnneeSco).WithMany(a => a.Controles).HasForeignKey(s => s.AnneeScoId);
            modelBuilder.Entity<Controle>().HasOne(s => s.Eleve).WithMany(e => e.Controles).HasForeignKey(s => s.EleveId);
            modelBuilder.Entity<Controle>().HasOne(s => s.Classe).WithMany(c => c.Controles).HasForeignKey(s => s.ClasseId);

            modelBuilder.Entity<Sequence>().HasOne(s => s.AnneeSco).WithMany(a => a.Sequences).HasForeignKey(s => s.AnneeScoId);
            modelBuilder.Entity<Sequence>().HasOne(s => s.Eleve).WithMany(e => e.Sequences).HasForeignKey(s => s.EleveId);
            modelBuilder.Entity<Sequence>().HasOne(s => s.Classe).WithMany(c => c.Sequences).HasForeignKey(s => s.ClasseId);

            modelBuilder.Entity<Bulletin>().HasOne(n => n.AnneeSco).WithMany(c => c.Bulletins).HasForeignKey(n => n.AnneeScoId);
            modelBuilder.Entity<Bulletin>().HasOne(n => n.Eleve).WithMany(e => e.Bulletins).HasForeignKey(s => s.EleveId);
            modelBuilder.Entity<Bulletin>().HasOne(n => n.Classe).WithMany(c => c.Bulletins).HasForeignKey(s => s.ClasseId);

            modelBuilder.Entity<NoteSequence>().HasOne(n => n.Sequence).WithMany(s => s.NotesSequences).HasForeignKey(n => n.SequenceId);
            modelBuilder.Entity<NoteEleve>().HasOne(n => n.Controle).WithMany(e => e.NotesEleves).HasForeignKey(n => n.ControleId);
            modelBuilder.Entity<LigneBulletin>().HasOne(n => n.Bulletin).WithMany(m => m.LignesBulletins).HasForeignKey(n => n.BulletinId);

            modelBuilder.Entity<Enseigner>().HasOne(e => e.AnneeSco).WithMany(a => a.Enseignements).HasForeignKey(e => e.AnneeScoId);
            modelBuilder.Entity<Enseigner>().HasOne(e => e.Classe).WithMany(c => c.Enseignements).HasForeignKey(e => e.ClasseId);
            modelBuilder.Entity<Enseigner>().HasOne(e => e.Matiere).WithMany(m => m.Enseignements).HasForeignKey(e => e.MatiereId);
            modelBuilder.Entity<Enseigner>().HasOne(e => e.Professeur).WithMany(p => p.Enseignements).HasForeignKey(e => e.ProfesseurId);

            // Enregistre automatiquement toutes les class qui implémente l'interface IEntityTypeConfiguration
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            //base.OnModelCreating(modelBuilder);
        }

        // 1. add-migration amazingMigration
        // 2. update-database

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer(@"Server=nameofyourdb;Database=nameofyourserver;TrustServerCertificate=True;Trusted_Connection=True;");

    }

}
