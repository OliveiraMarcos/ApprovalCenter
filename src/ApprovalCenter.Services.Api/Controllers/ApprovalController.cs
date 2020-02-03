using System;
using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalCenter.Services.Api.Controllers
{
    public class ApprovalController : ApiController
    {
        private readonly IApprovalAppService _approvalAppService;
        protected ApprovalController(IApprovalAppService approvalAppService,
                                     INotificationHandler<DomainNotification> notifications, 
                                     IMediatorHandler mediator) : base(notifications, mediator)
        {
            _approvalAppService = approvalAppService;
        }


        // GET api/approval
        [HttpGet("approval")]
        //[AllowAnonymous]
        //[Route("approval")]
        public IActionResult Get()
        {
            return Response(_approvalAppService.GetAll());
        }

        // GET api/approval/5
        [HttpGet("approval/{id:guid}")]
        //[Route("approval/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var approvalViewModel = _approvalAppService.GetById(id);
            return Response(approvalViewModel);
        }

        // POST api/approval
        [HttpPost("approval")]
        //[Route("approval")]
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
        [HttpPut("approval")]
        //[Route("approval")]
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
        [HttpDelete("approval")]
        //[Route("approval")]
        public IActionResult Delete(Guid id)
        {
            _approvalAppService.Delete(id);
            return Response();
        }

    }
}
