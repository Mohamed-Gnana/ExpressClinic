using ExpressClinic.SharedKernal.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Abstraction.IRepositories
{
    public interface IQueriesRepository<T, TId> where T : BaseEntity<TId>, IAggregateRoot
    {
        Task<T?> GetByIdAsync(TId id);
        Task<T?> GetAsync(Expression<Func<T, bool>> spec);
        Task<List<T>> ListAsync();
        Task<List<T>> ListAsync(Expression<Func<T, bool>> spec);
        Task<int> CountAsync(Expression<Func<T, bool>> spec);
    }
}
