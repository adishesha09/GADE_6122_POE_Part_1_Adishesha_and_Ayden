using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    using System.Media;

    public class ArcadeSounds
    {
        public static void PlayMoveSound()
        {
            // Simple beep for movement
            Console.Beep(800, 50);
        }

        public static void PlayRestartSound()
        {
            Console.Beep(1500, 100);
            Console.Beep(1200, 100);
            Console.Beep(1500, 200);
        }

        public static void PlayLevelComplete()
        {
            Console.Beep(1000, 200);
            Console.Beep(1200, 200);
            Console.Beep(1500, 400);
        }
    }
}
