using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Controle : BaseEntity
    {
        public int AnneeScoId { get; set; }
        public int ClasseId { get; set; }
        public int EleveId { get; set; }
        public Int16 TypeControle { get; set; } // 1: Devoir, 2: Interrogation, 3: Examen
        public int Numero { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        
        public string? Observation { get; set; }

        public virtual AnneeSco AnneeSco { get; set; } = new() { AnneeScolaire = "non définie" };
        public virtual Classe Classe { get; set; } = new() { Numero = "non définie" };
        public virtual Eleve Eleve { get; set; } = new();

        public ICollection<NoteEleve> NotesEleves { get; set; } = [];
    }
}
