using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace Path_Finding.SFML
{
    class SFMLSquare : RectangleShape
    {
        public SFMLSquare(int x, int y, int size, int outlineThickness)
        {
            // Set square position
            this.Position = new Vector2f(x, y);

            // Set square size
            int width = size;
            int height = size;
            this.Size = new Vector2f(width, height);

            // Set square color
            //square.FillColor = Color.Black;

            // Set square outline
            this.OutlineThickness = outlineThickness;
            this.OutlineColor = Color.Black;
        }
    }
}
