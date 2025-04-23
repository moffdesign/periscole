using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Enseigner : EntBase
    {
        //[Key]
        //public int Id { get; set; }

        public int MatiereId { get; set; }
        public int ClasseId { get; set; }
        public int ProfesseurId { get; set; }
        public int NombreHeures { get; set; }
        public Int16 CodeTri { get; set; }

        public virtual Matiere Matiere { get; set; } = new();
        public virtual Classe Classe { get; set; } = new() { Numero = string.Empty }; // Fix: Initialize required property 'Numero'
        public virtual Professeur Professeur { get; set; } = new();
    }
}
