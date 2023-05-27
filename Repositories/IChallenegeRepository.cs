using FITQUEST.Models;

namespace FITQUEST.Repositories
{
    public interface IChallenegeRepository
    {
        List<Challenge> GetAll();
        List<Challenge> GetAllByTier(int tier);

        Challenge GetById(int id);
        void Update(Challenge challenge);
    }
}