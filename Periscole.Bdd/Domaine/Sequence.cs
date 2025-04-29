using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Sequence : BaseEntity
    {
        public string? Libelle { get; set; }
        public int Numero { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }

        public string? Observation { get; set; }
    }
}
