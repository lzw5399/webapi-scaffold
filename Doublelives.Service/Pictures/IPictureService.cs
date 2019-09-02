using System;
using System.Collections.Generic;
using System.Text;
using Doublelives.Domain.Pictures;

namespace Doublelives.Service.Pictures
{
    public interface IPictureService
    {
        IEnumerable<Picture> GetAll();
    }
}
