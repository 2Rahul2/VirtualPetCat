using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kitty
{
    class PeekingCat(CatWindow cat)
    {
        private bool catOnScreen = false;
        public void StartPeeking()
        {
            //var peekingInterval = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(4) };
            var peekingDuration = new System.Windows.Threading.DispatcherTimer { Interval=TimeSpan.FromSeconds(2) };
            peekingDuration.Tick += (s, e) =>
            {
                if (!catOnScreen)
                {
                    // Display cat window
                    Random randInt = new Random();

                    if(randInt.Next(0 ,2) == 0)
                    {
                        SetCatToLeft();
                    }
                    else
                    {
                        SetCatToRight();
                    }
                    cat.Show();
                    catOnScreen = true;
                }
                else
                {
                    // Hide cat window
                    cat.Hide(); 
                    catOnScreen = false;
                }
            };
            peekingDuration.Start();
        }

        private void SetCatPosition(double left , double top)
        {
            cat.Left = left;
            cat.Top = top;
        }
        private void SetCatToLeft()
        {
            cat.RotateImage(90);
            Random random = new Random();
            int randomInt = random.Next(0, (int)(SystemParameters.PrimaryScreenHeight - 50));
            SetCatPosition(-30, randomInt);
        }
        private void SetCatToRight()
        {
            cat.RotateImage(-90);
            Random random = new Random();
            int randomInt = random.Next(0, (int)(SystemParameters.PrimaryScreenHeight - 50));
            SetCatPosition((int)SystemParameters.PrimaryScreenWidth - 70, randomInt);
        }
    }
}
