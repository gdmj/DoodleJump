using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine.Textures
{
    public class Texture
    {
        public string Name;
        public Image StandartImage;
        private Image scaledImage = null;

        public Texture(string name, Image standartImage)
        {
            Name = name;
            StandartImage = standartImage;
        }

        public Image ScaledImage 
        {
            get 
            {
                if (scaledImage == null)
                    return StandartImage;
                else
                    return scaledImage;
            }
            set => scaledImage = value; 
        }

    }
}
