using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class LigneBulletin : BaseEntity
    {
        public int BulletinNoteId { get; set; }
        public int MatiereId { get; set; }
        public decimal Moyenne { get; set; } = 0;   // Moyenne de la matière 
        public decimal Coefficiant { get; set; }
        public decimal Produit { get; set; }
        public decimal MoyenneClasse { get; set; } = 0;
        public Int16 Rang { get; set; } // Rang de l'élève dans la matière
        
        public string? Appreciations { get; set; }

        //public string? Travail { get; set; }
        //public string? Conduite { get; set; }
        //public string? Discipline { get; set; }

    }
}
