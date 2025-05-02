using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Historique : BaseEntity
    {
        public required string NomTable { get; set; }
        public required string LigneSvgde { get; set; }     // ligne svgde au format json

    }
}
