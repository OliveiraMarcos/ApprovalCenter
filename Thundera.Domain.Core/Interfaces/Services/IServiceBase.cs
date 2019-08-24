using System;
using System.Collections.Generic;

namespace Thundera.Domain.Core.Interfaces.Services
{
    public interface IServiceBase<TEntity> : IDisposable where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> GetAll();
        void InsertRanger(IList<TEntity> entities);
        void UpdateRanger(IList<TEntity> entities);
        IList<THistoryData> GetAllHistory<THistoryData>(Guid id) where THistoryData : class;
    }
}
