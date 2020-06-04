using DoodleJumpEngine.Interfaces;
using DoodleJumpEngine.Textures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine.Entity
{
    public class Platform : IEntity
    {
        private Texture texture = TextureManager.GetTextureByName("Platform");
        private Point point = new Point(0, 0);

        public Platform()
        {
            Interfaces.Logic.Entity.entities.Add(this);
        }

        public Interfaces.Logic.Entity.EntityType EntityType => Interfaces.Logic.Entity.EntityType.Platform;
        public Texture Texture { get => texture; set => texture = value; }
        public Point Point { get => point; set => point = value; }
    }
}
