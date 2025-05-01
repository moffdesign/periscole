using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    [Table("Eleve", Schema = "Eleve")]
    public class Eleve : Personne
    {
        public override string Libelle { get => Nom + " " + Prenom; }
        public string Matricule { get; set; } = string.Empty;
        public string? NomDuPere { get; set; }
        public string? NomDeLaMere { get; set; }
        public string? NomDuTuteur { get; set; }

        /// <summary>
        /// Date première inscription à l'école.
        /// </summary>
        public string? PremiereInscription { get; set; }
        public string? EtablissementOrigine { get; set; }
        public Int16? Bulletin { get; set; } // 1:envoyer 2:copie aux parents 3:copie au tuteur
        public DateTime? DateRadiation { get; set; }
        public string? MotifRadiation { get; set; }

        // toutes les classes fréquentées dans l'établissement par l'élève
        //public ICollection<ClasseEleve> ClasseEleves { get; set; } = [];

    }
}
