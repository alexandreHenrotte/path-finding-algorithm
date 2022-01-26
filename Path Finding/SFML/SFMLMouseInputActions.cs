using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Path_Finding.SFML
{
    class SFMLMouseInputActions
    {
        public static void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            SFMLWindow window = (SFMLWindow)sender;
            Logic.Grid currentNodeGrid = window.currentNodeGrid;

            try
            {
                Logic.Node clickedNode = GetClickedNode(currentNodeGrid, e);
                MakeActionOnNode(currentNodeGrid, clickedNode, e);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        private static Logic.Node GetClickedNode(Logic.Grid currentNodeGrid, MouseButtonEventArgs e)
        {
            decimal x_mouse = e.X;
            decimal y_mouse = e.Y;

            int xAxisSize = currentNodeGrid.grid.GetLength(0);
            int yAxisSize = currentNodeGrid.grid.GetLength(1);
            int squareSize = (int)currentNodeGrid.GetNode(1, 1).Size.X;

            int x_node = (int)((x_mouse / (xAxisSize * squareSize)) * xAxisSize) + 1;
            int y_node = (int)((y_mouse / (yAxisSize * squareSize)) * yAxisSize) + 1;

            if (currentNodeGrid.CoordinatesAreValid(x_node, y_node))
            {
                return currentNodeGrid.GetNode(x_node, y_node);
            }
            else
            {
                throw new Exception($"There is no node at x:{x_node}   y:{y_node}");
            }
        }

        private static void MakeActionOnNode(Logic.Grid currentNodeGrid, Logic.Node clickedNode, MouseButtonEventArgs e)
        {
            switch(e.Button)
            {
                // Set node as the start node
                case Mouse.Button.Left:
                    if (clickedNode.walkable && clickedNode != currentNodeGrid.endNode)
                        currentNodeGrid.startNode = clickedNode;
                    break;

                // Set node as the end node
                case Mouse.Button.Right:
                    if (clickedNode.walkable && clickedNode != currentNodeGrid.startNode)
                        currentNodeGrid.endNode = clickedNode;
                    break;

                // Set node as a wall
                case Mouse.Button.Middle:
                    if (clickedNode.walkable)
                        currentNodeGrid.AddWall(clickedNode);
                    else
                        currentNodeGrid.RemoveWall(clickedNode);

                    clickedNode.walkable = !clickedNode.walkable;
                    break;
            }
        }
    }
}
