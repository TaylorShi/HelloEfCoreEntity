using System;
using System.Collections.Generic;
using System.Text;
using Tesla.Framework.Infrastructure.Core.Algorithms.Snowflake;

namespace Tasla.Snowflake.Console
{
    public class DefaultSnowflakeRuler : ISnowflakeRuler
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public SnowflakeOptions GetRulerInfo()
        {
            // 默认仅使用流水号
            return new SnowflakeOptions { SequenceBits = 22 };
        }
    }
}
