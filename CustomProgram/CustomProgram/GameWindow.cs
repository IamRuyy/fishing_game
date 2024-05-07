using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomProgram
{
    public partial class GameWindow : Form
    {
        float timeLeft = 60f;
        int get = 0;
        int spawnTime;
        int spawnLimit;
        int highestScore = 0;

        List<Fish> fish_list = new List<Fish>();
        List<LargeFish> largefish_list = new List<LargeFish>();
        List<Star> star_list = new List<Star>();
        List<Unfish> unfish1_list = new List<Unfish>();
        List<Unfish> unfish2_list = new List<Unfish>();
        Random random = new Random();
        private Dictionary<LargeFish, int> largeFishClickCount = new Dictionary<LargeFish, int>();
        private Dictionary<Star, int> starClickCount = new Dictionary<Star, int>();
        Timer fishTimer = new Timer();
        Timer largeFishTimer = new Timer();
        Timer unFish1Timer = new Timer();
        Timer unFish2Timer = new Timer();
        Timer starTimer = new Timer();

        Image[] fish_images = { Properties.Resources.fish1__1_, Properties.Resources.fish2__1_ };
        Image[] largefish_images = { Properties.Resources.fish3_2pts };
        Image[] unfish1_images = { Properties.Resources.unfish4__1_ };
        Image[] unfish2_images = { Properties.Resources.unfish2__1_ };
        Image[] star_images = { Properties.Resources.star__1_ };
        public GameWindow()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            highestScore = Properties.Settings.Default.HighestScore;
          
            fishTimer.Interval = 1000;
            largeFishTimer.Interval = 5000;
            unFish1Timer.Interval = 15000;
            unFish2Timer.Interval = 18000;
            starTimer.Interval = 25000;

            fishTimer.Tick += FishTimer_Tick;
            largeFishTimer.Tick += LargeFishTimer_Tick;
            unFish1Timer.Tick += Unfish1Timer_Tick;
            unFish2Timer.Tick += Unfish2Timer_Tick;
            starTimer.Tick += StarTimer_Tick;


            fishTimer.Start();
            largeFishTimer.Start();
            unFish1Timer.Start();
            unFish2Timer.Start();
            starTimer.Start();  
        }

        private void TickEvent(object sender, EventArgs e)
        {
            timeLeft -= 0.05f;
            timeLabel.Text = "Time Left: " + timeLeft.ToString("#.#") + "second";
            getLabel.Text = "Number of fish: " + get;
            HighScoreLabel.Text = "Highest score: " + highestScore.ToString("000");

            if (fish_list.Count < spawnLimit)
            {
                if (spawnTime <= 0)
                {
                    MakeFish();
                }
            }

            if (largefish_list.Count < spawnLimit)
            {
                if (spawnTime <= 0)
                {
                    MakeLargeFish();

                }
            }

            if (unfish1_list.Count < spawnLimit)
            {
                

                if (spawnTime <= 0)
                {
                    MakeUnfish1();
                }
            }

            if (unfish2_list.Count < spawnLimit)
            {
                

                if (spawnTime <= 0)
                {
                    MakeUnfish2();

                }
            }
            if (star_list.Count < spawnLimit)
            {
              

                if (spawnTime <= 0)
                {
                    MakeStar();

                }
            }

            foreach (Fish fish in fish_list)
            {
                fish.FishMove();
                fish.PosX += fish.SpeedX;
                if (fish.PosX < 0 || fish.PosX + fish.Width > this.ClientSize.Width)
                {
                    fish.SpeedX = -fish.SpeedX;
                    if (fish.PosX < 0)
                    {
                        fish.PosX = fish.PosX + 10;
                    }
                    else if (fish.PosX + fish.Width > this.ClientSize.Width)
                    {
                        fish.PosX = fish.PosX - 10;
                    }
                }

                fish.PosY += fish.SpeedY;
                if (fish.PosY < 0 || fish.PosY + fish.Height > this.ClientSize.Height - 100)
                {
                    fish.SpeedY = -fish.SpeedY;
                    if (fish.PosY < 0)
                    {
                        fish.PosY = fish.PosY + 10;
                    }
                    else if (fish.PosY + fish.Height > this.ClientSize.Height - 100)
                    {
                        fish.PosY = fish.PosY - 10;
                    }
                }
            }
                foreach (LargeFish largeFish in largefish_list)
                {
                    largeFish.FishMove();
                    largeFish.PosX += largeFish.SpeedX;
                    if (largeFish.PosX < 0 || largeFish.PosX + largeFish.Width > this.ClientSize.Width)
                    {
                        largeFish.SpeedX = -largeFish.SpeedX;
                        if (largeFish.PosX < 0)
                        {
                            largeFish.PosX = largeFish.PosX + 10;
                        }
                        else if (largeFish.PosX + largeFish.Width > this.ClientSize.Width)
                        {
                            largeFish.PosX = largeFish.PosX - 10;
                        }
                    }

                    largeFish.PosY += largeFish.SpeedY;
                    if (largeFish.PosY < 0 || largeFish.PosY + largeFish.Height > this.ClientSize.Height - 100)
                    {
                        largeFish.SpeedY = -largeFish.SpeedY;
                        if (largeFish.PosY < 0)
                        {
                            largeFish.PosY = largeFish.PosY + 10;
                        }
                        else if (largeFish.PosY + largeFish.Height > this.ClientSize.Height - 100)
                        {
                            largeFish.PosY = largeFish.PosY - 10;
                        }
                    }

                }
            foreach (Unfish unFish1 in unfish1_list)
            {
                unFish1.FishMove();
                unFish1.PosX += unFish1.SpeedX;
                if (unFish1.PosX < 0 || unFish1.PosX + unFish1.Width > this.ClientSize.Width)
                {
                    unFish1.SpeedX = -unFish1.SpeedX;
                    if (unFish1.PosX < 0)
                    {
                        unFish1.PosX = unFish1.PosX + 10;
                    }
                    else if (unFish1.PosX + unFish1.Width > this.ClientSize.Width)
                    {
                        unFish1.PosX = unFish1.PosX - 10;
                    }
                }

                unFish1.PosY += unFish1.SpeedY;
                if (unFish1.PosY < 0 || unFish1.PosY + unFish1.Height > this.ClientSize.Height - 100)
                {
                    unFish1.SpeedY = -unFish1.SpeedY;
                    if (unFish1.PosY < 0)
                    {
                        unFish1.PosY = unFish1.PosY + 10;
                    }
                    else if (unFish1.PosY + unFish1.Height > this.ClientSize.Height - 100)
                    {
                        unFish1.PosY = unFish1.PosY - 10;
                    }
                }

            }
            foreach (Unfish unFish2 in unfish2_list)
            {
                unFish2.FishMove();
                unFish2.PosX += unFish2.SpeedX;
                if (unFish2.PosX < 0 || unFish2.PosX + unFish2.Width > this.ClientSize.Width)
                {
                    unFish2.SpeedX = -unFish2.SpeedX;
                    if (unFish2.PosX < 0)
                    {
                        unFish2.PosX = unFish2.PosX + 10;
                    }
                    else if (unFish2.PosX + unFish2.Width > this.ClientSize.Width)
                    {
                        unFish2.PosX = unFish2.PosX - 10;
                    }
                }

                unFish2.PosY += unFish2.SpeedY;
                if (unFish2.PosY < 0 || unFish2.PosY + unFish2.Height > this.ClientSize.Height - 100)
                {
                    unFish2.SpeedY = -unFish2.SpeedY;
                    if (unFish2.PosY < 0)
                    {
                        unFish2.PosY = unFish2.PosY + 10;
                    }
                    else if (unFish2.PosY + unFish2.Height > this.ClientSize.Height - 100)
                    {
                        unFish2.PosY = unFish2.PosY - 10;
                    }
                }
                foreach (Star star in star_list)
                {
                    star.FishMove();
                    star.PosX += star.SpeedX;
                    if (star.PosX < 0 || star.PosX + star.Width > this.ClientSize.Width)
                    {
                        star.SpeedX = -star.SpeedX;
                        if (star.PosX < 0)
                        {
                            star.PosX = star.PosX + 10;
                        }
                        else if (star.PosX + star.Width > this.ClientSize.Width)
                        {
                            star.PosX = star.PosX - 10;
                        }
                    }

                    star.PosY += star.SpeedY;
                    if (star.PosY < 0 || star.PosY + star.Height > this.ClientSize.Height - 100)
                    {
                        star.SpeedY = -star.SpeedY;
                        if (star.PosY < 0)
                        {
                            star.PosY = star.PosY + 10;
                        }
                        else if (star.PosY + star.Height > this.ClientSize.Height - 100)
                        {
                            star.PosY = star.PosY - 10;
                        }
                    }
                }
            }

            if (timeLeft <= 0)
            {
                EndGame();
            }
            this.Invalidate();

        }

        private void ClickEvent(object sender, EventArgs e)
        {
            
            MouseEventArgs mouse = (MouseEventArgs)e;
            foreach (Fish fish in fish_list.ToList())
            {
                if (mouse.X >= fish.PosX && mouse.Y >= fish.PosY && mouse.X < fish.PosX + fish.Width && mouse.Y < fish.PosY + fish.Height)
                {
                    fish_list.Remove(fish);
                    get++;
                }
            }

            foreach (LargeFish largeFish in largefish_list.ToList())
            {
                if (mouse.X >= largeFish.PosX && mouse.Y >= largeFish.PosY && mouse.X < largeFish.PosX + largeFish.Width && mouse.Y < largeFish.PosY + largeFish.Height)
                {
                    if (!largeFishClickCount.ContainsKey(largeFish))
                    {
                        largeFishClickCount[largeFish] = 1;
                    }
                    else
                    {
                        largeFishClickCount[largeFish]++;
                        if (largeFishClickCount[largeFish] >= 2)
                        {
                            largefish_list.Remove(largeFish);
                            get += 2;
                        }
                    }
                }
            }

            foreach (Unfish unfish1 in unfish1_list.ToList())
            {
                if (mouse.X >= unfish1.PosX && mouse.Y >= unfish1.PosY && mouse.X < unfish1.PosX + unfish1.Width && mouse.Y < unfish1.PosY + unfish1.Height)
                {
                    unfish1_list.Remove(unfish1);
                    get--;
                }
            }

            foreach (Unfish unfish2 in unfish2_list.ToList())
            {
                if (mouse.X >= unfish2.PosX && mouse.Y >= unfish2.PosY && mouse.X < unfish2.PosX + unfish2.Width && mouse.Y < unfish2.PosY + unfish2.Height)
                {
                    unfish2_list.Remove(unfish2);
                    get -= 3;
                }
            }

            foreach (Star star in star_list.ToList())
            {
                if (mouse.X >= star.PosX && mouse.Y >= star.PosY && mouse.X < star.PosX + star.Width && mouse.Y < star.PosY + star.Height)
                {
                    if (!starClickCount.ContainsKey(star))
                    {
                        starClickCount[star] = 1;
                    }
                    else
                    {
                        starClickCount[star]++;
                        if (starClickCount[star] >= 5)
                        {
                            star_list.Remove(star);
                            get += 10;
                            starClickCount.Remove(star);
                        }
                    }
                }

            }
        }
        private void PaintEvent(object sender, PaintEventArgs e)
        {
            ImageAnimator.UpdateFrames();
            foreach (Fish fish in fish_list)
            {
                e.Graphics.DrawImage(fish.fish_image, fish.PosX, fish.PosY, fish.Height, fish.Width);
            }
            foreach (LargeFish largeFish in largefish_list)
            {
                e.Graphics.DrawImage(largeFish.largefish_image, largeFish.PosX, largeFish.PosY, largeFish.Height, largeFish.Width); 
            }
            foreach (Unfish unfish1 in unfish1_list)
            {
                e.Graphics.DrawImage(unfish1.unfish_image, unfish1.PosX, unfish1.PosY, unfish1.Height, unfish1.Width);
            }
            foreach (Unfish unfish2 in unfish2_list)
            {
                e.Graphics.DrawImage(unfish2.unfish_image, unfish2.PosX, unfish2.PosY, unfish2.Height, unfish2.Width);
            }
            foreach (Star star in star_list)
            {
                e.Graphics.DrawImage(star.star_image, star.PosX, star.PosY, star.Height, star.Width);
            }
        }

        private void MakeFish()
        {
            int i = random.Next(fish_images.Length);
            Fish newFish = new Fish();
            newFish.fish_image = fish_images[i];
            newFish.PosX = random.Next(50, this.ClientSize.Width - 100);
            newFish.PosY = random.Next(50, this.ClientSize.Height - 100);
            fish_list.Add(newFish);
            ImageAnimator.Animate(newFish.fish_image, this.OnFrameChangedHandler);

           
        }
        private void FishTimer_Tick(object sender, EventArgs e)
        {
            MakeFish();
        }
        private void MakeLargeFish()
        {
            int i = random.Next(largefish_images.Length);
            LargeFish newLargeFish = new LargeFish();
            newLargeFish.largefish_image = largefish_images[i];
            newLargeFish.PosX = random.Next(50, this.ClientSize.Width - 100);
            newLargeFish.PosY = random.Next(50, this.ClientSize.Height - 100);
            largefish_list.Add(newLargeFish);
            ImageAnimator.Animate(newLargeFish.largefish_image, this.OnFrameChangedHandler);

           
            
        }
        private void LargeFishTimer_Tick(object sender, EventArgs e)
        {
            MakeLargeFish();
        }
        private void MakeUnfish1()
        {
            int i = random.Next(unfish1_images.Length);
            Unfish newUnfish1 = new Unfish();
            newUnfish1.unfish_image = unfish1_images[i];
            newUnfish1.PosX = random.Next(50, this.ClientSize.Width - 100);
            newUnfish1.PosY = random.Next(50, this.ClientSize.Height - 100);
            unfish1_list.Add(newUnfish1);
            ImageAnimator.Animate(newUnfish1.unfish_image, this.OnFrameChangedHandler);

            
        }
        private void Unfish1Timer_Tick (object sender, EventArgs e)
        {
            MakeUnfish1();
        }
        private void MakeUnfish2()
        {
            int i = random.Next(unfish2_images.Length);
            Unfish newUnfish2 = new Unfish();
            newUnfish2.unfish_image = unfish2_images[i];
            newUnfish2.PosX = random.Next(50, this.ClientSize.Width - 100);
            newUnfish2.PosY = random.Next(50, this.ClientSize.Height - 100);
            unfish2_list.Add(newUnfish2);
            ImageAnimator.Animate(newUnfish2.unfish_image, this.OnFrameChangedHandler);

            
        }
        private void Unfish2Timer_Tick(object sender, EventArgs e)
        {
            MakeUnfish2();
        }
        private void MakeStar()
        {
            int i = random.Next(star_images.Length);
            Star newStar = new Star();
            newStar.star_image = star_images[i];
            newStar.PosX = random.Next(50, this.ClientSize.Width - 100);
            newStar.PosY = random.Next(50, this.ClientSize.Height - 100);
            star_list.Add(newStar);
            ImageAnimator.Animate(newStar.star_image, this.OnFrameChangedHandler);

           
        }
        private void StarTimer_Tick(object sender, EventArgs e)
        {
            MakeStar();
        }
        private void OnFrameChangedHandler(object sender, EventArgs e)
        {
            this.Invalidate();
        }


        private void GameRestart()
        {
            this.Invalidate();
            fish_list.Clear();
            largefish_list.Clear();
            unfish1_list.Clear();
            unfish2_list.Clear();
            star_list.Clear();

            get = 0;
            timeLeft = 60f;
            spawnTime = 0;
            timeLabel.Text = "Time Left: 00";
            getLabel.Text = "Number of fish: 0";
            HighScoreLabel.Text = "Highest score: " + highestScore.ToString("000");

            Timer.Start();
        }

        private void EndGame()
        {
            Timer.Stop();
            MessageBox.Show("Congratulations !!!, You have got " + get + " fishes. Click Ok to restart the game.");

            if (get > highestScore)
            {
                highestScore = get;
                Properties.Settings.Default.HighestScore = highestScore;
                Properties.Settings.Default.Save();
            }
            GameRestart();
        }

        private void GameWindow_Load(object sender, EventArgs e)
        {

        }

        private void getLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
