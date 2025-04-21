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
        /// <summary>
        /// Année scolaire (ex. "2021/2022", "2024-2025")
        /// </summary>
        public string? AnneeScolaire { get; set; }
        public string? Description { get; set; }

        /// <summary>
        /// Professeur principal de la classe (ex. M. Antoine Elan).
        /// </summary>
        public int? IdProfesseur { get; set; }

        /// <summary>
        /// Elèves affectés à la classe pour l'année scolaire en cours.
        /// </summary>
        public List<Eleve> Eleves { get; set; } = new List<Eleve>();
    }
    
}
