namespace Hackathon.Data.Interfaces
{
    public interface IVisiteurRepository
    {
        Task<IList<string>> ListeEmailVisiteurEvenement(int evenementId);
    }
}
