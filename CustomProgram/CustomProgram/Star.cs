using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class Star : Fish
    {
        public Image star_image;
        public Star() : base() 
        {
            SpeedX *= 2;
            SpeedY *= 2;
        }

        public override void FishMove()
        {
            base.FishMove();
        }

    }
}
