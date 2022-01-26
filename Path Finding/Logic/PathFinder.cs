using System;
using System.Collections.Generic;
using System.Text;

namespace Path_Finding.Logic
{
    class PathFinder
    {
        private static Grid grid;

        public static void SetGrid(Grid grid)
        {
            PathFinder.grid = grid;
        }

        public static void FindPath()
        {
            List<Node> openNodes = new List<Node>();
            List<Node> closedNodes = new List<Node>();
            openNodes.Add(grid.startNode);

            while (openNodes.Count > 0) {
                
                Node centerNode = FindNodeWithLeast_fCost(openNodes);
                openNodes.Remove(centerNode);
                closedNodes.Add(centerNode);

                List<Node> neighbours = FindNeighbours(centerNode);
                foreach (Node neighbour in neighbours)
                {
                    if (centerNode == grid.endNode)
                    {
                        return;
                    }

                    if (closedNodes.Contains(neighbour) || !neighbour.walkable)
                    {
                        continue;
                    }

                    int g_cost = centerNode.GetDijkstra_gCost() + GetDistance(centerNode, neighbour);
                    if (g_cost < neighbour.GetDijkstra_gCost() || !openNodes.Contains(neighbour))
                    {
                        int h_cost = GetDistance(grid.endNode, neighbour);
                        int f_cost = g_cost + h_cost;
                        neighbour.SetDijkstraCost(g_cost, h_cost, f_cost);
                        neighbour.SetParentNode(centerNode);

                        if (!openNodes.Contains(neighbour))
                            openNodes.Add(neighbour);
                    }
                    
                }
            }
        }

        static Node FindNodeWithLeast_fCost(List<Node> nodes)
        {
            Node bestNode = nodes[0];
            for (int i = 1; i < nodes.Count; i++)
            {
                Node node = nodes[i];
                if (node.GetDijkstra_fCost() < bestNode.GetDijkstra_fCost())
                {
                    bestNode = node;
                }
            }
            return bestNode;
        }

        static List<Node> FindNeighbours(Node node)
        {
            //   XXX   O = node
            //   XOX   X = neighbours
            //   XXX
            List<Node> neighboursNode = new List<Node>();
            for (int x = -1; x <=1; x++)
            {
                for (int y = -1; y <=1; y++)
                {
                    int neighbourNode_x = node.x + x;
                    int neighbourNode_y = node.y + y;
                    if (grid.CoordinatesAreValid(neighbourNode_x, neighbourNode_y))
                    {
                        Node neighbourNode = grid.GetNode(neighbourNode_x, neighbourNode_y);

                        if (!(x == 0 && y == 0)) 
                            neighboursNode.Add(neighbourNode);
                    }
                }
            }
            return neighboursNode;
        }

        static int GetDistance(Node nodeA, Node nodeB)
        {
            int dstX = Math.Abs(nodeA.x - nodeB.x);
            int dstY = Math.Abs(nodeA.y - nodeB.y);

            if (dstX > dstY)
                return 14 * dstY + 10 * (dstX - dstY);

            return 14 * dstX + 10 * (dstY - dstX);
        }

        public static List<Node> GetBestPathNodes()
        {
            List<Node> bestPathNodes = new List<Node>();

            Node currentNode = grid.endNode.GetParentNode();
            while (currentNode != grid.startNode)
            {
                bestPathNodes.Add(currentNode);
                currentNode = currentNode.GetParentNode();
            }

            return bestPathNodes;
        }
    }
}
