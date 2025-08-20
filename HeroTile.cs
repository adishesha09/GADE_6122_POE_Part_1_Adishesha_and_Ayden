using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public class HeroTile : CharacterTile
    {
        public HeroTile(Position position) : base(position, 40, 8) { }

        public override char Display
        {
            get { return IsDead ? 'X' : 'H'; }
        }
    }
}