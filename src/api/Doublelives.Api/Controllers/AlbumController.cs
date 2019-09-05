using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Doublelives.Api.Infrastructure;
using Doublelives.Api.Models.Album;
using Doublelives.Domain.Pictures;
using Doublelives.Service.Pictures;
using Microsoft.AspNetCore.Mvc;

namespace Doublelives.Api.Controllers
{
    [Route("api/album")]
    public class AlbumController : ControllerBase
    {
        private readonly IPictureService _pictureService;
        private readonly IMapper _mapper;

        public AlbumController(IPictureService pictureService, IMapper mapper)
        {
            _pictureService = pictureService;
            _mapper = mapper;
        }

        /// <summary>获取所有的图片链接</summary>
        [HttpGet]
        public IActionResult GetAll()
        {
            var pictures = _pictureService.GetAll();

            var response = _mapper.Map<IEnumerable<PicturesResponse>>(pictures);

            return Ok(response);
        }

        /// <summary>用于引发除以0的异常，测试专用</summary>
        [HttpGet("divideByZero")]
        public IActionResult DivideByZero()
        {
            int x = 1, y = 0;
            var z = x / y;

            return Ok(z);
        }
    }
}