using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XQT.Core.Common.Extensions;

namespace XQT.Core.Common
{
    /// <summary>
    /// Json配置帮助类
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="environmentName">环境名称</param>
        /// <param name="reloadOnChange">自动更新</param>
        /// <returns></returns>
        public IConfiguration Load(string fileName, string environmentName = "", bool reloadOnChange = false)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "configs");
            if (!Directory.Exists(filePath))
            {
                return null;
            }
            var builder = new ConfigurationBuilder()
                                           .SetBasePath(filePath)
                                           .Add(new JsonConfigurationSource { Path = fileName + ".json", Optional = true, ReloadOnChange = reloadOnChange });
            // 如果有基于环境变量的json文件
            if (environmentName.NotNull())
            {
                builder.Add(new JsonConfigurationSource { Path = $"{fileName}.{environmentName}.json", Optional = true, ReloadOnChange = reloadOnChange });
            }
            return builder.Build();
        }

        /// <summary>
        /// 获取配置信息
        /// </summary>
        /// <typeparam name="T">配置类</typeparam>
        /// <param name="fileName">文件名称</param>
        /// <param name="environmentName">环境名称</param>
        /// <param name="reloadOnChange">自动更新</param>
        /// <returns></returns>
        public T Get<T>(string fileName, string environmentName = "", bool reloadOnChange = false) where T: class
        {
            var configuration = Load(fileName, environmentName, reloadOnChange);
            return (configuration?.Get<T>()) ?? default(T);
        }

        /// <summary>
        /// 绑定实例配置信息
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="instance">实例配置</param>
        /// <param name="environmentName">环境名称</param>
        /// <param name="reloadOnChange">自动更新</param>
        public void Bind(string fileName, object instance, string environmentName = "", bool reloadOnChange = false)
        {
            var configuration = Load(fileName, environmentName, reloadOnChange);
            if(configuration == null || instance == null)
            {
                return;
            }
            configuration.Bind(instance);
        }
    }
}
