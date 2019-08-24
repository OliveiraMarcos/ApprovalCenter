using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Thundera.Domain.Core.Interfaces.Bus;
using Thundera.Domain.Core.Notifications;

namespace Thundera.Services.Api.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        public ValuesController(INotificationHandler<DomainNotification> notifications,
            IMediatorHandler mediator) : base(notifications, mediator)
        {

        }

        // GET api/values
        [HttpGet]
        [Route("values")]
        public IActionResult Get()
        {
            return Response(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet]
        [Route("values/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            return Response("value");
        }

        // POST api/values
        [HttpPost]
        [Route("values")]
        public IActionResult Post([FromBody] string value)
        {
            return Response();
        }

        // PUT api/values/5
        [HttpPut]
        [Route("values")]
        public IActionResult Put([FromBody] string value)
        {
            return Response();
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("values")]
        public IActionResult Delete(Guid id)
        {
            return Response();
        }

        // GET api/values/history/5
        [HttpGet]
        [Route("values/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            return Response();
        }
    }
}
