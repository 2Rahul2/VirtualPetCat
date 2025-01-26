using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kitty
{
    class AddCat
    {
        private Window window;
        private string imagePath;
        private double left;
        private double top;
        public AddCat(Window window , string imagePath, double left=0, double top=0)
        {
            this.window = window;  
            this.imagePath = imagePath;
            this.left = left;
            this.top = top;
        }
        public void CreateWalkingCat()
        {
            CatWindow cat = new CatWindow(this.window, imagePath, left, top ,80 ,120);
            WalkingCat walkingCat = new WalkingCat(cat);
            cat.Show();
            walkingCat.StartMovingCat();
        }
        public void CreatePeekingCat()
        {
            CatWindow cat = new CatWindow(this.window , imagePath ,left , top ,100 ,100); 
            PeekingCat peekingCat = new PeekingCat(cat);
            peekingCat.StartPeeking();
        }
        public void CreateTypingCat(ref DetectUserTyping detectUserTyping)
        {
            double typingCatLeft = SystemParameters.PrimaryScreenWidth -300;
            double screenHeight = SystemParameters.PrimaryScreenHeight;
            double workAreaHeight = SystemParameters.WorkArea.Height;

            double taskbarHeight = screenHeight - workAreaHeight;    // not really needed

            double typingCatTop = workAreaHeight - 165;
            CatWindow cat = new CatWindow(this.window, imagePath, typingCatLeft, typingCatTop, 300, 220);
            detectUserTyping.typingCatWindow = cat;
        }
    }
}
