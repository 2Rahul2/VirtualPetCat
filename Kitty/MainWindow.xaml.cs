using Gma.System.MouseKeyHook;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kitty
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DetectUserTyping detectUserTyping;
        private NotifyIcon notifyIcon;
        public MainWindow()
        {
            InitializeComponent();
            SystemTray();
            Loaded += Window_Loaded;
            detectUserTyping = new DetectUserTyping();
            detectUserTyping.StartDetectingTyping();
        }
        private void SystemTray()
        {
            var iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/images/kitty.ico"))?.Stream;
            notifyIcon = new NotifyIcon
            {
                Icon = new Icon(iconStream),
                Visible = true,
                Text = "Virtual Pet Cat"
            };
            var contextMenu = new ContextMenuStrip();
            var showMenuItem = new ToolStripMenuItem("Show");
            //var hideMenuItem = new ToolStripMenuItem("Hide");
            var exitMenuItem = new ToolStripMenuItem("Exit");

            showMenuItem.Click += (s, e) => ShowMainWindow();
            exitMenuItem.Click += (s, e) => ExitApplication();
            //hideMenuItem.Click += (s, e) => HideMainWindow();

            contextMenu.Items.Add(showMenuItem);
            contextMenu.Items.Add(exitMenuItem);
            //contextMenu.Items.Add(hideMenuItem);

            notifyIcon.ContextMenuStrip = contextMenu;
        }
        private void ShowMainWindow()
        {
            this.Show();
            this.WindowState = WindowState.Normal;
            this.Activate();
        }

        private void HideMainWindow()
        {
            //this.WindowState = WindowState.Minimized;
            this.Hide();
        }

        private void ExitApplication()
        {
            notifyIcon.Visible = false; 
            notifyIcon.Dispose();
            System.Windows.Application.Current.Shutdown(); 
        }
        private void Window_Loaded(object sender , RoutedEventArgs e)
        {
            // adding walking cat
            AddCat kittyCat = new AddCat(this , "pack://application:,,,/images/walking-cat.gif",0,0);
            kittyCat.CreateWalkingCat();
            // adding peeking cat

            AddCat peekingKittyCat = new AddCat(this, "pack://application:,,,/images/peeking-kitty.gif", 0, 0);
            peekingKittyCat.CreatePeekingCat();

            // typing cat
            // <Image gif:ImageBehavior.AnimatedSource="images/cute-cat-white.gif" />
            //MessageBox.Show(typingCatTop.ToString() + "    " +taskbarHeight.ToString()+"    " + workAreaHeight.ToString());
            AddCat typingCat = new AddCat(this, "pack://application:,,,/images/typing-cat.gif");
            typingCat.CreateTypingCat(ref detectUserTyping);
        }
        protected override void OnClosed(EventArgs e)
        {
            detectUserTyping?.UnSubscribeEvents();
            base.OnClosed(e);
        }
    }
}