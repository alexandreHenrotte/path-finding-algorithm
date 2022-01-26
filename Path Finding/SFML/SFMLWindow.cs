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
    class SFMLWindow : RenderWindow
    {
        static uint WINDOW_WIDTH = 800;
        static uint WINDOW_HEIGHT = 600;
        static Color WINDOW_COLOR_RGB = new Color(255, 255, 255);
        static string WINDOW_TITLE = "Path finding A*";
        static uint WINDOW_MAX_FPS = 60;

        public Logic.Grid currentNodeGrid;

        public static void Main(string[] args)
        {

            new SFMLWindow();
        }

        public SFMLWindow() : base(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), WINDOW_TITLE)
        {
            Color windowColor = WINDOW_COLOR_RGB;
            this.SetFramerateLimit(WINDOW_MAX_FPS);

            // Setup events
            this.Closed += new EventHandler(OnWindowClose);
            this.MouseButtonPressed += new EventHandler<MouseButtonEventArgs>(SFMLMouseInputActions.OnMouseButtonPressed);
            this.KeyPressed += new EventHandler<KeyEventArgs>(SFMLKeyInputActions.OnKeyPressed);

            // Create node grid
            currentNodeGrid = Logic.GridBuilder.GetDemoGrids()[3];

            // Window loop
            while (this.IsOpen)
            {
                // Process events
                this.DispatchEvents();

                // Clear screen
                this.Clear(windowColor);

                // Draw node grid
                currentNodeGrid.Draw(this, showBestPath:true);

                // Update the window
                this.Display();
            }
        }

        void OnWindowClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
    }
}
