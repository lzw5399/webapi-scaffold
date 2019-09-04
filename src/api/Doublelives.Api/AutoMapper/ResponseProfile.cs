using AutoMapper;
using Doublelives.Api.Models.Album;
using Doublelives.Domain.Pictures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.AutoMapper
{
    public class ResponseProfile : Profile
    {
        public ResponseProfile()
        {
            CreateMap<Picture, PicturesResponse>();
        }
    }
}
