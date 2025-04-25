using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    /// <summary>
    /// Classe de l'élève.
    /// affectation d'un élève à une classe pour une année scolaire donnée. 
    /// </summary>
    public class ClasseEleve
    {
        [ForeignKey("AnneeSco")]
        public int AnneeScoId { get; set; }
        public AnneeSco? AnneeSco { get; set; }

        [ForeignKey("Classe")]
        public int ClasseId { get; set; }
        public Classe? Classe { get; set; }

        [ForeignKey("Eleve")]
        public int EleveId { get; set; }
        public Eleve? Eleve { get; set; }
    }
}
