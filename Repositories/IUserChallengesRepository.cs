using FITQUEST.Models;

namespace FITQUEST.Repositories
{
    public interface IUserChallengesRepository
    {
        UserChallenges GetById(int id);

        UserChallenges Add(UserChallenges userChallenges);

        void Update(UserChallenges userChallenges);

        void Delete(int id);

    }
}