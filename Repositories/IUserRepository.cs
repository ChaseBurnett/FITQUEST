using FITQUEST.Models;

namespace FITQUEST.Repositories
{
    public interface IUserRepository
    {
        User AddUser(User userDetails);

        User GetById(int id);

        void DeleteUser(int id);

        void UpdateUser(User userDetails);
    }
}