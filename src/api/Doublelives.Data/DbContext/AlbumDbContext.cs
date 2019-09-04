using Doublelives.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Doublelives.Data.Mapping;

namespace Doublelives.Data
{
    public class AlbumDbContext : DbContext, IAlbumDbContext
    {
        public AlbumDbContext(DbContextOptions opts)
        : base(opts)
        {
        }

        public new DbSet<TEntity> Set<TEntity>() where TEntity : EntityBase
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PictureEmtityMapping());

            base.OnModelCreating(modelBuilder);
        }
    }
}
