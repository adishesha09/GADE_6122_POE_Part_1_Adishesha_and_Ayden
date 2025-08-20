using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public class EmptyTile: Tile
    {
        public EmptyTile(Position position) : base(position) { }

        public override char Display
        {
            get { return '.'; }
        }
    }
}