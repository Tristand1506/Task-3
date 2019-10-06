using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RTS_POE
{
    abstract class Building
    {
        //declaring the protected variables for use
        protected string name;
        protected int xPos;
        protected int yPos;
        protected int health;
        protected int HEALTH_MAX;
        protected int team;
        protected string symbol;

        //constructor that receives parameteres for all the above class variables 
        public Building(int xPos1, int yPos1, string name, int health, int team, string symbol)
        {
            //this. to refer to the instance of the variable in this class
            this.name = name;
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
        }

        //the abstract methods that will later be overridden
        public abstract void Demolish();
        public abstract string ToString();


        //get and set methods for main class...
        public int XPos { get { return xPos; } set { xPos = value; } }

        public int YPos { get { return yPos; } set { yPos = value; } }

        public int maxHP { get { return health; } }

        //no sets required...
        public int Health { get { return health; } }

        public int Team { get { return team; } set { team = value; } }

        public string Symbol { get { return symbol; } }

        public string Name { get { return name; } set { name = value; } }

        public abstract void saveFile();

    }
}
