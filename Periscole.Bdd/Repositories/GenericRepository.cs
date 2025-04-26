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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly PeriscoleDbContext _databaseContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(PeriscoleDbContext context)
        {
            _databaseContext = context;
            _dbSet = context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entityToDelete = await _dbSet.FindAsync(id);

            if (entityToDelete != null)
            {
                _dbSet.Remove(entityToDelete);
                await SaveAsync();
            }
        }

        /// <summary>
        /// Récupère un élément par son identifiant.
        /// Dans le cas où l'élément n'est pas trouvé, une exception est levée. Il faut donc faire un try/catch dans le code appelant.
        /// </summary>
        /// <param name="id">pk de l'entité recherché</param>
        /// <returns>entité trouvé</returns>
        /// <exception cref="EntityNotFoundException">exception si non trouvé</exception>
        public async Task<T> GetByIdAsync(int id)
        {
            //return await _dbSet.FindAsync(id);
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
            {
                // Gérer le cas où l'entité n'est pas trouvée.
                // Par exemple, lancer une exception, retourner une valeur par défaut,
                // enregistrer un événement, etc.
                //return null; // Ou une autre indication d'absence
                throw new EntityNotFoundException(id);
            }
            return entity;
        }

        /// <summary>
        /// Récupère tous les éléments de la table.
        /// la liste de retour peut être nulle mais elle ne peut contenir d'éléments null
        /// </summary>
        /// <param name="tracked"></param>
        /// <returns></returns>
        public async Task<List<T>> GetAllAsync(bool tracked = true)
        {
            IQueryable<T> query = _dbSet;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
