using System;
using System.Collections.Generic;
using Thundera.Domain.Core.Commands;

namespace Thundera.Application.Interfaces.Services
{
    public interface IServiceAppBase<TObject, TEntity> where TObject : class where TEntity : class
    {
        void Insert<TCommand>(TObject entity) where TCommand : Command, new();
        void Update<TCommand>(TObject entity) where TCommand : Command, new();
        void Insert(TObject entity);
        void Update(TObject entity);
        void Delete(Guid id);
        TObject GetById(Guid id);
        IEnumerable<TObject> GetAll();
        void InsertRanger(IList<TObject> entities);
        void UpdateRanger(IList<TObject> entities);
        IList<THistoryData> GetAllHistory<THistoryData>(Guid id) where THistoryData : class;
    }
}
