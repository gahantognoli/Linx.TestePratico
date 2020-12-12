using Linx.Core.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Linx.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        public IUnitOfWork UnitOfWork { get; }
        Task Adicionar(T entity);
        void Atualizar(T entity);
        void Remover(Guid Id);
        Task<T> ObterPorId(Guid id);
        Task<IEnumerable<T>> ObterTodos();
    }
}
