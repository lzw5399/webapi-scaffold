using COSXML;
using Doublelives.Core.Configs;
using System;
using Microsoft.Extensions.Options;
using COSXML.Auth;

namespace Doublelives.Cos
{
    public class TencentCosService : ITencentCosService
    {
        private readonly CosXmlConfig _cosXmlConfig;
        private readonly CosXmlServer _cosXmlServer;
        private readonly QCloudCredentialProvider _cosCredentialProvider;

        public TencentCosService(IOptions<TencentCosOptions> cosOptions)
        {
            var cosConfig = cosOptions.Value;

            _cosXmlConfig = new CosXmlConfig.Builder()
                .IsHttps(false)
                .SetAppid(cosConfig.AppId)
                .SetRegion(cosConfig.Region)
                .SetDebugLog(true)
                .Build();
            _cosCredentialProvider = new DefaultQCloudCredentialProvider(
                cosConfig.SecretId,
                cosConfig.SecretKey,
                cosConfig.DurationSecond);
            _cosXmlServer = new CosXmlServer(_cosXmlConfig, _cosCredentialProvider);
        }

        public void GetAllByBucket(string bucket)
        {
            throw new NotImplementedException();
        }
    }
}
