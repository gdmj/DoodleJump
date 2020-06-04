using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine.Interfaces.Logic
{
    public static class Movable
    {
        public const float Gravity = 0.4f;

        public static List<IMovable> movables = new List<IMovable>();

        public enum Direction
        {
            Up,
            Right,
            Down,
            Left
        }

        public static void Move(IMovable movable, Direction direction)
        {
            switch (direction)
            {
                case Direction.Up:
                    movable.Speed.SpeedY -= movable.Speed.Acceleration;
                    break;
                case Direction.Right:
                    movable.Speed.SpeedX += movable.Speed.Acceleration;
                    break;
                case Direction.Down:
                    movable.Speed.SpeedY += movable.Speed.Acceleration;
                    break;
                case Direction.Left:
                    movable.Speed.SpeedX -= movable.Speed.Acceleration;
                    break;
            }
        }


        public static void Move(double DeltaTime)
        {
            foreach (IMovable movable in movables)
            {
                Point NewPoint = new Point(movable.Point.X + (int)Math.Round(movable.Speed.SpeedX * DeltaTime), movable.Point.Y + (int)Math.Round(movable.Speed.SpeedY * DeltaTime));
                
                foreach (IEntity entitie in Entity.entities)
                {
                        if (Entity.IsInHitbox(entitie, movable, NewPoint))
                        {
                            if ((movable.EntityType == Entity.EntityType.Player) &&
                                (entitie.EntityType == Entity.EntityType.Platform) &&
                                (entitie.Point.Y > NewPoint.Y + movable.Texture.ScaledImage.Height-1))
                            {
                                NewPoint.Y = entitie.Point.Y - movable.Texture.ScaledImage.Height;
                            }
                            else
                            {
                                if ((movable.EntityType == Entity.EntityType.Player) &&
                                (entitie.EntityType == Entity.EntityType.Platform) &&
                                (entitie.Point.Y >= movable.Point.Y))
                                {
                                    if (movable.Speed.SpeedY >= 0)
                                    {
                                        movable.Speed.SpeedY = -movable.Speed.MaxSpeedY;
                                        NewPoint = new Point(movable.Point.X + (int)Math.Round(movable.Speed.SpeedX * DeltaTime), movable.Point.Y + (int)Math.Round(movable.Speed.SpeedY * DeltaTime));
                                    }
                                }
                            }

                            
                        }
                }
                if (NewPoint.X > Textures.TextureManager.GetTextureByName("Background").ScaledImage.Width)
                {
                    NewPoint.X = 0 - movable.Texture.ScaledImage.Width + 1;
                }
                if (NewPoint.X + movable.Texture.ScaledImage.Width < 0)
                {
                    NewPoint.X = Textures.TextureManager.GetTextureByName("Background").ScaledImage.Width - 1;
                }

                movable.Point = NewPoint;
            }
        }

        public static void GravityMove()
        {
            foreach (IMovable movable in movables)
            {
                if (!movable.IsFlying)
                {
                    movable.Speed.SpeedY += Gravity;
                }
            }
        }
    }
}
