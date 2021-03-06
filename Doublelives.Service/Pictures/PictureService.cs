﻿using System;
using System.Collections.Generic;
using System.Text;
using Doublelives.Cos;
using Doublelives.Domain.Pictures;
using Microsoft.AspNetCore.Http;

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
            return _cosService.GetDoublelivesBucketPictures();
        }

        public void Upload(string userId, List<IFormFile> files)
        {
            throw new NotImplementedException();
        }
    }
}
