using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public class Level
    {
        private Tile[,] tiles;
        private int width;
        private int height;
        private HeroTile hero;
        private ExitTile exit;

        public enum TileType { Empty, Wall, Hero, Exit }

        public Level(int width, int height, HeroTile existingHero = null)
        {
            this.width = width;
            this.height = height;
            tiles = new Tile[width, height];

            InitializeTiles();

            // Place hero
            Position heroPos = GetRandomEmptyPosition();
            if (existingHero != null)
            {
                hero = existingHero;
                hero.Position = heroPos;
                tiles[heroPos.X, heroPos.Y] = hero;
            }
            else
            {
                hero = (HeroTile)CreateTile(TileType.Hero, heroPos);
            }

            hero.UpdateVision(this);

            // Place exit
            Position exitPos = GetRandomEmptyPosition();
            exit = (ExitTile)CreateTile(TileType.Exit, exitPos);
        }

        public int Width
        {
            get { return width; }
        }

        public int Height
        {
            get { return height; }
        }

        public HeroTile Hero
        {
            get { return hero; }
        }

        public ExitTile Exit
        {
            get { return exit; }
        }

        public Tile[,] Tiles
        {
            get { return tiles; }
        }

        private void InitializeTiles()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                    {
                        CreateTile(TileType.Wall, new Position(x, y));
                    }
                    else
                    {
                        CreateTile(TileType.Empty, new Position(x, y));
                    }
                }
            }
        }

        public Tile CreateTile(TileType type, Position position)
        {
            Tile tile = null;

            switch (type)
            {
                case TileType.Empty:
                    tile = new EmptyTile(position);
                    break;
                case TileType.Wall:
                    tile = new WallTile(position);
                    break;
                case TileType.Hero:
                    tile = new HeroTile(position);
                    hero = (HeroTile)tile;
                    break;
                case TileType.Exit:
                    tile = new ExitTile(position);
                    exit = (ExitTile)tile;
                    break;
            }

            tiles[position.X, position.Y] = tile;
            return tile;
        }

        public Tile CreateTile(TileType type, int x, int y)
        {
            return CreateTile(type, new Position(x, y));
        }

        public Position GetRandomEmptyPosition()
        {
            Random random = new Random();
            Position position;

            do
            {
                int x = random.Next(1, width - 1);
                int y = random.Next(1, height - 1);
                position = new Position(x, y);
            } while (tiles[position.X, position.Y] is not EmptyTile);

            return position;
        }

        public Tile GetTileAt(int x, int y)
        {
            if (x < 0 || x >= width || y < 0 || y >= height)
                return null;

            return tiles[x, y];
        }

        public void SwapTiles(Tile tile1, Tile tile2)
        {
            Position pos1 = tile1.Position;
            Position pos2 = tile2.Position;

            tiles[pos1.X, pos1.Y] = tile2;
            tiles[pos2.X, pos2.Y] = tile1;

            tile1.Position = pos2;
            tile2.Position = pos1;
        }

        public override string ToString()
        {
            string levelString = "";

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    levelString += tiles[x, y].Display;
                }
                levelString += "\n";
            }

            return levelString;
        }
    }
}