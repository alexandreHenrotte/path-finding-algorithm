using System;
using System.Collections.Generic;

namespace Path_Finding.Logic
{
    class GridBuilder
    {
        private static int[] gridSize;
        private static Node startNode;
        private static Node endNode;
        private static List<Node> walls;

        public static Grid Build()
        {
            return new Grid(gridSize, startNode, endNode, walls);
        }

        public static void SetGridSize(int x, int y)
        {
            gridSize = new int[] { x, y };
        }
        public static void SetStartNodePosition(int x, int y)
        {
            startNode = new Node(x, y, Node.DEFAULT_SIZE, Node.DEFAULT_OUTLINE_THICKNESS);
        }
        public static void SetEndNodePosition(int x, int y)
        {
            endNode = new Node(x, y, Node.DEFAULT_SIZE, Node.DEFAULT_OUTLINE_THICKNESS);
        }
        public static void SetWallsNodesPosition(List<int[]> wallsPositions)
        {
            walls = new List<Node>();
            for (int i = 0; i < wallsPositions.Count; i++)
            {
                int x = wallsPositions[i][0];
                int y = wallsPositions[i][1];
                walls.Add(new Node(x, y, Node.DEFAULT_SIZE, Node.DEFAULT_OUTLINE_THICKNESS, walkable: false));
            }
        }

        public static Grid[] GetDemoGrids()
        {
            return new Grid[] { DemoGrid1(), DemoGrid2(), DemoGrid3() };
        }

        private static Grid DemoGrid1()
        {
            SetGridSize(11, 6);
            SetStartNodePosition(8, 5);
            SetEndNodePosition(5, 2);
            SetWallsNodesPosition(new List<int[]>());
            return Build();
        }
        private static Grid DemoGrid2()
        {
            SetGridSize(11, 6);
            SetStartNodePosition(8, 5);
            SetEndNodePosition(5, 2);
            SetWallsNodesPosition(new List<int[]> {
                new int[] {4, 2},
                new int[] {4, 3},
                new int[] {5, 3},
                new int[] {6, 3},
                new int[] {7, 3},
                new int[] {8, 3},
            });
            return Build();
        }

        private static Grid DemoGrid3()
        {
            SetGridSize(7, 4);
            SetStartNodePosition(2, 4);
            SetEndNodePosition(7, 2);
            SetWallsNodesPosition(new List<int[]> {
                new int[] {4, 2},
                new int[] {5, 2},
                new int[] {5, 3},
            });
            return Build();
        }
    }
}
