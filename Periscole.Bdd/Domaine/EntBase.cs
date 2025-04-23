using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class EntBase
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateSaisie { get; set; }
        public string SaisiePar { get; set; } = "dbuser";
        public DateTime DateMaj { get; set; }
        public string MajPar { get; set; } = "dbuser";
        public DateTime DateCloture { get; set; }
        public string CloturePar { get; set; } = "dbuser";

        //public string? UserKey { get; set; }
    }
}
