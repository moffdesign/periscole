using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public abstract class Personne: Entity
    {
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public DateTime DateNaissance { get; set; }
        public string LieuNaissance { get; set; } = string.Empty;
        public string Adresse { get; set; } = string.Empty;
        public string Localite { get; set; } = string.Empty;
        public string BP { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Initiales { get; set; } = string.Empty;
        public Int16 Sexe { get; set; }     //1:Homme 2:Femme 3:Autre 4:Inconnu
        public string Nationalite { get; set; } = string.Empty;


        public override string Libelle { get => Nom + " " + Prenom; }

        /// <summary>
        /// Nom de connexion au système
        /// </summary>
        public string Pseudo { get; set; } = string.Empty;
        public string? MotDePasse { get; set; } = string.Empty;

    }
}
