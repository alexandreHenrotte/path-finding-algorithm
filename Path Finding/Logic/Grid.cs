using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        grid[x,y] = new Node(x + 1, y + 1);
                    }
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
