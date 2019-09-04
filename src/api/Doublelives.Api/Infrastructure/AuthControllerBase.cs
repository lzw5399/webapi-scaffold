using Doublelives.Domain.WorkContext;
using Doublelives.Service.Users;
using Doublelives.Service.WorkContextAccess;
using IdentityModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Infrastructure
{
    public class AuthControllerBase : ControllerBase
    {
        protected WorkContext WorkContext { get; }

        public AuthControllerBase(IWorkContextAccessor workContextAccessor)
        {
            WorkContext = workContextAccessor.WorkContext;
        }
    }
}
