using ExpressClinic.SharedKernal.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Abstraction.IRepositories
{
    public interface ICommandsRepository<T, TId> where T : BaseEntity<TId>, IAggregateRoot
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
