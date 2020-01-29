using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;
using MediatR;

namespace ApprovalCenter.Services.Api.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryAppService _categoryAppService;
        protected CategoryController(ICategoryAppService categoryAppService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) : base(notifications, mediator)
        {
            _categoryAppService = categoryAppService;
        }
    }
}
