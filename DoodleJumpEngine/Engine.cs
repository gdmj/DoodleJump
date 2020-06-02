using DoodleJumpEngine.Properties;
using DoodleJumpEngine.Textures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoodleJumpEngine
{
    public class Engine
    {
        public const int DefaultTPS = 30;
        public const int DefaultFPS = 60;

        public AppSettings appSettings = new AppSettings();
        public DebugTool debugTool;


        public delegate void Drawer(Image frame);

        internal Drawer drawer;
        internal Graphics graphics;
        internal Bitmap bitmap;

        bool isLaunched = false;

        public bool IsLaunched { get => isLaunched; }

        public Engine(Drawer drawer, AppSettings appSettings)
        {
            TextureManager.LoadTextures();
            TextureManager.Resize( (double)appSettings.WindowHeight / 1080.0);
            this.drawer = drawer;
            this.appSettings = appSettings;
            debugTool = new DebugTool(this);
        }


        DateTime lasttick = default;
        void Worker()
        {
            while (isLaunched)
            {
                debugTool.TickUpdate();

                while (((DateTime.Now - lasttick).TotalSeconds * 1000) < 1000 / DefaultTPS)
                    Thread.Sleep(1);
                lasttick = DateTime.Now;
            }
        }

        DateTime lastfps = default;
        void DWorker()
        {
            while (isLaunched)
            {
                drawer(GetFrame());
                debugTool.FrameUpdate();

                while (((DateTime.Now - lastfps).TotalSeconds * 1000) < 1000 / DefaultFPS)
                    Thread.Sleep(1);
                lastfps = DateTime.Now;
            }
        }

        Image GetFrame()
        {
            bitmap = new Bitmap(appSettings.WindowWidth, appSettings.WindowHeight);
            graphics = Graphics.FromImage(bitmap);

            //TODO: govnocode for drawing frame
            graphics.DrawImage(TextureManager.GetTextureByName("Background").ScaledImage, new Point(0, 0));

            graphics.Dispose();
            return bitmap;
        }




        public void Start()
        {
            isLaunched = true;
            Task.Run(Worker);
            Task.Run(DWorker);
        }

        public void Stop()
        {
            isLaunched = false;
        }
    }
}
