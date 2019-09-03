using System;
using System.Collections.Generic;
using System.Text;

namespace Doublelives.Cos
{
    public interface ITencentCosService
    {
        string GetCurrentBucket();

        string GetDoublelivesBucketObjects();
    }
}
