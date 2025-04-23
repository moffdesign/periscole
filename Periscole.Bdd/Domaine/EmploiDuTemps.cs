using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class EmploiDuTemps : EntBase
    {
        //matière-classe-professeur-salle
        public int MatiereId { get; set; }
        public int SalleId { get; set; }
        public int ClasseId { get; set; }
        public int ProfesseurId { get; set; }

        public int NombreHeures { get; set; }
        public int HeuresProgrammees { get; set; }
        public int HeuresPlacees { get; set; }
        public decimal TauxHoraire { get; set; }
    }
}
