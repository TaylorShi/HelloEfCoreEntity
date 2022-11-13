using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Infrastructure.Core.Algorithms.Snowflake;

namespace Tasla.Snowflake.Console
{
    class TestSnowflakeRuler : ISnowflakeRuler
    {
        public SnowflakeOptions GetRulerInfo()
        {
            //数据中心编号03 服务编号129 实例编号9
            int workId = (3 << 12) | (129 << 4) | 9;
            return new SnowflakeOptions { WorkerId = workId, WorkerIdBits = 16, SequenceBits = 6 };
        }
    }
}
