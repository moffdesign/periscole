using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class NoteClasse : BaseEntity
    {
        public int ControleId { get; set; }
        public int ClasseId { get; set; }
        public int MatiereId { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal NoteTotale { get; set; } = 0; // le controle peut être noté sur 10, 20, 15, etc.
        public decimal MoyenneClasse { get; set; }
        public Int16 Rang { get; set; } // Rang de la classe dans la matière par rapport aux autres classes.
        public Int16 Effectif { get; set; }
        public string? Appreciation { get; set; }
    }
}
