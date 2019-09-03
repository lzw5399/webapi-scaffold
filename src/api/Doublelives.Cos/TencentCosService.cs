using COSXML;
using System;
using Microsoft.Extensions.Options;
using COSXML.Auth;
using COSXML.Model.Service;
using COSXML.Utils;

namespace Doublelives.Cos
{
    public class TencentCosService : ITencentCosService
    {
        private readonly CosXmlServer _cosXmlServer;

        public TencentCosService(CosXmlServer cosXmlServer)
        {
            _cosXmlServer = cosXmlServer;
        }

        public void GetAllBuckets()
        {
            try
            {
                var request = new GetServiceRequest();
                //设置签名有效时长
                request.SetSign(TimeUtils.GetCurrentTime(TimeUnit.SECONDS), 600);
                //执行请求
                GetServiceResult result = _cosXmlServer.GetService(request);
                //请求成功
                Console.WriteLine(result.GetResultInfo());
            }
            catch (COSXML.CosException.CosClientException clientEx)
            {
                //请求失败
                Console.WriteLine("CosClientException: " + clientEx.Message);
            }
            catch (COSXML.CosException.CosServerException serverEx)
            {
                //请求失败
                Console.WriteLine("CosServerException: " + serverEx.GetInfo());
            }
        }
    }
}
