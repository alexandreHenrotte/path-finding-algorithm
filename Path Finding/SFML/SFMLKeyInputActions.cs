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
    class SFMLKeyInputActions
    {
        public static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            SFMLWindow window = (SFMLWindow)sender;
            Logic.Grid currentNodeGrid = window.currentNodeGrid;

            switch (e.Code)
            {
                // Switch ON/OFF the option of having diagonal neighbours in the best path found
                case Keyboard.Key.Space:
                    window.currentNodeGrid.wantDiagonalNeighbours = !window.currentNodeGrid.wantDiagonalNeighbours;
                    break;
            }
        }
    }
}
