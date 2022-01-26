using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Path_Finding.Logic
{
    class Node : RectangleShape
    {
        public const int DEFAULT_SIZE = 60;
        public const int DEFAULT_OUTLINE_THICKNESS = 2;

        // 2D coordinates on the grid
        public int x;
        public int y;

        // Dijkstra algorithm variables
        private Node parentNode;
        private int dijkstra_g = 0; // distance from start node
        private int dijkstra_h = 0; // distance from end node
        private int dijkstra_f = 0; // g + h

        // Is the node a wall or not
        public bool walkable; 

        public Node(int x, int y, int size, int outlineThickness, bool walkable=true)
        {
            this.x = x;
            this.y = y;
            this.walkable = walkable;

            // SFML
            this.Size = new Vector2f(size, size);
            this.OutlineThickness = outlineThickness;
            this.OutlineColor = Color.Black;
        }

        public bool IsLocatedAt(int x, int y)
        {
            return this.x == x && this.y == y;
        }

        public Node GetParentNode()
        {
            return this.parentNode;
        }
        public void SetParentNode(Node parentNode)
        {
            this.parentNode = parentNode;
        }

        public void SetDijkstraCost(int g, int h, int f)
        {
            this.dijkstra_g = g;
            this.dijkstra_h = h;
            this.dijkstra_f = f;
        }

        public int GetDijkstra_gCost()
        {
            return this.dijkstra_g;
        }
        public int GetDijkstra_hCost()
        {
            return this.dijkstra_h;
        }
        public int GetDijkstra_fCost()
        {
            return this.dijkstra_f;
        }
    }
}
