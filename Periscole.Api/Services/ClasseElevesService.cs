using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Interfaces;

namespace Periscole.Bdd.Repositories
{
    public class ClasseElevesService : IClasseElevesService
    {
        private readonly PeriscoleDbContext _context;

        public ClasseElevesService(PeriscoleDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AffectationEleveClasseAsync(int anneeScoId, int classeId, int eleveId)
        {
            var anneeSco = await _context.AnneesSco.FindAsync(anneeScoId);
            var classe = await _context.Classes.FindAsync(classeId);
            var eleve = await _context.Eleves.FindAsync(eleveId);

            if (anneeSco == null || classe == null || eleve == null)
            {
                throw new ArgumentException("Invalid IDs provided for AnneeSco, Classe, or Eleve.");
            }

            var existeDeja = await _context.ClasseEleves.AnyAsync(ec => ec.EleveId == eleveId && ec.AnneeScoId == anneeScoId && ec.ClasseId == classeId);

            if (!existeDeja)
            {
                var nouvelleAffectation = new ClasseEleve
                {
                    AnneeScoId = anneeScoId,
                    //AnneeSco = anneeSco,
                    ClasseId = classeId,
                    //Classe = classe,
                    EleveId = eleveId,
                    //Eleve = eleve
                };


                _context.ClasseEleves.Add(nouvelleAffectation);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("L'élève est déjà affecté à cette classe pour l'année scolaire donnée.");
            }
        }

        /// <summary>
        /// Récupérer tous les élèves d'une classe pour une année scolaire donnée.
        /// </summary>
        /// <param name="classeId">ID Classe</param>
        /// <param name="anneeScoId">ID AnnéeSco</param>
        /// <returns>list élèves</returns>
        public async Task<IList<Eleve>> RecupererElevesClasseAsync(int classeId, int anneeScoId)
        {
            var elevesClasse = await _context.ClasseEleves
                .Where(ec => ec.ClasseId == classeId && ec.AnneeScoId == anneeScoId)
                .Include(ec => ec.Eleve)
                .ToListAsync();
            return elevesClasse.Select(ec => ec.Eleve).ToList();
        }

        //void IClasseElevesRepository.AffectationEleveClasseAsync(int anneeScoId, int classeId, int eleveId)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
