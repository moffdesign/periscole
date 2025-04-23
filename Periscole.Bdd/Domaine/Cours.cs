using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    /// <summary>
    /// Classe qui représente un cours
    /// Cours dispensé par un professeur à une classe, à une date donnée, et pour une durée déterminée.
    /// </summary>
    public class Cours : EntBase
    {
        //[Key]
        //public int Id { get; set; }

        public int AnneeScoId { get; set; }
        public int EnseignerId { get; set; }
        public int ProfesseurId { get; set; } = 0;  // cas où c'est un autre prof qui dispense le cours

        public DateTime DateEffective { get; set; }
        public DateTime HeureDebut { get; set; }
        public DateTime HeureFin { get; set; }
    }
}
