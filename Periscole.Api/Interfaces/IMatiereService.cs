using Periscole.Bdd.Domaine;

namespace Periscole.Api.Interfaces
{
    public interface IMatiereService
    {
        Task<Result<bool>> AjouterUneMatiere(Matiere matiere);

        Task<Result<bool>> ModifierUneMatiere(Matiere matiere);

        Task<Result<bool>> SupprimerUneMatiere(int matiereId);
        Task<Result<Matiere>> RecupererUneMatiere(int matiereId);
        Task<Result<IList<Matiere>>> RecupererListeDesMatieres();
        Task<Result<IList<Matiere>>> RecupererMatieresParAnneeSco(int anneeScoId);
        Task<Result<IList<Matiere>>> RecupererMatieresParProfesseur(int anneeScoId, int professeurId);
        
        Task<Result<IList<Matiere>>> RecupererMatieresParClasseEtAnneeSco(int anneeScoId, int classeId);
        
        Task<Result<IList<Matiere>>> RecupererMatieresParClasseProfesseurAnneeSco(int anneeScoId, int classeId, int professeurId);
        Task<Result<Matiere>> RecupererMatiereAyantLePlusFortCoeff(int anneeScoId, int classeId);


    }
}
