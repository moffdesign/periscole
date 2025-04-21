using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Modeles
{
    public class Personne: Entity
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string Adresse { get; set; } = string.Empty;
        public string Localite { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public Int16 Sexe { get; set; }     //1:Homme 2:Femme 3:Autre 4:Inconnu
        //public int Statut { get; set; }
        //public int TypePersonne { get; set; }
        //public int? IdParent { get; set; }
        //public int? IdEnseignant { get; set; }
        //public int? IdEleve { get; set; }
        public override string Libelle { get => Nom + " " + Prenom; }

    }
}
