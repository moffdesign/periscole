using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Periscole.Bdd.Domaine;

namespace Periscole.Bdd.Interfaces
{
    public interface IMatiereRepository
    {
        Task<bool> AjouterUneMatiere(Matiere matiere);

        Task<bool> ModifierUneMatiere(Matiere matiere);

        Task<bool> SupprimerUneMatiere(int matiereId);
        Task<Matiere?> RecupererUneMatiere(int matiereId);
        Task<IList<Matiere>> RecupererListeDesMatieres();
        Task<IList<Matiere>> RecupererMatieresParAnneeSco(int anneeScoId);
        Task<IList<Matiere>> RecupererMatieresParProfesseur(int anneeScoId, int professeurId);

        Task<IList<Matiere>> RecupererMatieresParClasseEtAnneeSco(int anneeScoId, int classeId);

        Task<IList<Matiere>> RecupererMatieresParClasseProfesseurAnneeSco(int anneeScoId, int classeId, int professeurId);
        Task<Matiere?> RecupererMatiereAyantLePlusFortCoeff(int anneeScoId, int classeId);
    }
}
