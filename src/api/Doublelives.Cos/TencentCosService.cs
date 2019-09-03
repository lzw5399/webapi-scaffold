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
using Microsoft.Extensions.Logging;

namespace Doublelives.Cos
{
    public class TencentCosService : ITencentCosService
    {
        private readonly CosXml _cosXml;
        private readonly TencentCosOptions _cosConfig;
        private readonly ILogger<TencentCosService> _logger;

        public TencentCosService(CosXml cosXml, IOptions<TencentCosOptions> options, ILogger<TencentCosService> logger)
        {
            _cosXml = cosXml;
            _cosConfig = options.Value;
            _logger = logger;
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
            request.SetSign(TimeUtils.GetCurrentTime(TimeUnit.SECONDS), _cosConfig.DurationSecond);
            GetBucketResult response = _cosXml.GetBucket(request);

            var result = response.listBucket.contentsList
                    .Select(it =>
                    {
                        var encodeValue = HttpUtility.HtmlEncode(it.key);

                        return $"{_cosConfig.BaseUrl}/{encodeValue}";
                    });

            return result;
        }
    }
}
