using Doublelives.Domain.Pictures;

namespace Doublelives.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAlbumDbContext _albumDbContext;

        public IRepository<Picture> PictureRepository { get; private set; }

        public UnitOfWork(IAlbumDbContext albumDbContext)
        {
            _albumDbContext = albumDbContext;
            PictureRepository = new Repository<Picture>(albumDbContext);
        }

        public void Commit()
        {
            _albumDbContext.SaveChanges();
        }
    }
}
