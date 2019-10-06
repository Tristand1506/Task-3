using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_POE
{
    abstract class Unit
    {

        // initial varible declarations
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int HEALTH_MAX;
        protected int speed;
        protected int attack;
        protected int attackRange;
        protected int team;
        protected string symbol;
        protected bool isAttacking;
        protected string name;

        public Unit(int xPos, int yPos, int health, int speed, int attack, int attackRange, int team, string symbol, bool isAttacking)
        {
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.speed = speed;
            this.attack = attack;
            this.attackRange = attackRange;
            this.team = team;
            this.symbol = symbol;
            this.isAttacking = isAttacking;
        }

        public int XPos 
        {   get{ return this.xPos; }  set{ xPos = value; }   }

        public int YPos
        { get { return this.yPos; } set { yPos = value; } }

        public int Health
        {
            get { return this.health; }

            set
            {
                if (value < 0)
                {
                    health = 0;
                    this.death();
                }
                else { health = value; }
            }   
        }

        public int Speed
        {
            get { return this.speed; }

           /* set
            {
                if (value < 0)
                {
                    speed = 0;
                }
                else { speed = value; }
            } */
        }

        public int Attack
        {
            get { return this.attack; }

            set
            {
                if (value < 1)
                {
                    attack = 1;
                }
                else { attack = value; }
            }
        }

        public int AttackRange
        {
            get { return this.attackRange; }

           /* set
            {
                if (value < 1)
                {
                    attackRange = 1;
                }
                else { attackRange = value; }
            } */
        }

        public int Team
        {
            get { return team; }
        }

        public string Symbol
        {
            get { return this.symbol; }

            /* set
            {
                if ((value.Trim()).Equals(""))
                {
                    symbol = "O";
                }
                else if (value.Length > 1)
                {
                    symbol = value[0] + "";
                }
                else { symbol = value; }
                
            } */
        }

        public bool IsAttacking
        {
            get { return this.isAttacking; }

            set { isAttacking = value; }
        }

        public int HealthMax
        {
            get { return this.HEALTH_MAX; }
        }

        public abstract void move(int Direction, int Diagonal);


        public abstract void combat( Unit enemy);


        public abstract bool inRange(Unit enemy);


        public abstract Unit nearby(Unit[] units);

        public abstract void death();

        public abstract string ToString();
        public abstract void saveFile();
        


    }
}
