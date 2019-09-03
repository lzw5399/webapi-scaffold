using System;
using System.Collections.Generic;
using System.Text;
using Doublelives.Cos;
using Doublelives.Domain.Pictures;

namespace Doublelives.Service.Pictures
{
    public class PictureService : IPictureService
    {
        private readonly ITencentCosService _cosService;

        public PictureService(ITencentCosService cosService)
        {
            _cosService = cosService;
        }

        public IEnumerable<Picture> GetAll()
        {
            _cosService.GetAllBuckets();

            return null;
        }
    }
}
