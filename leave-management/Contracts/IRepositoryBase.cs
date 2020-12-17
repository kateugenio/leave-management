using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace leave_management.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<ICollection<T>> FindAll();

        Task<T> FindById(int id);

        Task<bool> isExists(int id);

        Task<bool> Create(T entity);

        Task<bool> Update(T entity);

        Task<bool> Delete(T entity);

        Task<bool> Save();
    }

    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> FindAll(
            // This allows us to write lamda expressions
            // setting to null allows this to be optional in case no lambda is passed in
            Expression<Func<T, bool>> expression = null,
            // This allows to specify order like `q => q.OrderBy(q => q.Id)`
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            // This allows us to include/eager load other tables in the query
            List<string> includes = null
            );

        Task<T> Find(Expression<Func<T, bool>> expression, List<string> includes = null);

        Task<bool> isExists(Expression<Func<T, bool>> expression = null);

        Task Create(T entity);

        // B/c Update and Delete don't have async methods, so updating this to a void function
        void Update(T entity);

        void Delete(T entity);

        //Task Save();
    }
}
