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
    public class ClasseEleveRepository : IClasseEleveRepository
    {
        private readonly PeriscoleDbContext _context;

        public ClasseEleveRepository(PeriscoleDbContext dbContext)
        {
            _context = dbContext;
        }


        public async Task<bool> AffecterEleveDansClasseAsync(int anneeScoId, int classeId, int eleveId)
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
                return true; // Indique que l'affectation a réussi
            }
            else
            {
                throw new InvalidOperationException("L'élève est déjà affecté à cette classe pour l'année scolaire donnée.");
            }
            
        }

        public async Task<List<Eleve>> RecupererElevesParClasseAsync(int anneeScoId, int classeId)
        {
            var elevesClasse = await _context.ClasseEleves
               .Where(ec => ec.ClasseId == classeId && ec.AnneeScoId == anneeScoId)
               .Include(ec => ec.Eleve)
               .ToListAsync();

            // Fix for CS8619: Ensure nullability is handled by filtering out null values
            return [.. elevesClasse.Select(ec => ec.Eleve)
                .Where(eleve => eleve != null) // Filter out null values
                .Cast<Eleve>()];
        }

        public async Task<Result<bool>> SupprimerAffectationEleveAsync(int anneeScoId, int classeId, int eleveId)
        {
            var affectation = await _context.ClasseEleves.FirstOrDefaultAsync(ec =>
            ec.EleveId == eleveId &&
            ec.AnneeScoId == anneeScoId &&
            ec.ClasseId == classeId);

            if (affectation != null)
            {
                _context.ClasseEleves.Remove(affectation);
                await _context.SaveChangesAsync();
                return Result<bool>.Ok(true); // Indique que la suppression a réussi
            }
            else
            {
                return Result<bool>.Fail("AFFECTATION_NOT_FOUND", "Aucune affectation trouvée pour cet élève.", 404);
            }
            
        }
    }
}
