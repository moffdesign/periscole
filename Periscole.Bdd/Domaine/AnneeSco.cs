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
        public required string AnneeScolaire { get; set; }

        public DateTime? RentreeScolaire { get; set; }
        public DateTime? FinAnneeScolaire { get; set; }

        /// <summary>
        /// Matières/Classes/Profeesseurs enseignés durant l'année scolaire.
        /// </summary>
        public ICollection<Enseigner> Enseignements { get; set; } = [];

        public ICollection<Controle> Controles { get; set; } = [];
        public ICollection<Sequence> Sequences { get; set; } = [];

        public ICollection<Bulletin> Bulletins { get; set; } = [];
    }
}
