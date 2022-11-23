using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasla.Snowflake.Console
{
    internal class ConfigHelper
    {
        public static IConfigurationRoot GetConfigurationRoot()
        {
            // 创建配置构建器
            IConfigurationBuilder builder = new ConfigurationBuilder();
            // 添加Json文件数据源
            builder.AddJsonFile("appsettings.json");
            // 构建配置获取配置根
            IConfigurationRoot configurationRoot = builder.Build();
            return configurationRoot;
        }
    }
}
