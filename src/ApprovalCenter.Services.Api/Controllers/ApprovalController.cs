using System;
using System.Linq;
using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;
using ApprovalCenter.Domain.General.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalCenter.Services.Api.Controllers
{

    [Route("api/[controller]")]
    public class ApprovalController : ApiController
    {
        private readonly IApprovalAppService _approvalAppService;
        public ApprovalController(IApprovalAppService approvalAppService,
                                     INotificationHandler<DomainNotification> notifications,
                                     IUser user,
                                     IMediatorHandler mediator) : base(notifications, mediator, user)
        {
            _approvalAppService = approvalAppService;
        }


        // GET api/approval
        [HttpGet]
        [Authorize(Policy = "CanReadApprovalData")]
        public IActionResult Get()
        {
            if (AppUser.IsInRole("Integration"))
            {
                return Response(_approvalAppService.GetAll());
            }
            else
            {
                return Response(_approvalAppService.GetAll().Where(e => e.EmailApproval == AppUser.GetUserEmail()));
            }
        }

        // GET api/approval/5
        [HttpGet("{id:guid}")]
        [Authorize(Policy = "CanReadApprovalData")]
        public IActionResult Get(Guid id)
        {
            var approvalViewModel = _approvalAppService.GetById(id);
            return Response(approvalViewModel);
        }

        // POST api/approval
        [HttpPost]
        [Authorize(Policy = "CanWriteApprovalData", Roles = "Integration")]
        public IActionResult Post([FromBody] ApprovalDTO approvalDTO)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }
            _approvalAppService.Insert(approvalDTO);
            return Response(approvalDTO);
        }

        // PUT api/approval/5
        [HttpPut]
        [Authorize(Policy = "CanWriteApprovalData")]
        public IActionResult Put([FromBody] ApprovalDTO approvalDTO)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }
            _approvalAppService.Update(approvalDTO);
            return Response(approvalDTO);
        }

        // DELETE api/approval/5
        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "CanRemoveApprovalData")]
        public IActionResult Delete(Guid id)
        {
            _approvalAppService.Delete(id);
            return Response();
        }

    }
}
