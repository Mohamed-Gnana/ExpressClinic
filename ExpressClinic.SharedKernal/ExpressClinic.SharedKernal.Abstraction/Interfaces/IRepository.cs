using ExpressClinic.SharedKernal.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Abstraction.Interfaces
{
    public interface IRepository
    {
        Task<T> AddAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
        Task<T> UpdateAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
        Task DeleteAsync<T, TId>(T entity) where T : BaseEntity<TId>, IAggregateRoot;
    }
}
