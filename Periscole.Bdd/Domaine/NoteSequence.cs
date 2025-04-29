using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class NoteSequence : BaseEntity
    {
        public int SequenceId { get; set; }
        public int EleveId { get; set; }
        public int EnseignerId { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal NoteEleve { get; set; }
        //public decimal Coefficiant { get; set; }
        //public decimal Produit { get; set; }
        public Int16 Rang { get; set; }
        public string? Travail { get; set; }
        public string? Conduite { get; set; }
        public string? Discipline { get; set; }
        public string? Appreciation { get; set; }
    }
}
