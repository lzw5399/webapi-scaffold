using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doublelives.Api.Infrastructure;
using Doublelives.Service.Pictures;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IPictureService _pictureService;

        public ValuesController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            _pictureService.GetAll();

            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
