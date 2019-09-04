using Doublelives.Domain.Pictures;

namespace Doublelives.Data
{
    public interface IUnitOfWork
    {
        IRepository<Picture> PictureRepository { get; }

        void Commit();
    }
}
