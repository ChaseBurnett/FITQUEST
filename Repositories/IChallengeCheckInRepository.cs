using FITQUEST.Models;

namespace FITQUEST.Repositories
{
    public interface IChallengeCheckInRepository
    {
        List<UserChallengeCheckIn> GetAllByUserId(int id);
    }
}