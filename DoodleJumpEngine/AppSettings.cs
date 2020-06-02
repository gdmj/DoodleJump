using DoodleJumpEngine.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine
{
    public class AppSettings
    {
        const string JsonPath = "AppSettings.json";

        int windowHeight = Resources.Background.Height;


        public string Version { get => "0.1";}
        public int WindowWidth { get => Convert.ToInt32(windowHeight / 1.5); }
        public int WindowHeight { get => windowHeight; set => windowHeight = value; }

        public void Load()
        {
            AppSettings appSettings = new AppSettings();

            try
            {
                appSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(JsonPath));
            }
            catch
            {

            }

            WindowHeight = appSettings.WindowHeight;

        }

        public void Save()
        {
            string dirfile = JsonPath.Replace(Path.GetFileName(JsonPath), "");



            if (dirfile == "" || Directory.Exists(dirfile))
            {
                File.WriteAllText(JsonPath, JsonConvert.SerializeObject(this));
            }
        }
    }
}
