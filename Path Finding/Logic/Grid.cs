using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Path_Finding.Logic
{
    class Grid
    {
        public Node[,] grid;
        public Node startNode;
        public Node endNode;
        public List<Node> walls;

        public Grid(int[] gridSize, Node startNode, Node endNode, List<Node> walls)
        {
            // Keep references
            this.startNode = startNode;
            this.endNode = endNode;
            this.walls = walls;

            // Create grid
            grid = new Node[gridSize[0], gridSize[1]];

            // Add start node
            grid[startNode.x - 1, startNode.y - 1] = startNode;

            // Add end node
            grid[endNode.x - 1, endNode.y - 1] = endNode;

            // Add wall nodes
            foreach (Node wallNode in walls)
            {
                grid[wallNode.x - 1, wallNode.y - 1] = wallNode;
            }

            // Fill grid with walkable empty nodes
            for (int y = 0; y < gridSize[1]; y++)
            {
                for (int x = 0; x < gridSize[0]; x++)
                {
                    if (grid[x, y] == null)
                    {
                        grid[x,y] = new Node(x + 1, y + 1, Node.DEFAULT_SIZE, Node.DEFAULT_OUTLINE_THICKNESS);
                    }
                }
            }

            // Set SFML position of nodes
            int nodePositionX = Node.DEFAULT_OUTLINE_THICKNESS;
            for (int x = 0; x < gridSize[0]; x++)
            {
                int nodePositionY = Node.DEFAULT_OUTLINE_THICKNESS;
                for (int y = 0; y < gridSize[1]; y++)
                {
                    grid[x, y].Position = new Vector2f(nodePositionX, nodePositionY);
                    nodePositionY += Node.DEFAULT_SIZE;
                }

                nodePositionX += Node.DEFAULT_SIZE;
            }
        }

        public void Draw(RenderWindow window, bool showBestPath = true)
        {
            if (showBestPath)
            {
                Logic.PathFinder.SetGrid(this);
                Logic.PathFinder.FindPath();
            }

            for (int x = 1; x <= grid.GetLength(0); x++)
            {
                for (int y = 1; y <= grid.GetLength(1); y++)
                {
                    int x_array = x - 1;
                    int y_array = y - 1;

                    if (startNode.IsLocatedAt(x, y))
                    {
                        grid[x_array, y_array].FillColor = Color.Blue;
                    }
                    // End point
                    else if (endNode.IsLocatedAt(x, y))
                    {
                        grid[x_array, y_array].FillColor = Color.Yellow;
                    }
                    // Walls
                    else if (walls.Exists(wall => wall.IsLocatedAt(x, y)))
                    {
                        grid[x_array, y_array].FillColor = Color.Black;
                    }
                    // Best path
                    else if (showBestPath && Logic.PathFinder.GetBestPathNodes().Exists(bestPathNode => bestPathNode.IsLocatedAt(x, y)))
                    {
                        grid[x_array, y_array].FillColor = Color.Cyan;
                    }
                    // Blank space
                    else
                    {
                        // (Can be used for DEBUG)
                        //bool hasParentNode = GetNode(x, y).GetParentNode() != null;
                        //Console.Write(hasParentNode ? "#" : "□");

                        //Console.Write("□");
                    }

                    window.Draw(grid[x_array, y_array]);
                }
            }
        }

        public Node GetNode(int x, int y)
        {
            return grid[x-1, y-1];
        }

        
        public bool CoordinatesAreValid(int x, int y)
        {
            return (x >= 1 && x <= grid.GetLength(0)) &&
                   (y >= 1 && y <= grid.GetLength(1));
        }
    }
}
