using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class Matiere : Entity
    {
        //public int GroupeMatiereId { get; set; }

        /// <summary>
        /// Années/Classes/Matières enseignées durant l'année scolaire.
        /// qui enseigne quelle matière dans quelle classe
        /// </summary>
        public ICollection<Enseigner> Enseignements { get; set; } = [];
    }
}
