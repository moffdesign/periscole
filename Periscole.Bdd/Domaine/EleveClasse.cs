using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class EleveClasse
    {
        [ForeignKey("AnneeSco")]
        public int IdAnneeSco { get; set; }
        public required AnneeSco AnneeSco { get; set; }

        [ForeignKey("Classe")]
        public int IdClasse { get; set; }
        public required Classe Classe { get; set; }

        /// <summary>
        /// Professeur principal de la classe (ex. M. Antoine Elan).
        /// </summary>
        public int? IdProfesseur { get; set; }
        public Professeur? Professeur { get; set; }

        /// <summary>
        /// Elèves affectés à la classe pour l'année scolaire en cours.
        /// </summary>
        public virtual ICollection<Eleve> Eleves { get; set; } = [];
    }
}
