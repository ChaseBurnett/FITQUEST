using FITQUEST.Models;

namespace FITQUEST.Repositories
{
    public interface ILeaderBoardRepository
    {
        List<Leaders> GetAll();
    }
}