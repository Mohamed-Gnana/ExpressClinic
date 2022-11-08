using ExpressClinic.SharedKernal.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressClinic.SharedKernal.Abstraction.Interfaces
{
    public interface IReadRepository
    {
        Task<T> GetByIdAsync<T, TId>(TId id) where T : BaseEntity<TId>, IAggregateRoot;
        Task<T> GetAsync<T, TId>(Predicate<T> spec) where T : BaseEntity<TId>, IAggregateRoot;
        Task<List<T>> ListAsync<T, TId>() where T : BaseEntity<TId>, IAggregateRoot;
        Task<List<T>> ListAsync<T, TId>(Predicate<T> spec) where T : BaseEntity<TId>, IAggregateRoot;
        Task<int> CountAsync<T, TId>(Predicate<T> spec) where T : BaseEntity<TId>, IAggregateRoot;
    }
}
