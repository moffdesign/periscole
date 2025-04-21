using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    /// <summary>
    /// Base Entity.
    /// </summary>
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID de l'objet parent et ascendant pour les relations chaînées en cascade.
        ///  par défaut chaque objet est son propre parent...
        /// </summary>
        public int IdAscendant { get; set; } = 0; 

        public virtual string Abrev { get; set; } = string.Empty;
        public virtual string Libelle { get; set; } = string.Empty;
        public virtual string Code { get; set; } = string.Empty;
        public virtual string Couleur { get; set; } = string.Empty;
        public virtual string Bulle { get; set; } = string.Empty;
        public virtual Int16? Ordre { get; set; } = 0;

        public DateTime DateSaisie { get; set; }
        public string SaisiePar { get; set; } = "dbuser";
        public DateTime DateMaj { get; set; }
        public string MajPar { get; set; } = "dbuser";
        public DateTime DateCloture { get; set; }
        public string CloturePar { get; set; } = "dbuser";

        //public string? UserKey { get; set; }

    }
}
