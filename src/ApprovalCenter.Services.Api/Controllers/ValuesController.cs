using System;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ApprovalCenter.Domain.Core.Interfaces.Bus;
using ApprovalCenter.Domain.Core.Notifications;

namespace ApprovalCenter.Services.Api.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : ApiController
    {
        public ValuesController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {

        }

        // GET api/values
        [HttpGet]
        [Authorize(Policy = "CanReadValuesData")]
        public IActionResult Get()
        {
            return Response(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id:guid}")]
        [Authorize(Policy = "CanReadValuesData")]
        public IActionResult Get(Guid id)
        {
            return Response("value");
        }

        // POST api/values
        [HttpPost]
        [Authorize(Policy ="CanWriteValuesData")]
        public IActionResult Post([FromBody] string value)
        {
            return Response();
        }

        // PUT api/values/5
        [HttpPut]
        [Authorize(Policy = "CanWriteValuesData")]
        public IActionResult Put([FromBody] string value)
        {
            return Response();
        }

        // DELETE api/values/5
        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "CanRemoveValuesData")]
        public IActionResult Delete(Guid id)
        {
            return Response();
        }

        // GET api/values/history/5
        [HttpGet("/history/{id:guid}")]
        [Authorize(Policy = "CanReadValuesData")]
        public IActionResult History(Guid id)
        {
            return Response();
        }
    }
}
