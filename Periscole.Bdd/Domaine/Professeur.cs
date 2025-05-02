using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Professeur : Personne
    {
        public override string Libelle { get => Nom + " " + Prenom; }

        //public string? NomEcole { get; set; }
        //public string? NomGroupe { get; set; }

        /// <summary>
        /// Années/Classes/Matières enseignées durant l'année scolaire.
        /// Classes et Matières tenues par le professeur.
        /// </summary>
        public ICollection<Enseigner> Enseignements { get; set; } = [];
    }
}
