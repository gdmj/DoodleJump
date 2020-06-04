using DoodleJumpEngine.Textures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine.Interfaces
{
    public interface IEntity
    {
        Logic.Entity.EntityType EntityType { get; }
        Texture Texture { get; set; }
        Point Point { get; set; }

    }
}
