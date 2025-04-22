using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    /// <summary>
    /// Classe de l'élève.
    /// désigne un regroupement d'élève pour une année scolaire.
    /// </summary>
    public class Classe : Entity
    {
        /// <summary>
        /// Numéro de la classe (ex. 6ème A, 5ème B, 4ème C, 2ndT12, etc.).
        /// </summary>
        public required string Numero { get; set; }
        public override string Libelle { get => "Classe de : " + Numero; }
        
        public string? Description { get; set; }

        
    }
    
}
