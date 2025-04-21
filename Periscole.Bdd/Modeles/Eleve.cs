using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Modeles
{
    public class Eleve : Personne
    {
        public int? IdClasse { get; set; }
        public int? IdParent { get; set; }
        public int? IdEnseignant { get; set; }
        public string? NomParent { get; set; }
        public string? NomEnseignant { get; set; }
        public string? NomClasse { get; set; }
        public string? NomEcole { get; set; }
        public string? NomGroupe { get; set; }
        public string? NomGroupeScolaire { get; set; }
        public string? NomGroupeActivite { get; set; }
    
    }
}
