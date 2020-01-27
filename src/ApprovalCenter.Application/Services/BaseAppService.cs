using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Core.Commands;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Interfaces.Repository;
using ApprovalCenter.Domain.Core.Interfaces.Repository.EventSourcing;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApprovalCenter.Application.Services
{
    public abstract class BaseAppService<TDTO, TEntity> : IDisposable, IBaseAppService<TDTO, TEntity> where TDTO : class where TEntity : class
    {
        protected readonly IMapper _mapper;
        protected readonly IRepositoryBase<TEntity> _baseRepository;
        protected readonly IEventStoreRepository _eventStoreRepository;
        protected readonly IMediatorHandler Bus;

        public BaseAppService(IMapper mapper,
                              IRepositoryBase<TEntity> baseRepository,
                              IMediatorHandler bus,
                              IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _baseRepository = baseRepository;
            Bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }
        public abstract void Delete(Guid id);

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TDTO> GetAll()
        {
            return _baseRepository.GetAll().ProjectTo<TDTO>(_mapper.ConfigurationProvider);
        }

        public IList<THistoryData> GetAllHistory<THistoryData>(Guid id) where THistoryData : class
        {
            throw new NotImplementedException();
        }

        public TDTO GetById(Guid id)
        {
            return _mapper.Map<TDTO>(_baseRepository.GetById(id));
        }

        public virtual void Insert<TCommand>(TDTO dto) where TCommand : Command
        {
            var registerCommand = _mapper.Map<TCommand>(dto);
            Bus.SendCommand(registerCommand);
        }

        public void InsertRanger(IList<TDTO> dtos)
        {
            throw new NotImplementedException();
        }

        public virtual void Update<TCommand>(TDTO dto) where TCommand : Command
        {
            var updateCommand = _mapper.Map<TCommand>(dto);
            Bus.SendCommand(updateCommand);
        }

        public void UpdateRanger(IList<TDTO> dtos)
        {
            throw new NotImplementedException();
        }
    }
}
