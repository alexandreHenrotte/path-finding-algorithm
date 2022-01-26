using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using Path_Finding;

namespace Path_Finding.SFML
{
    class SFMLWindow
    {
        static uint WINDOW_WIDTH = 800;
        static uint WINDOW_HEIGHT = 600;
        static Color WINDOW_COLOR_RGB = new Color(255, 255, 255);
        static string WINDOW_TITLE = "Path finding A*";
        static uint WINDOW_MAX_FPS = 60;

        public static void Main(string[] args)
        {
            SFML.SFMLWindow.Show();
        }

        public static void Show()
        {
            // Create the window
            RenderWindow window = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), WINDOW_TITLE);
            Color windowColor = WINDOW_COLOR_RGB;
            window.SetFramerateLimit(WINDOW_MAX_FPS);

            // Setup events
            window.Closed += new EventHandler(OnWindowClose);
            window.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(OnMouseButtonPressed);

            // Create node grid
            Logic.Grid nodeGrid = CreateLogicNodeGridDemo();

            // Window loop
            while (window.IsOpen)
            {
                // Process events
                window.DispatchEvents();

                // Clear screen
                window.Clear(windowColor);

                // Draw node grid
                nodeGrid.Draw(window, showBestPath:true);

                // Update the window
                window.Display();
            }
        }

        static Logic.Grid CreateLogicNodeGridDemo()
        {
            return Logic.GridBuilder.GetDemoGrids()[0];
        }



        /*
         *   WINDOW EVENTS
         */

        static void OnWindowClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            int x_mouse = e.X;
            int y_mouse = e.Y;
        }
    }
}
