using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Wing.ABPMetroWPF.EntityFramework.Repositories
{
    public abstract class ABPMetroWPFRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<ABPMetroWPFDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected ABPMetroWPFRepositoryBase(IDbContextProvider<ABPMetroWPFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }

    public abstract class ABPMetroWPFRepositoryBase<TEntity> : ABPMetroWPFRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected ABPMetroWPFRepositoryBase(IDbContextProvider<ABPMetroWPFDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }
    }
}
