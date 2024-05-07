using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class LargeFish : Fish
    {
        public Image largefish_image;
        public LargeFish() : base()
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
