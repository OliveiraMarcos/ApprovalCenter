using System;
using System.Collections.Generic;
using System.Linq;

namespace AprovationCenter.Domain.Core.Interfaces.Repository
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Attach(TEntity entity);
        void Remove(Guid id);
        TEntity GetById(Guid id);
        IQueryable<TEntity> GetAll();
        void AddRanger(IList<TEntity> entities);
        void AttachRanger(IList<TEntity> entities);
        int SaveChanges();
    }
}
