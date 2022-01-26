using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding.Logic
{
    class Node
    {
        // 2D coordinates on the grid
        public int x;
        public int y;

        // Parent of node
        private Node parentNode;

        // G cost : distance from start node
        private int dijkstra_g = 0;
        // H cost : distance from end node
        private int dijkstra_h = 0;
        // F cost : G + H
        private int dijkstra_f = 0;

        // Is the node a "wall" or not
        private bool walkable;

        public Node(int x, int y, bool walkable=true)
        {
            this.x = x;
            this.y = y;
            this.walkable = walkable;
        }

        public bool IsLocatedAt(int x, int y)
        {
            return this.x == x && this.y == y;
        }

        public bool IsWalkable()
        {
            return this.walkable;
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
