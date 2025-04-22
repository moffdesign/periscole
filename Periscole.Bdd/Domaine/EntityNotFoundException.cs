using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Periscole.Bdd.Domaine
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id) : base($"L'entité avec l'ID {id} n'a pas été trouvée.")
        {
        }
    }
}
