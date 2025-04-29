using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Bulletin : BaseEntity
    {
        public int AnneeScoId { get; set; }
        public int EleveId { get; set; }
        //public int ClasseId { get; set; }
        public int Periode { get; set; } // Mensuelle, Trimestre ou Semestre
        public Int16 Numero { get; set; } // Numéro de la période
        public decimal Moyenne { get; set; } // Moyenne obtenue par l'élève
        public int Rang { get; set; }

        public int EffectifClasse { get; set; } // Effectif de la classe
        public decimal MoyenneClasse { get; set; } // (revoir la pertinence de cette info ici.)

        public int Absences { get; set; } = 0;
        public int Retards { get; set; } = 0;
        public string? AppreciationGlobale { get; set; }

    }
}
