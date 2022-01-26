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

        public static void Show()
        {
            // Create the window
            RenderWindow window = new RenderWindow(new VideoMode(WINDOW_WIDTH, WINDOW_HEIGHT), WINDOW_TITLE);
            Color windowColor = WINDOW_COLOR_RGB;
            window.SetFramerateLimit(WINDOW_MAX_FPS);

            // Setup events
            window.Closed += new EventHandler(OnClose);

            // Settings of the grid
            int xAxisSize = 11;
            int yAxisSize = 6;
            int squareSize = 50;
            int squareOutlineThickness = 2;

            // Create logic of the square grid
            Logic.Grid logicSquareGrid = CreateLogicSquareGridDemo(xAxisSize, yAxisSize);

            // Create representation of the square grid
            RectangleShape[,] representationSquareGrid = SFMLGridBuilder.CreateSquareGrid(xAxisSize, yAxisSize, squareSize, squareOutlineThickness);

            // Window loop
            while (window.IsOpen)
            {
                // Process events
                window.DispatchEvents();

                // Clear screen
                window.Clear(windowColor);

                // Create logic square grid and draw its representation
                
                DrawSquareGrid(window, logicSquareGrid, representationSquareGrid, showBestPath: true);
                

                // Update the window
                window.Display();
            }
        }

        static Logic.Grid CreateLogicSquareGridDemo(int xAxisSize, int yAxisSize)
        {
            return Logic.GridBuilder.GetDemoGrids()[2];
        }

        static Logic.Grid CreateLogicSquareGrid(int xAxisSize, int yAxisSize, int[] startPosition, int[] endPosition, List<int[]> wallsPosition)
        {
            Logic.GridBuilder.SetGridSize(xAxisSize, yAxisSize);
            Logic.GridBuilder.SetStartNodePosition(startPosition[0], startPosition[1]);
            Logic.GridBuilder.SetEndNodePosition(endPosition[0], endPosition[1]);
            Logic.GridBuilder.SetWallsNodesPosition(wallsPosition);
            return Logic.GridBuilder.Build();
        }

        static void DrawSquareGrid(RenderWindow window, Logic.Grid logicSquareGrid, RectangleShape[,] representationSquareGrid, bool showBestPath=true)
        {
            if (showBestPath)
            {
                Logic.PathFinder.SetGrid(logicSquareGrid);
                Logic.PathFinder.FindPath();
            }

            for (int x = 1; x <= representationSquareGrid.GetLength(0); x++)
            {
                for (int y = 1; y <= representationSquareGrid.GetLength(1); y++)
                {
                    // BETTER CODE POSSIBLE :
                    // Create a class like Logic.Grid for the representationGrid and create a method
                    // to get the RectangleShape with the help of the normal "x" and "y" position
                    int x_array = x - 1;
                    int y_array = y - 1;

                    if (logicSquareGrid.startNode.IsLocatedAt(x, y))
                    {
                        representationSquareGrid[x_array, y_array].FillColor = Color.Blue;
                    }
                    // End point
                    else if (logicSquareGrid.endNode.IsLocatedAt(x, y))
                    {
                        representationSquareGrid[x_array, y_array].FillColor = Color.Yellow;
                    }
                    // Walls
                    else if (logicSquareGrid.walls.Exists(wall => wall.IsLocatedAt(x, y)))
                    {
                        representationSquareGrid[x_array, y_array].FillColor = Color.Black;
                    }
                    // Best path
                    else if (showBestPath && Logic.PathFinder.GetBestPathNodes().Exists(bestPathNode => bestPathNode.IsLocatedAt(x, y)))
                    {
                        representationSquareGrid[x_array, y_array].FillColor = Color.Cyan;
                    }
                    // Blank space
                    else
                    {
                        // (Can be used for DEBUG)
                        //bool hasParentNode = GetNode(x, y).GetParentNode() != null;
                        //Console.Write(hasParentNode ? "#" : "□");

                        //Console.Write("□");
                    }

                    window.Draw(representationSquareGrid[x_array, y_array]);
                }
            }
        }



        /*
         *   WINDOW EVENTS
         */

        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
    }
}
