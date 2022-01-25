using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Path_Finding
{
    class PathFindingProgram
    {
        static void Main(string[] args)
        {
            Console.WriteLine("+ : Start point\r\n" +
                              "- : End point\r\n" +
                              "■ : Wall\r\n" +
                              "$ : Best path\r\n" +
                              "□ : Empty space\r\n");

            int demoGridIndex = 1;
            foreach (Grid demoGrid in GridBuilder.GetDemoGrids())
            {
                Console.WriteLine($"--- Demo n°{demoGridIndex} ---");
                
                demoGrid.Show(withPath: false);
                Console.WriteLine();

                demoGrid.Show(withPath: true);
                Console.WriteLine();

                demoGridIndex++;
            }
        }
    }
}
