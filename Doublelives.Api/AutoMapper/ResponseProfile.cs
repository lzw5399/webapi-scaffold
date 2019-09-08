using AutoMapper;
using Doublelives.Api.Models.Album;
using Doublelives.Api.Models.Users;
using Doublelives.Domain.Pictures;
using Doublelives.Domain.Users;
using Doublelives.Domain.Users.Dto;
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
            CreateMap<User, UserResponse>();
            CreateMap<CurrentUserDto, UserResponse>();
        }
    }
}
