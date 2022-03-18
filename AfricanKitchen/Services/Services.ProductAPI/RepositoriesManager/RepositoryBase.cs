using Microsoft.EntityFrameworkCore;
using Services.ProductAPI.Contracts.IRepositoryManager;
using Services.ProductAPI.DbContexts;
using System.Linq.Expressions;

namespace Services.ProductAPI.RepositoriesManager
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext RepositoryContext { get; set; }
        public RepositoryBase(ApplicationDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public void Create(T entity) =>

          RepositoryContext.Set<T>().Add(entity);


        public void Delete(T entity) =>

           RepositoryContext?.Set<T>().Remove(entity);


        public IQueryable<T> FindAll() =>
            RepositoryContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindAllWithTracking(Expression<Func<T, bool>> predicate) =>
            RepositoryContext.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryContext.Set<T>()
            .Where(expression)
            .AsNoTracking();

        public IQueryable<T> FindByConditionWithTracking(Expression<Func<T, bool>> expression) =>
           RepositoryContext.Set<T>()
            .Where(expression);


        public void Update(T entity) =>
            RepositoryContext.Set<T>().Update(entity);
    }
}
