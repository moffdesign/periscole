using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateCreation { get; set; }
        public string Utilisateur { get; set; } = "dbuser";     // on met le pseudo de l'utilisateur qui a créé l'entité.
        public DateTime DateModification { get; set; }
        public string ModifiePar { get; set; } = "dbuser";
        public DateTime DateCloture { get; set; }
        public string CloturePar { get; set; } = "dbuser";

        //public string? UserKey { get; set; }
    }
}
