using FITQUEST.Models;

namespace FITQUEST.Repositories
{
    public interface IChallenegeRepository
    {
        List<Challenge> GetAll();
        List<Challenge> GetAllByTier(int tier);
        void Update(Challenge challenge);
    }
}