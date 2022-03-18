using System.Linq.Expressions;

namespace Services.ProductAPI.Contracts.IRepositoryManager
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
        void Delete(T entity);
        IQueryable<T> FindAll();
        IQueryable<T> FindAllWithTracking(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        IQueryable<T> FindByConditionWithTracking(Expression<Func<T, bool>> expression);
        void Update(T entity);
    }
}
