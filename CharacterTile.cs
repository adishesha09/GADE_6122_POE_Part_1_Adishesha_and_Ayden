using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GADE_6122_POE_Adishesha_and_Ayden
{
    public abstract class CharacterTile : Tile
    {
        protected int hitPoints;
        protected int maxHitPoints;
        protected int attackPower;
        protected Tile[] vision;

        public CharacterTile(Position position, int hitPoints, int attackPower) : base(position)
        {
            this.hitPoints = hitPoints;
            this.maxHitPoints = hitPoints;
            this.attackPower = attackPower;
            this.vision = new Tile[4];
        }

        public int HitPoints
        {
            get { return hitPoints; }
        }

        public int MaxHitPoints
        {
            get { return maxHitPoints; }
        }

        public int AttackPower
        {
            get { return attackPower; }
        }

        public Tile[] Vision
        {
            get { return vision; }
        }

        public void UpdateVision(Level level)
        {
            // North (0)
            if (Y > 0) 
                vision[0] = level.GetTileAt(X, Y - 1);
            else vision[0] = null;

            // East (1)
            if (X < level.Width - 1) 
                vision[1] = level.GetTileAt(X + 1, Y);
            else vision[1] = null;

            // South (2)
            if (Y < level.Height - 1) 
                vision[2] = level.GetTileAt(X, Y + 1);
            else vision[2] = null;

            // West (3)
            if (X > 0) 
                vision[3] = level.GetTileAt(X - 1, Y);
            else vision[3] = null;
        }

        public void TakeDamage(int damage)
        {
            hitPoints -= damage;
            if (hitPoints < 0) 
                hitPoints = 0;
        }

        public void Attack(CharacterTile target)
        {
            target.TakeDamage(attackPower);
        }

        public bool IsDead
        {
            get { return hitPoints <= 0; }
        }
    }
}