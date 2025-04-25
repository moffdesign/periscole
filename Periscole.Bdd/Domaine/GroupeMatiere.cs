using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class GroupeMatiere 
    {
        [Key]
        public int Id { get; set; }
        public string Libelle { get; set; } = string.Empty; 
        public Int16 Numero { get; set; }

        public int MatiereId { get; set; }
        public int ClasseId { get; set; }
    }
}
