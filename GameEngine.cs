using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public enum Direction { Up, Right, Down, Left, None }
    public enum GameState { InProgress, Complete, GameOver }

    public class GameEngine
    {
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;

        private Level currentLevel;
        private int numberOfLevels;
        private int currentLevelNumber;
        private Random random;
        private GameState gameState;

        public GameEngine(int numberOfLevels)
        {
            this.numberOfLevels = numberOfLevels;
            currentLevelNumber = 1;
            random = new Random();
            gameState = GameState.InProgress;

            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);
            currentLevel = new Level(width, height);
        }

        public Level CurrentLevel
        {
            get { return currentLevel; }
        }

        public int CurrentLevelNumber
        {
            get { return currentLevelNumber; }
        }

        public GameState State
        {
            get { return gameState; }
        }

        private bool MoveHero(Direction direction)
        {
            if (gameState != GameState.InProgress) return false;

            Tile targetTile = null;
            int directionIndex = (int)direction;

            if (directionIndex >= 0 && directionIndex < 4)
            {
                targetTile = currentLevel.Hero.Vision[directionIndex];
            }

            if (targetTile == null) return false;

            if (targetTile is ExitTile)
            {
                if (currentLevelNumber >= numberOfLevels)
                {
                    gameState = GameState.Complete;
                    return false;
                }
                else
                {
                    NextLevel();
                    return true;
                }
            }

            if (targetTile is not EmptyTile) return false;

            currentLevel.SwapTiles(currentLevel.Hero, targetTile);
            currentLevel.Hero.UpdateVision(currentLevel);
            return true;
        }

        public void TriggerMovement(Direction direction)
        {
            MoveHero(direction);
        }

        private void NextLevel()
        {
            currentLevelNumber++;
            HeroTile existingHero = currentLevel.Hero;

            int width = random.Next(MIN_SIZE, MAX_SIZE + 1);
            int height = random.Next(MIN_SIZE, MAX_SIZE + 1);
            currentLevel = new Level(width, height, existingHero);
        }

        public override string ToString()
        {
            if (gameState == GameState.Complete)
            {
                return "Congratulations! You have completed all levels!";
            }

            return currentLevel.ToString();
        }
    }
}
