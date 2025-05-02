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
        public int MatiereId { get; set; }
        public DateTime DateEffective { get; set; }
        public string? Note { get; set; }
        public string? Coefficiant { get; set; }
        public string? Produit { get; set; }
        public string? Moyenne { get; set; }
        public Int16? Rang { get; set; }
        public string? Travail { get; set; }
        public string? Conduite { get; set; }
        public string? Discipline { get; set; }
        public string? Appreciation { get; set; }

        public virtual Controle Controle { get; set; } = new();
        public virtual Matiere Matiere { get; set; } = new();

    }
}
