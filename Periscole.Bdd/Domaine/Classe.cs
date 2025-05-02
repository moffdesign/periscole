using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    /// <summary>
    /// Classe de l'élève.
    /// regroupe les élèves d'une classe pour une année scolaire.
    /// </summary>
    public class Classe : Entity
    {
        /// <summary>
        /// Numéro de la classe (ex. 6ème A, 5ème B, 4ème C, 2ndT12, etc.).
        /// </summary>
        public required string Numero { get; set; }
        public override string Libelle { get => "Classe de : " + Numero; }
        
        public string? Description { get; set; }

        /// <summary>
        /// tous les élèves affectés à la classe.
        /// </summary>
        //public ICollection<ClasseEleve> ClasseEleves { get; set; } = [];

        /// <summary>
        /// Années/Classes/Matières enseignées durant l'année scolaire.
        /// quelles sont les matières enseignées et par quel professeur
        public ICollection<Enseigner> Enseignements { get; set; } = [];

        public ICollection<Controle> Controles { get; set; } = [];
        public ICollection<Sequence> Sequences { get; set; } = [];
        public ICollection<Bulletin> Bulletins { get; set; } = [];
        

        /// <summary>
        /// Professeur principal de la classe (ex. M. Antoine Ela).
        /// </summary>
        public int? ProfesseurId { get; set; }
        public Professeur? Professeur { get; set; }

    }
    
}
