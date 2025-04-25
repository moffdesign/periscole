using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Parametre
    {
        [Key]
        public int Id { get; set; }

        public required string Code { get; set; } = string.Empty;
        public string? Libelle { get; set; } = string.Empty;
        public string? Parametres { get; set; } = string.Empty;
    }
}
