using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine.Interfaces.Logic
{
    public static class Entity
    {
        public enum EntityType
        {
            Player,
            Platform
        }

        public static List<IEntity> entities = new List<IEntity>();

        public static bool IsInHitbox(IEntity entity, Point point)
        {
            if (((point.X > entity.Point.X) && (point.X < entity.Point.X + entity.Texture.ScaledImage.Width)) &&
                ((point.Y > entity.Point.Y) && (point.Y < entity.Point.Y + entity.Texture.ScaledImage.Height)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool IsInHitbox(IEntity entity, IEntity entitymain)
        {
            if (IsInHitbox(entity, new Point(entitymain.Point.X, entitymain.Point.Y)))
                return true;
            if (IsInHitbox(entity, new Point(entitymain.Point.X + entitymain.Texture.ScaledImage.Width, entitymain.Point.Y + entitymain.Texture.ScaledImage.Height)))
                return true;
            return false;
        }
        public static bool IsInHitbox(IEntity entity, IEntity entitymain, Point NewPoint)
        {
            entitymain.Point = NewPoint;
            if (IsInHitbox(entity, new Point(entitymain.Point.X, entitymain.Point.Y)))
                return true;
            if (IsInHitbox(entity, new Point(entitymain.Point.X + entitymain.Texture.ScaledImage.Width, entitymain.Point.Y + entitymain.Texture.ScaledImage.Height)))
                return true;
            return false;
        }




    }
}
