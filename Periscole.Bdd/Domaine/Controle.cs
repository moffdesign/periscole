using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Controle : BaseEntity
    {
        public int ClasseId { get; set; }
        public int TypeControle { get; set; }
        public int Numero { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        
        public string? Observation { get; set; }
    }
}
