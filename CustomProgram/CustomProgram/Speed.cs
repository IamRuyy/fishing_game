using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomProgram
{
    public class Speed
    {
        int speedX, speedY;
        public int SpeedX
        {
            get { return speedX; }
            set { speedX = value; }
        }
        public int SpeedY
        {
            get { return speedY; }
            set { speedY = value; }
        }
        protected Random random = new Random();
        
        public Speed()
        {
            SpeedX = random.Next(-5, 5);
            SpeedY = random.Next(-5, 5);    
        }
    }
}
