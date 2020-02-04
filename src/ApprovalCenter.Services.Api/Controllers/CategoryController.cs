using System;
using ApprovalCenter.Application.DataTranferObject;
using ApprovalCenter.Application.Interfaces.Services;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApprovalCenter.Services.Api.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryAppService _categoryAppService;
        public CategoryController(ICategoryAppService categoryAppService, 
                                     INotificationHandler<DomainNotification> notifications, 
                                     IMediatorHandler mediator) : base(notifications, mediator)
        {
            _categoryAppService = categoryAppService;
        }

        // GET api/category
        [HttpGet]
        //[AllowAnonymous]
        public IActionResult Get()
        {
            return Response(_categoryAppService.GetAll());
        }

        // GET api/category/5
        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var categoryViewModel = _categoryAppService.GetById(id);
            return Response(categoryViewModel);
        }

        // POST api/category
        [HttpPost]
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
        [HttpPut]
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
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _categoryAppService.Delete(id);
            return Response();
        }

    }
}
