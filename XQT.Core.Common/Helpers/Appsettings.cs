using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XQT.Core.Common
{
    /// <summary>
    /// appsettings.json操作类
    /// </summary>
    public class Appsettings
    {
        private static IConfiguration _configuration;

        public Appsettings(string contentPath)
        {
            string path = "appsettings.json";
            // 如果你配置文件是根据环境变量分开的,可以这样写
            // path = $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json";
            _configuration = new ConfigurationBuilder()
                             .SetBasePath(contentPath)
                             //.AddJsonFile(path, false, true)
                             .Add(new JsonConfigurationSource { Path = path, Optional = false, ReloadOnChange = true }) // 这样可以直接读目录里的json文件,而不是bin文件夹下的,所以不用修改复制属性
                             .Build();
        }

        public Appsettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// 封装要操作的字符串
        /// </summary>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static string? app(params string[] sections)
        {
            try
            {
                if (sections.Any())
                {
                    string key = string.Join(":", sections);
                    return _configuration[key];
                }
            }
            catch (Exception ex)
            {
                
            }
            return string.Empty;
        }

        /// <summary>
        /// 递归获取配置信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sections"></param>
        /// <returns></returns>
        public static List<T> app<T>(params string[] sections) 
        {
            List<T> list = new List<T>();
            try
            {
                string key = string.Join(":", sections);
                _configuration.Bind(key, list);
            }
            catch (Exception ex)
            {

            }
            return list;
        }
    }
}
