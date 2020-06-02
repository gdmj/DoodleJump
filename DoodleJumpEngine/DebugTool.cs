using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine
{
    public class DebugTool
    {
        Engine engine;

        double fps = 0;
        double tps = 0;
        double mstick = 0;

        public double Fps { get => fps; }
        public double Tps { get => tps; }

        DateTime lastcheckfps = default;
        public void FrameUpdate()
        {
            mstick = (DateTime.Now - lastcheckfps).TotalSeconds * 1000;
            fps = 1000.0 / mstick;
            lastcheckfps = DateTime.Now;
        }
        DateTime lastchecktick = default;
        public void TickUpdate()
        {
            mstick = (DateTime.Now - lastchecktick).TotalSeconds * 1000;
            tps = 1000.0 / mstick;
            lastchecktick = DateTime.Now;
        }

        public DebugTool(Engine engine)
        {
            this.engine = engine;
        }

        public string GetDebugStr()
        {
            return $"===DEBUG===\n" +
                    $"W/H settings: {engine.appSettings.WindowWidth}/{engine.appSettings.WindowHeight}\n" +
                    $"W/H Bitmap:   {engine.bitmap.Width}/{engine.bitmap.Height}\n" +
                    $"Fps: {Math.Round(Fps, 0)}; Tps: {Math.Round(Tps, 0)};\n";
        }
    }
}
