using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Core.Commands;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Interfaces.Repository;
using ApprovalCenter.Domain.Core.Interfaces.Repository.EventSourcing;

namespace ApprovalCenter.Application.Services
{
    public abstract class ServiceAppBase<TObject, TEntity> : IDisposable, IServiceAppBase<TObject, TEntity> where TObject : class where TEntity : class
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryBase<TEntity> _baseRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler Bus;

        public ServiceAppBase(IMapper mapper,
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

        public virtual void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public virtual IEnumerable<TObject> GetAll()
        {
            return _baseRepository.GetAll().ProjectTo<TObject>(_mapper.ConfigurationProvider);
        }

        public IList<THistoryData> GetAllHistory<THistoryData>(Guid id) where THistoryData : class
        {
            throw new NotImplementedException();
        }

        public virtual TObject GetById(Guid id)
        {
            return _mapper.Map<TObject>(_baseRepository.GetById(id));
        }

        public void Insert<TCommand>(TObject entity) where TCommand : Command, new()
        {
            var registerCommand = _mapper.Map<TCommand>(entity);
            Bus.SendCommand(registerCommand);
        }

        public abstract void Insert(TObject entity);

        public void InsertRanger(IList<TObject> entities)
        {
            throw new NotImplementedException();
        }

        public virtual void Update<TCommand>(TObject entity) where TCommand : Command, new()
        {
            var updateCommand = _mapper.Map<TCommand>(entity);
            Bus.SendCommand(updateCommand);
        }

        public abstract void Update(TObject entity);

        public void UpdateRanger(IList<TObject> entities)
        {
            throw new NotImplementedException();
        }
    }
}
