using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Enseigner : BaseEntity
    {
        //[Key]
        //public int Id { get; set; }

        [ForeignKey("AnneeScoId")]
        public int AnneeScoId { get; set; }

        [ForeignKey("MatiereId")]
        public int MatiereId { get; set; }

        [ForeignKey("ClasseId")]
        public int ClasseId { get; set; }

        [ForeignKey("ProfesseurId")]
        public int ProfesseurId { get; set; }

        public int GroupeMatiereId { get; set; }

        public decimal Coefficient { get; set; }
        public int NombreHeures { get; set; }
        public Int16 CodeTri { get; set; }

        public virtual AnneeSco AnneeSco { get; set; } = new() { AnneeScolaire = string.Empty }; // Fix: Initialize required property 'AnneeScolaire'
        public virtual Matiere Matiere { get; set; } = new();
        public virtual Classe Classe { get; set; } = new() { Numero = string.Empty }; // Fix: Initialize required property 'Numero'
        public virtual Professeur Professeur { get; set; } = new();
    }
}
