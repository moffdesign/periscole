
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
            //base.OnModelCreating(modelBuilder);

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
            modelBuilder.Entity<ClasseEleve>().ToTable("ClasseEleve", "Eleve");     // Affectation élèves à une classe pour l'AnneeSco
            
            
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

            //Déclaration des PK clés
            // Affectation élèves à une classe pour l'AnneeSco
            modelBuilder.Entity<ClasseEleve>().HasKey(ec => new { ec.AnneeScoId, ec.ClasseId, ec.EleveId });

            // Déclaration des Foreign Key
            //modelBuilder.Entity<EleveClasse>().HasOne(ec => ec.Eleve).WithMany(e => e.EleveClasses).HasForeignKey(ec => ec.EleveId);

            //modelBuilder.Entity<EleveClasse>()
            //    .HasOne(ec => ec.Classe)
            //    .WithMany(c => c.EleveClasse)
            //    .HasForeignKey(ec => ec.ClasseId);

            //modelBuilder.Entity<EleveClasse>()
            //    .HasOne(ec => ec.AnneeSco)
            //    .WithMany(a => a.EleveClasses)
            //    .HasForeignKey(ec => ec.AnneeScoId);

            //Transformation des enum en code

            // Enregistre automatiquement toutes les class qui implémente l'interface IEntityTypeConfiguration
            //modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public PeriscoleDbContext(DbContextOptions<PeriscoleDbContext> options) : base(options) { }

    }

}
