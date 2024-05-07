using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CustomProgram
{
    public class Fish : Speed
    {
        int posX, posY;
        int width, height;
        int limit, limitmove;
        public Image fish_image;

        public int PosX
        {
            get { return posX; }
            set { posX = value; }
        }
        public int PosY
        {
            get { return posY; }
            set { posY = value; }
        }
        public int Width
        {
            get { return width; }
            set { width = value; }
        }
        public int Height
        {
            get { return height; }
            set { height = value; }
        }
        public int Limit
        {
            get { return limit; }
            set { limit = value; }
        }
        public int LimitMove
        { 
            get { return limitmove; }
            set {limitmove = value; }
        }
        public Fish()
        {
            Limit = random.Next(100, 500);
            LimitMove = Limit;
            Width = 60;
            Height = 40;
        }
        
        public virtual void FishMove()
        {
            LimitMove--;
            if (LimitMove < 0)
            {
                if (SpeedX < 0)
                {
                    SpeedX = random.Next(2, 5);
                }
                else
                {
                    SpeedX = random.Next(-5, -2);
                }

                if (SpeedY < 0)
                {
                    SpeedY = random.Next(2, 5);
                }
                else
                {
                    SpeedY = random.Next(-5, -2);
                }

                LimitMove = random.Next(100, Limit);
            }
        }
    }
}
