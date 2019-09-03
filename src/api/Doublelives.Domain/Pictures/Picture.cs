using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Domain.Pictures
{
    public class Picture
    {
        public Picture()
        {
            Owner = "Unknown";
        }

        public DateTime LastModified { get; set; }

        public string Owner { get; set; }

        /// <summary>
        /// 文件大小，单位是byte
        /// </summary>
        public long Size { get; set; }

        public string Url { get; set; }
    }
}
