using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Salle : Entity
    {
        /// <summary>
        /// Numéro de la salle (ex. 101, 102, 103, etc.).
        /// </summary>
        public required string Numero { get; set; }
        public string? Localisation { get; set; } 
        public int? Capacite { get; set; }
        public bool? EstActive { get; set; } = true;
        public string? Description { get; set; }

    }
}
