using DoodleJumpEngine.Interfaces;
using DoodleJumpEngine.Interfaces.Logic;
using DoodleJumpEngine.Textures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine.Entity
{
    class Doodle : IEntity, IMovable
    {
        private Texture texture;
        private Point point;
        private Speed speed;
        private bool isFlying = false;

        public Doodle()
        {
            texture = TextureManager.GetTextureByName("Doodle");
            point = new Point(0, 0);
            speed = new Speed(0f, 0f, 10f, 13f, 0.5f);
            isFlying = false;
            Interfaces.Logic.Entity.entities.Add(this);
            Interfaces.Logic.Movable.movables.Add(this);
        }

        public Interfaces.Logic.Entity.EntityType EntityType => Interfaces.Logic.Entity.EntityType.Player;
        public Texture Texture { get => texture; set => texture = value; }
        public Point Point { get => point; set => point = value; }


        public Speed Speed { get => speed; set => speed = value; }
        public bool IsFlying { get => isFlying; set => isFlying = value; }

    }
}
