using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleApp3
{
    class Config
    {
        private const string configFolder = "Resources";
        private const string configFile = "config.json";
        private const string folderPath = configFolder + "/" + configFile;

        public static BotConfig bot;

        static Config()
        {
            if (!Directory.Exists(configFolder))
                Directory.CreateDirectory(configFolder);
            if(!File.Exists(folderPath))
            {
                bot = new BotConfig();
                string json = JsonConvert.SerializeObject(bot, Formatting.Indented);
                File.WriteAllText(folderPath, json);
            }
            else
            {
                string json = File.ReadAllText(folderPath);
                bot = JsonConvert.DeserializeObject<BotConfig>(json);
                
            }

        }
    }
    public struct BotConfig
    {
        public string token;
        public string cmdPrefix;
    }
}