using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfAnimatedGif;

namespace Kitty
{
    /// <summary>
    /// Interaction logic for CatWindow.xaml
    /// </summary>
    public partial class CatWindow : Window
    {
        public CatWindow(Window owner ,string gifPath , double left , double top , double width , double height)
        {

            InitializeComponent();
            this.Owner = owner;
            Left = left;
            Top = top;
            var kittyImage = new BitmapImage();
            kittyImage.BeginInit();
            kittyImage.UriSource = new Uri(gifPath);
            kittyImage.EndInit();
            ImageBehavior.SetAnimatedSource(CatImage , kittyImage);
            CatImage.Height = height;
            CatImage.Width = width;
            Canvas.SetLeft(CatImage , left);
            Canvas.SetTop(CatImage , top);

        }
        public void RotateImage(int rotateAngle)
        {
            RotateTransform rotateTransform = new RotateTransform(rotateAngle);
            // Set the rotation origin to the center of the image
            rotateTransform.CenterX = CatImage.Width / 2;
            rotateTransform.CenterY = CatImage.Height / 2;
            CatImage.RenderTransform = rotateTransform;
        }
    }
}
