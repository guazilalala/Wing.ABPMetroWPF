using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace MyProject.EntityFramework.Repositories
{
    public abstract class MyProjectRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MyProjectDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MyProjectRepositoryBase(IDbContextProvider<MyProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MyProjectRepositoryBase<TEntity> : MyProjectRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MyProjectRepositoryBase(IDbContextProvider<MyProjectDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
