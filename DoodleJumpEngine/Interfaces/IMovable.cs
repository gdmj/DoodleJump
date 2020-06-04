using DoodleJumpEngine.Interfaces.Logic;
using DoodleJumpEngine.Textures;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace DoodleJumpEngine.Interfaces
{
    public interface IMovable : IEntity
    {
        Speed Speed { get; set; }

        bool IsFlying { get; set; }
    

    }
}
