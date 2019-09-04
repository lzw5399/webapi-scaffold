using Doublelives.Domain.Pictures;
using Doublelives.Domain.Users;

namespace Doublelives.Data
{
    public interface IUnitOfWork
    {
        IRepository<Picture> PictureRepository { get; }

        IRepository<User> UserRepository { get; }

        void Commit();
    }
}
