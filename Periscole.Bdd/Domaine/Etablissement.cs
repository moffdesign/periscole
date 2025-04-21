using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Etablissement : Entity
    {
        public string Adresse { get; set; } = string.Empty;
        public string Localite { get; set; } = string.Empty;
        public string BP { get; set; } = string.Empty;
        public string CodePostal { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
