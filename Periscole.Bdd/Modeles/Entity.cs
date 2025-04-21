using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Modeles
{
    /// <summary>
    /// Base Entity.
    /// </summary>
    public class Entity
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// ID de l'objet et ascendant pour les relations chaînées en cascade.
        ///  par défaut chaque objet est son propre parent...
        /// </summary>
        public int ObjParentID { get; set; } = 0;

        public virtual string Abrev { get; set; } = string.Empty;
        public virtual string Libelle { get; set; } = string.Empty;
        public virtual string Code { get; set; } = string.Empty;
        public virtual string Couleur { get; set; } = string.Empty;
        public virtual string Bulle { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = "dbuser";
        public DateTime ModifiedOn { get; set; }
        public string ModifiedBy { get; set; } = "dbuser";
        public DateTime ClosedOn { get; set; }
        public string ClosedBy { get; set; } = "dbuser";
        public string? UserKey { get; set; }

    }
}
