using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periscole.Bdd.Domaine;
using Periscole.Bdd.Contrats;

namespace Periscole.Bdd.Repositories
{
    public class MatiereRepository : IMatiereRepository
    {
        private readonly PeriscoleDbContext _context;

        public MatiereRepository(PeriscoleDbContext dbContext)
        {
            _context = dbContext;
        }

        public Task<bool> AjouterUneMatiere(Matiere matiere)
        {
            _context.Matieres.Add(matiere);
            return _context.SaveChangesAsync().ContinueWith(task => task.Result > 0);
        }

        public Task<bool> ModifierUneMatiere(Matiere matiere)
        {
            var matiereExistante = _context.Matieres.Find(matiere.Id);
            if (matiereExistante == null)
            {
                //throw new ArgumentException("La matière à modifier n'existe pas.");
                return Task.FromResult(false);
            }

            matiereExistante.Abrev = matiere.Abrev;
            matiereExistante.Libelle = matiere.Libelle;
            matiereExistante.Code = matiere.Code;
            matiereExistante.Couleur = matiere.Couleur;
            matiereExistante.Bulle = matiere.Bulle;

            return _context.SaveChangesAsync().ContinueWith(task => task.Result > 0);

        }

        public Task<IList<Matiere>> RecupererListeDesMatieres()
        {
            var matieres = _context.Matieres.ToList();
            return Task.FromResult<IList<Matiere>>(matieres);

        }

        public Task<Matiere?> RecupererMatiereAyantLePlusFortCoeff(int anneeScoId, int classeId)
        {
            // On récupère la matière ayant le plus fort coefficient pour une classe donnée dans une année scolaire donnée
            var matiereList = _context.Matieres.ToList();
            var enseignerList = _context.Enseigner.ToList();

            var matiere = enseignerList
                .Where(e => e.AnneeScoId == anneeScoId && e.ClasseId == classeId)
                .Join(matiereList,
                    enseigner => enseigner.MatiereId,
                    matiere => matiere.Id,
                    (enseigner, matiere) => new { Matiere = matiere, Coeff = enseigner.Coefficient })
                .OrderByDescending(x => x.Coeff) // On trie par le Coefficient venant de Enseigner
                .Select(x => x.Matiere) // Sélectionner uniquement l'objet Matiere
                .FirstOrDefault();

            return Task.FromResult<Matiere?>(matiere);
        }

        public Task<IList<Matiere>> RecupererMatieresParAnneeSco(int anneeScoId)
        {
            var matiereList = _context.Matieres.ToList();
            var enseignerList = _context.Enseigner.ToList();

            var matieres = enseignerList
                .Where(e => e.AnneeScoId == anneeScoId)
                .Join(matiereList,
                    enseigner => enseigner.MatiereId,
                    matiere => matiere.Id,
                    (enseigner, matiere) => new { matiere })
                .ToList();

            return Task.FromResult<IList<Matiere>>(matieres.Select(m => m.matiere).ToList());
        }

        public Task<IList<Matiere>> RecupererMatieresParClasseEtAnneeSco(int anneeScoId, int classeId)
        {
            var matiereList = _context.Matieres.ToList();
            var enseignerList = _context.Enseigner.ToList();

            var matieres = enseignerList
                .Where(e => e.AnneeScoId == anneeScoId && e.ClasseId == classeId)
                .Join(matiereList,
                    enseigner => enseigner.MatiereId,
                    matiere => matiere.Id,
                    (enseigner, matiere) => new { matiere })
                .ToList();
            return Task.FromResult<IList<Matiere>>([.. matieres.Select(m => m.matiere)]);
        }

        public Task<IList<Matiere>> RecupererMatieresParClasseProfesseurAnneeSco(int anneeScoId, int classeId, int professeurId)
        {
            var matiereList = _context.Matieres.ToList();
            var enseignerList = _context.Enseigner.ToList();

            var matieres = enseignerList
                .Where(e => e.AnneeScoId == anneeScoId && e.ClasseId == classeId && e.ProfesseurId == professeurId)
                .Join(matiereList,
                    enseigner => enseigner.MatiereId,
                    matiere => matiere.Id,
                    (enseigner, matiere) => new { matiere })
                .ToList();
            return Task.FromResult<IList<Matiere>>([.. matieres.Select(m => m.matiere)]);
        }

        public Task<IList<Matiere>> RecupererMatieresParProfesseur(int anneeScoId, int professeurId)
        {
            var matiereList = _context.Matieres.ToList();
            var enseignerList = _context.Enseigner.ToList();

            var matieres = enseignerList
                .Where(e => e.AnneeScoId == anneeScoId && e.ProfesseurId == professeurId)
                .Join(matiereList,
                    enseigner => enseigner.MatiereId,
                    matiere => matiere.Id,
                    (enseigner, matiere) => new { matiere })
                .ToList();
            return Task.FromResult<IList<Matiere>>([.. matieres.Select(m => m.matiere)]);
        }

        public Task<Matiere?> RecupererUneMatiere(int matiereId)
        {
            var matiere = _context.Matieres.Find(matiereId);
            if (matiere == null)
            {
                return Task.FromResult<Matiere?>(null);
            }
            return Task.FromResult<Matiere?>(matiere);
        }

        public Task<bool> SupprimerUneMatiere(int matiereId)
        {
            var matiere = _context.Matieres.Find(matiereId);
            if (matiere == null)
            {
                return Task.FromResult(false);
            }
            // Vérifier si la matière est utilisée dans d'autres entités avant de la supprimer
            _context.Matieres.Remove(matiere);
            return _context.SaveChangesAsync().ContinueWith(task => task.Result > 0);

        }
    }
}
