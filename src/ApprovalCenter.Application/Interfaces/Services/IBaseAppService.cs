using ApprovalCenter.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Application.Interfaces.Services
{
    public interface IBaseAppService<TDTO, TEntity> : IDisposable where TDTO : class where TEntity : class
    {
        void Insert<TCommand>(TDTO dto) where TCommand : Command;
        void Update<TCommand>(TDTO entity) where TCommand : Command;
        void Delete(Guid id);
        TDTO GetById(Guid id);
        IEnumerable<TDTO> GetAll();
        void InsertRanger(IList<TDTO> dtos);
        void UpdateRanger(IList<TDTO> dtos);
        IList<THistoryData> GetAllHistory<THistoryData>(Guid id) where THistoryData : class;
    }
}
