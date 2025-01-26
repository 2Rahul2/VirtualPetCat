using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kitty
{
    class WalkingCat(CatWindow cat)
    {
        public void StartMovingCat()
        {
            var walkingCatInterval = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromSeconds(120) };
            var timerTask = new System.Windows.Threading.DispatcherTimer { Interval = TimeSpan.FromMilliseconds(16) };
            double screenWidth = SystemParameters.PrimaryScreenWidth;
            double targetY = SystemParameters.WorkArea.Height - cat.Height + 25;

            double currentX = screenWidth;
            timerTask.Tick += (s, e) =>
            {
                currentX -= 2;
                cat.Left = currentX;
                cat.Top = targetY;

                if (currentX < -100)
                {
                    currentX += screenWidth + 100;
                    timerTask.Stop();
                }
            };
            walkingCatInterval.Tick += (s, e) =>
            {
                timerTask.Start();
            };
            timerTask.Start();
            walkingCatInterval.Start();
        }
    }
}
