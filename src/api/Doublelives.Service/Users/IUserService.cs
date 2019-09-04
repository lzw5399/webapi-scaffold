using Doublelives.Domain.Users;

namespace Doublelives.Service.Users
{
    public interface IUserService
    {
        string GenerateToken(string id);

        User GetById(string id);
    }
}
