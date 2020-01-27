using ApprovalCenter.Domain.Category.Commands;
using ApprovalCenter.Domain.Category.Entities;
using ApprovalCenter.Domain.Category.Events;
using ApprovalCenter.Domain.Category.Interfaces;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;
using ApprovalCenter.Domain.General.CommandHandlers;
using ApprovalCenter.Domain.General.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ApprovalCenter.Domain.Category.CommandHandlers
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<InsertNewCategoryCommand, bool>,
        IRequestHandler<UpdateCategoryCommand, bool>,
        IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly IMediatorHandler Bus;
        private readonly ICategoryRepository _categoryRepository;
        public CategoryCommandHandler(ICategoryRepository categoryRepository, 
                                      IUnitOfWork uow, 
                                      IMediatorHandler bus, 
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _categoryRepository = categoryRepository;
            Bus = bus;
        }

        public Task<bool> Handle(InsertNewCategoryCommand request, CancellationToken cancellationToken)
        {

            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var category = new CategoryEntity(Guid.NewGuid()
                                              , request.Name
                                              , request.Description
                                              , DateTime.Now
                                              , DateTime.Now);

            _categoryRepository.Add(category);

            if (Commit())
            {
                Bus.RaiseEvent(new CategoryInsertEvent(category.Id
                                              , category.Name
                                              , category.Description
                                              , category.DateCreate
                                              , category.DateEdit));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            var category = new CategoryEntity(Guid.NewGuid()
                                              , request.Name
                                              , request.Description
                                              , DateTime.Now
                                              , DateTime.Now);

            _categoryRepository.Attach(category);

            if (Commit())
            {
                Bus.RaiseEvent(new CategoryUpdateEvent(category.Id
                                              , category.Name
                                              , category.Description
                                              , category.DateCreate
                                              , DateTime.Now));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                NotifyValidationErrors(request);
                return Task.FromResult(false);
            }
            _categoryRepository.Remove(request.Id);

            if (Commit())
            {
                Bus.RaiseEvent(new CategoryDeleteEvent(request.Id));
            }
            return Task.FromResult(true);
        }
    }
}
