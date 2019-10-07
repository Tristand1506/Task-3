using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RTS_POE
{
    class FactoryBuilding : Building
    {
        Random rnd = new Random();

        int unitType;
        int productionSpeed;
        int[] spawn= new int[2];
        string factGate;

        //constructor
        public FactoryBuilding(string name, int xPos, int yPos, int health, int team, string symbol, int unitType, int speed) : base(xPos, yPos, name, 110, team, "O")
        {
            HEALTH_MAX = 400;
            this.name = name;
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.team = team;
            this.symbol = symbol;
            this.unitType = unitType;
            this.productionSpeed = speed;

            // decides if the spawn is above or below building
            if (yPos<=0)
            {
                spawn[0] = xPos;
                spawn[1] = yPos+1;
                factGate = "Bottom";
            }
            else
            {
                spawn[0] = xPos;
                spawn[1] = yPos - 1;
                factGate = "Top";
            }



        }

        // creates a dynamic cost system for each unit type
        public int cost
        {
            get
            {
                switch (unitType)
                {
                    // returns cost value...
                    default: return 25; break;
                    case 0: return 20; break;
                    case 1: return 15; break;       
                }
            }
        }

        public override void Demolish()
        {
            throw new NotImplementedException();
        }

        //tostring
        public override string ToString()
        {
            string type;
            if (unitType == 0)
            {
                type = "Bruiser";
            }
            else
            {
                type = "Ranger";
            }
            return Symbol + "  " + name + Symbol + "\nTeam: " + team + "\nPosition:  X:" + xPos + ", Y:" + yPos + "\nHP: " + Health + "\nFACTORY STATS...\nUnit Type: "+type+"\nProduction Rate: "+productionSpeed+ "\nFactory Gate: "+factGate;
        }
         public int ProductionSpeed
        {
            get { return productionSpeed; }
        }



        public bool SourceMaterials (Building[] buildings)
        {
            //sets to max value as a flag.
            int closestBulding = Int32.MaxValue;

            //max out double to highest int so any distance should be lower than it...
            double closeestDistance = Int32.MaxValue;
            int i = 0;
            foreach (Building b in buildings)
            {
                if (b.Team == this.Team && b.GetType().Equals(typeof(ResourceBuilding)))
                {
                    // uses pithag to chek distance...
                    double distance = Math.Sqrt(Math.Pow(Math.Abs(b.XPos - this.XPos), 2) + Math.Pow(Math.Abs(b.YPos - this.YPos), 2));

                    //checks if this building can supply the resources and if its closer...
                    if ((distance < closeestDistance)&&(((ResourceBuilding)b).ResorcePool - cost > 0))
                    {
                        closeestDistance = distance;
                        closestBulding = i;
                    }
                }
                i++;
            }
            // checks if flag has changed 
            if (closestBulding != Int32.MaxValue)
            {
                // subtracts resource from the pool...
                ((ResourceBuilding)buildings[closestBulding]).ResorcePool -= cost;
                return true;
            }
            else return false;


        }

       


        public Unit Spawn()
        {
                // assigns unit x and y values 
                int newX = spawn[0];
                int newY = spawn[1];
                int tempAttack = 0;

                // randomly assigns units damage values
                switch (rnd.Next(0, 4))
                {
                    case 0: tempAttack = 5; break;
                    case 1: tempAttack = 10; break;
                    case 2: tempAttack = 15; break;
                    case 3: tempAttack = 20; break;
                }

                // gives unit type
                switch (unitType)
                {
                    default: return new MeleeUnit("Bruiser", newX, newY, 300, 1, tempAttack, 1, team, "♣", false); break;
                    case 0: return new MeleeUnit("Bruiser", newX, newY, 300, 1, tempAttack, 1, team, "♣", false); break;
                    case 1: return new RangeUnit("Ranger", newX, newY, 150, 2, tempAttack, 4, team, "♠", false); break;

                }

        }

        public override void saveFile()
        {
            // creates and opens file for writing 
            FileStream savefile = new FileStream(Environment.CurrentDirectory + "\\FactoryBuildings.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(savefile);
            // o = team, 1 = x, 2 = y, 3 = health, 4 = unit , 5 = production speed
            writer.WriteLine(Team + "," + XPos + "," + YPos + "," + Health + "," + unitType + "," + ProductionSpeed);
            Console.WriteLine("Saved!");
            writer.Close();
            savefile.Close();
        }

    }
}


