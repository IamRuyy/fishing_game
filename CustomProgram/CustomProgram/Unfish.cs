using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class Unfish : Fish
    {
        public Image unfish_image;
        public Unfish() : base() 
        {
        }

        public override void FishMove()
        {
            base.FishMove(); 
        }
    }
}
