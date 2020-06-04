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
        public Image hitBoxeImage;
        private Image scaledhitBoxeImage = null;

        public Texture(string name, Image standartImage)
        {
            Name = name;
            StandartImage = standartImage;

            hitBoxeImage = new Bitmap(standartImage.Width, standartImage.Height);
            using (Graphics graphics = Graphics.FromImage(hitBoxeImage))
            {
                graphics.DrawRectangle(new Pen(Color.White), new Rectangle(0, 0, hitBoxeImage.Width-1, hitBoxeImage.Height-1));
            }

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

        public Image ScaledHitBoxeImage
        {
            get
            {
                if (scaledhitBoxeImage == null)
                    return scaledhitBoxeImage;
                else
                    return scaledhitBoxeImage;
            }
            set => scaledhitBoxeImage = value;
        }

    }
}
