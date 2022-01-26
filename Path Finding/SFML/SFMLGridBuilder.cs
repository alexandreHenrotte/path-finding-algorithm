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
    class SFMLGridBuilder
    {
        public static RectangleShape[,] CreateSquareGrid(int xAxisSize, int yAxisSize, int square_size, int squareOutlineThickness)
        {
            RectangleShape[,] squareGrid = new RectangleShape[xAxisSize, yAxisSize];

            int squarePositionX = squareOutlineThickness;
            for (int x = 0; x < xAxisSize; x++)
            {
                int squarePositionY = squareOutlineThickness;
                for (int y = 0; y < yAxisSize; y++)
                {
                    squareGrid[x, y] = new SFMLSquare(squarePositionX, squarePositionY, square_size, squareOutlineThickness);
                    squarePositionY += square_size;
                }

                squarePositionX += square_size;
            }

            return squareGrid;
        }
    }
}
