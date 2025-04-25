using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class AnneeSco
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Année scolaire (ex. "2021/2022", "2024-2025")
        /// </summary>
        public string? AnneeScolaire { get; set; }

        public DateTime? RentreeScolaire { get; set; }
        public DateTime? FinAnneeScolaire { get; set; }

        //public ICollection<ClasseEleve> ClasseEleves { get; set; } = [];
    }
}
