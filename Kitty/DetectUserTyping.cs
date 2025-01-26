using Gma.System.MouseKeyHook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace Kitty
{
    class DetectUserTyping
    {
        public CatWindow typingCatWindow;
        private DispatcherTimer typingTimer;
        private IKeyboardEvents keyboardEvents;
        private bool isUserTyping;
        public void StartDetectingTyping()
        {
            typingTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(0.5)};
            typingTimer.Tick += TypingTimerTick;

            keyboardEvents = Hook.GlobalEvents();
            keyboardEvents.KeyDown += UserTyping;
        }
        private void UserTyping(object sender , System.Windows.Forms.KeyEventArgs e)
        {
            if (!isUserTyping)
            {
                isUserTyping = true;
                typingCatWindow?.Show();
                // display typing cat
            }
            typingTimer.Stop();
            typingTimer.Start();

        }

        private void TypingTimerTick(object sender , EventArgs e)
        {
            isUserTyping = false;
            typingTimer.Stop();
            // Disable cat gif
            typingCatWindow?.Hide();
        }
        public void UnSubscribeEvents()
        {
            keyboardEvents.KeyDown -= UserTyping;   
        }
    }
}
