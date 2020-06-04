using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoodleJumpEngine
{
    public class Controls
    {
        internal bool PLeft = false;
        internal bool PRight = false;
        public void StartLeft()
        {
            PLeft = true;
        }
        public void StartRight()
        {
            PRight = true;
        }
        public void StopLeft()
        {
            PLeft = false;
        }
        public void StopRight()
        {
            PRight = false;
        }
    }
}
