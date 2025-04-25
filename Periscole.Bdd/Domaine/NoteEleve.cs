using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class NoteEleve : BaseEntity
    {
        public int ControleId { get; set; }
        public int EleveId { get; set; }
        public int MatiereId { get; set; }
        public DateTime DateEffective { get; set; }
        public decimal Note { get; set; }
        public decimal Coeff { get; set; }
        public decimal Produit { get; set; }
        public decimal Moyenne { get; set; }
        public Int16 Rang { get; set; }
        public string? Travail { get; set; }
        public string? Conduite { get; set; }
        public string? Discipline { get; set; }
        public string? Appreciation { get; set; }
        
    }
}
