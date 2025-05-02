using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Sequence : BaseEntity
    {
        public int AnneeScoId { get; set; }
        public int EleveId { get; set; }
        public int ClasseId { get; set; }
        public string? Libelle { get; set; }
        public Int16 Numero { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public decimal Moyenne { get; set; } // Moyenne obtenue par l'élève
        public int Rang { get; set; } // rang dans la classe

        public int Absences { get; set; } = 0;
        public int Retards { get; set; } = 0;
        public string? AppreciationGlobale { get; set; }

        
        public string? Observation { get; set; }

        public virtual AnneeSco AnneeSco { get; set; } = new() { AnneeScolaire = "non définie" };
        public virtual Eleve Eleve { get; set; } = new();
        public virtual Classe Classe { get; set; } = new() { Numero = "non définie" };

        public ICollection<NoteSequence> NotesSequences { get; set; } = [];
    }
}
