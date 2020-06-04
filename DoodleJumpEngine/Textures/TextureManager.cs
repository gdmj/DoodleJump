using DoodleJumpEngine.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine.Textures
{
    public static class TextureManager
    {
        static List<Texture> textures = new List<Texture>();

        public static void LoadTextures()
        {
            textures.Add(new Texture("Background", Resources.Background));
            textures.Add(new Texture("Doodle", Resources.Doodle));
            textures.Add(new Texture("Ground", Resources.Ground));
            textures.Add(new Texture("Platform", Resources.Platform));
        }

        public static void Resize(double ScaleMult)
        {
            foreach (Texture texture in textures)
            {
                texture.ScaledImage = SimpleGraphics.ResizeImage(texture.StandartImage, Convert.ToInt32(texture.StandartImage.Width * ScaleMult), Convert.ToInt32((texture.StandartImage.Height * ScaleMult)));
                texture.ScaledHitBoxeImage = SimpleGraphics.ResizeImage(texture.hitBoxeImage, Convert.ToInt32(texture.hitBoxeImage.Width * ScaleMult), Convert.ToInt32((texture.hitBoxeImage.Height * ScaleMult)));
            }
        }

        public static Texture GetTextureByName(string name)
        {
            foreach (Texture texture in textures)
            {
                if (texture.Name.ToLower() == name.ToLower())
                    return texture;
            }
            throw new Exception("Texture not found!");
        }


    }
}
