using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.Json;

namespace WebCore.Core.Config
{
    public abstract class IConfig { }
    public static class ConfigCore
    {
        public static readonly string ConfigPath = Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Configs");
        private static List<Type> ServiceConfig { get; set; } = new List<Type>();
        public static Dictionary<string, IConfig> GetConfig { get; set; } = new();
        /// <summary>
        /// 配置文件初始化
        /// </summary>
        public static async void ConfigInit()
        {
            foreach (var config in ServiceConfig)
            {
                Console.WriteLine($"ServiceName:{config.Name}");
                var filepath = Path.Combine(ConfigPath, string.Format($"{config.Name}.json"));
                Console.WriteLine(filepath);
                try
                {
                    IConfig con = (IConfig)JsonSerializer.Deserialize(await LoadingJsonfile(filepath), config);
                    GetConfig.Add(config.Name, con);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
        }
        public static async Task<string> LoadingJsonfile(string path)
        {
            if (File.Exists(path))
            {
                return await File.ReadAllTextAsync(path);
            }
            throw new Exception($"Not find file:{path}");

        }
        public static void AddConfig<T>() where T : IConfig
        {
            ServiceConfig.Add(typeof(T));
        }
        public static T GetConfigItem<T>(this Dictionary<string, IConfig> valuePairs, string ConfigName) where T : IConfig
        {
            if (valuePairs.ContainsKey(ConfigName))
            {
                return valuePairs[ConfigName] as T;
            }
            throw new Exception($"No find {ConfigName}");
        }

    }
}


