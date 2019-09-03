using COSXML;
using System;
using Microsoft.Extensions.Options;
using COSXML.Auth;
using COSXML.Model.Service;
using COSXML.Utils;
using COSXML.CosException;
using COSXML.Model.Bucket;
using Doublelives.Shared.ConfigModels;

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

        public string GetCurrentBucket()
        {
            var bucket = string.Empty;
            try
            {
                var request = new GetServiceRequest();
                //设置签名有效时长
                request.SetSign(TimeUtils.GetCurrentTime(TimeUnit.SECONDS), 600);
                GetServiceResult result = _cosXmlServer.GetService(request);

                bucket = result.GetResultInfo();
            }
            catch (CosClientException ex)
            {
                Console.WriteLine("CosClientException: " + ex.Message);
            }
            catch (CosServerException ex)
            {
                Console.WriteLine("CosServerException: " + ex.GetInfo());
            }

            return bucket;
        }

        public string GetDoublelivesBucketObjects()
        {
            var result = GetObjectsByBucket(_cosConfig.Bucket);

            return result;
        }

        private string GetObjectsByBucket(string bucket)
        {
            var request = new GetBucketRequest(bucket);
            //设置签名有效时长
            request.SetSign(TimeUtils.GetCurrentTime(TimeUnit.SECONDS), 600);
            GetBucketResult result = _cosXmlServer.GetBucket(request);

            return result.GetResultInfo();
        }
    }
}
