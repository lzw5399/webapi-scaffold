using COSXML;
using System;
using Microsoft.Extensions.Options;
using COSXML.Model.Service;
using COSXML.Utils;
using COSXML.CosException;
using COSXML.Model.Bucket;
using Doublelives.Shared.ConfigModels;
using System.Linq;
using System.Collections.Generic;
using System.Web;

namespace Doublelives.Cos
{
    public class TencentCosService : ITencentCosService
    {
        private readonly CosXmlServer _cosXmlServer;
        private readonly TencentCosOptions _cosConfig;

        public TencentCosService(CosXmlServer cosXmlServer, IOptions<TencentCosOptions> options)
        {
            _cosXmlServer = cosXmlServer;
            _cosConfig = options.Value;
        }

        public IEnumerable<string> GetDoublelivesBucketObjects()
        {
            var result = GetObjectsByBucket(_cosConfig.Bucket);

            return result;
        }

        private IEnumerable<string> GetObjectsByBucket(string bucket)
        {
            var request = new GetBucketRequest(bucket);
            //设置签名有效时长
            // request.SetSign(TimeUtils.GetCurrentTime(TimeUnit.SECONDS), 600);
            GetBucketResult response = _cosXmlServer.GetBucket(request);

            var result =  response.listBucket.contentsList
                    .Select(it =>
                    {
                        var encodeValue = HttpUtility.HtmlEncode(it.key);

                        return $"{_cosConfig.BaseUrl}/{encodeValue}";
                    });

            return result;
        }
    }
}
