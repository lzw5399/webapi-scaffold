using Doublelives.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Doublelives.Data
{
    public partial interface IAlbumDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;

        int SaveChanges();
    }
}
