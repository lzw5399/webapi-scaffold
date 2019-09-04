using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Doublelives.Api.Models.Album
{
    public class PicturesResponse
    {
        public string Uploader { get; set; }

        public long Size { get; set; }

        public string Url { get; set; }
    }
}
