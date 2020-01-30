using System;
using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalCenter.Services.Api.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryAppService _categoryAppService;
        protected CategoryController(ICategoryAppService categoryAppService, 
                                     INotificationHandler<DomainNotification> notifications, 
                                     IMediatorHandler mediator) : base(notifications, mediator)
        {
            _categoryAppService = categoryAppService;
        }


        // GET api/category
        [HttpGet("category")]
        //[AllowAnonymous]
        //[Route("category")]
        public IActionResult Get()
        {
            return Response(_categoryAppService.GetAll());
        }

        // GET api/category/5
        [HttpGet("category/{id:guid}")]
        //[Route("category/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var categoryViewModel = _categoryAppService.GetById(id);
            return Response(categoryViewModel);
        }

        // POST api/category
        [HttpPost("category")]
        //[Route("category")]
        public IActionResult Post([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }
            _categoryAppService.Insert(categoryDTO);
            return Response(categoryDTO);
        }

        // PUT api/category/5
        //[HttpPut("category")]
        [Route("category")]
        public IActionResult Put([FromBody] CategoryDTO categoryDTO)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response();
            }
            _categoryAppService.Update(categoryDTO);
            return Response(categoryDTO);
        }

        // DELETE api/category/5
        [HttpDelete("category")]
        //[Route("category")]
        public IActionResult Delete(Guid id)
        {
            _categoryAppService.Delete(id);
            return Response();
        }

    }
}
