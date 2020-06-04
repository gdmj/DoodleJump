using DoodleJumpEngine.Interfaces;
using DoodleJumpEngine.Interfaces.Logic;
using DoodleJumpEngine.Properties;
using DoodleJumpEngine.Textures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DoodleJumpEngine
{
    public class Engine : IDisposable
    {
        public const double DefaultTPS = 30;
        public const double DefaultFPS = 30;

        public AppSettings appSettings = new AppSettings();
        public DebugTool debugTool;
        public Controls controls = new Controls();


        public delegate void Drawer(Image frame);

        internal Drawer drawer;
        internal Graphics graphics;
        internal Bitmap bitmap;

        internal Entity.Doodle doodle;
        internal List<Entity.Ground> grounds = new List<Entity.Ground>();
        internal List<Entity.Platform> platforms = new List<Entity.Platform>();

        bool isLaunched = false;

        public bool IsLaunched { get => isLaunched; }


        public double DeltaTimeFPS
        {
            get
            {
                if ((DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds < 10)
                    return 1;
                return DefaultFPS / debugTool.Fps;
            }
        }
        public double DeltaTimeTPS
        {
            get
            {
                if ((DateTime.Now - Process.GetCurrentProcess().StartTime).TotalSeconds < 10)
                    return 1;
                return DefaultTPS / debugTool.Tps;
            }
        }

        public Engine(Drawer drawer, AppSettings appSettings)
        {
            TextureManager.LoadTextures();
            TextureManager.Resize((double)appSettings.WindowHeight / 1080.0);

            doodle = new Entity.Doodle();
            doodle.Point = new Point(appSettings.WindowWidth / 2, appSettings.WindowHeight / 2);


            for (int x = 0; x <= appSettings.WindowWidth; x += TextureManager.GetTextureByName("Ground").ScaledImage.Height)
            {

                Entity.Ground ground = new Entity.Ground();
                ground.Point = new Point(x, appSettings.WindowHeight - ground.Texture.ScaledImage.Height);
                grounds.Add(ground);
            }

            Entity.Platform platform = new Entity.Platform();
            platform.Point = new Point(appSettings.WindowWidth / 2, appSettings.WindowHeight - 200);
            platforms.Add(platform);


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

                Interfaces.Logic.Movable.GravityMove();

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
                debugTool.FrameUpdate();



                if (controls.PLeft)
                    Movable.Move(doodle, Movable.Direction.Left);
                if (controls.PRight)
                    Movable.Move(doodle, Movable.Direction.Right);


                if (doodle.Speed.SpeedX != 0)
                {
                    if (!controls.PRight && doodle.Speed.SpeedX > 0)
                    {
                        Movable.Move(doodle, Movable.Direction.Left);
                    }
                    if (!controls.PLeft && doodle.Speed.SpeedX < 0)
                    {
                        Movable.Move(doodle, Movable.Direction.Right);
                    }
                }



                Movable.Move(DeltaTimeFPS);

                drawer(GetFrame());

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

            foreach (Entity.Ground ground in grounds)
            {

                graphics.DrawImage(ground.Texture.ScaledImage, ground.Point);
            }

            foreach (Entity.Platform platform in platforms)
            {

                graphics.DrawImage(platform.Texture.ScaledImage, platform.Point);
            }


            graphics.DrawImage(doodle.Texture.ScaledImage, doodle.Point);
            graphics.DrawImage(doodle.Texture.ScaledHitBoxeImage, doodle.Point);

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

        public void Dispose()
        {
            Interfaces.Logic.Entity.entities = new List<IEntity>();
            Interfaces.Logic.Movable.movables = new List<IMovable>();
        }
    }
}
