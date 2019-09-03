using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Doublelives.Api.Infrastructure;
using Doublelives.Service.Pictures;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    [Route("api/album")]
    public class AlbumController : ApiControllerBase
    {
        private readonly IPictureService _pictureService;

        public AlbumController(IPictureService pictureService)
        {
            _pictureService = pictureService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var pictures = _pictureService.GetAll();

            return Ok(pictures);
        }

        [HttpGet("divideByZero")]
        public IActionResult DivideByZero()
        {
            int x = 1, y = 0;
            var z = x / y;

            return Ok(z);
        }
    }
}