using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public abstract class Tile
    {
        private Position position;


        public Tile(Position position)
        {
            this.position = position;
        }

        public int X
        {
            get { return position.X; }
        }

        public int Y
        {
            get { return position.Y; }
        }

        public Position Position
        {
            get { return position; }
            set { position = value; }
        }

        public abstract char Display { get; }
    }
}
