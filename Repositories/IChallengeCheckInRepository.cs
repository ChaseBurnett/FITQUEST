using FITQUEST.Models;

namespace FITQUEST.Repositories
{
    public interface IChallengeCheckInRepository
    {
        List<UserChallengeCheckIn> GetAllByUserId(int id);

        ChallengeCheckIn Add(ChallengeCheckIn challengeCheckIn);

        void Update(ChallengeCheckIn challengeCheckIn, int id);

        void Delete(int id);
    }
}