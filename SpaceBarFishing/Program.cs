using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceBarFishing
{
   class Program
   {
      const UInt32 WM_KEYDOWN = 0x0100;
      const int VK_Space = 0x20;

      static Random ran = new Random();

      static int RandomSleepTime = 0;

      [DllImport("user32.dll")]
      public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

      [DllImport("user32.dll")]
      static extern bool PostMessage(IntPtr hWnd, UInt32 Msg, int wParam, int lParam);

      [STAThread]
      static void Main()
      {
         WelcomeMessage();

         while (true)
         {
            RandomSleepTime = ran.Next(700, 1300);

            Thread.Sleep(RandomSleepTime);

            SendSpace();
         }
      }

      public static void SendSpace()
      {
         //Change Later
         IntPtr WindowToFind = FindWindow("MozillaWindowClass", null);

         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("Fishing......");
         Console.WriteLine($"Current Sleep Time {RandomSleepTime}");
         Console.ForegroundColor = ConsoleColor.Gray;

         PostMessage(WindowToFind, WM_KEYDOWN, VK_Space, 0);
      }

      public static void WelcomeMessage()
      {
         string Time = DateTime.Now.ToShortTimeString();

         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine("--------------------------------------------------------------");
         Console.ForegroundColor = ConsoleColor.Cyan;

         Console.WriteLine("Welcome to MapleStory2 Fishing Buddy");
         Console.WriteLine("This program will automate the fishing process in MapleStory2");
         Console.WriteLine();
         Console.WriteLine($"Start time: {Time}");

         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine("--------------------------------------------------------------");
         Console.ForegroundColor = ConsoleColor.Gray;

         Console.WriteLine("Fishing has started.......");
      }
   }
}
