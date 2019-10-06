using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RTS_POE
{
    class ResourceBuilding : Building
    {
        //random number generator...
        Random rnd = new Random();

        //Resource Building spacific fields..
        // "r" indicating a resounce variable...
        string rType;
        int rGenTotal;
        int rGenPerRound;
        int rPool;

        
        
        // does some constructing
        public ResourceBuilding(string name, int xPos, int yPos, int health, int team, string symbol,string node) : base(xPos, yPos,name, 110, team, "O")
        {
            HEALTH_MAX = health;
            this.name = name;
            this.xPos = xPos;
            this.yPos = yPos;
            this.health = health;
            this.team = team;
            this.symbol = symbol;

            rType = node.Split(',')[0];
            rPool = Int32.Parse(node.Split(',')[1]);

            rGenPerRound = Int32.Parse(node.Split(',')[2]);



        }

       



        //checks the current remaining resources in referance to how many were avaliable at the beggining...
        public string status
        {
            get
            {
                if ((rPool) == 0)// Depleated
                {
                    return "D E P L E A T E D";
                }
                else if ((rPool) < (rPool+rGenTotal) * 0.25)//less than 25%
                {
                    return "L O W";
                }
                else if ((rPool) < (rPool + rGenTotal) * 0.5) //less than 50%
                {
                    return "A V E R A G E";
                }
                //if ((rPool - rGenTotal) > rPool * 0.5)
                else// over 50 %
                {
                    return "G O O D";
                }

            }
        }

        // handles the increas of resources
        public void Extract()
        {
            if (rPool-rGenPerRound>=0)
            {
                rGenTotal += rGenPerRound;
                rPool -= rGenPerRound;
            }
            else
            {
                rGenTotal += rPool;
                rPool = 0;
            }
        }




        public override void Demolish()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return Symbol + "  " + name + Symbol + "\nTeam: " + team + "\nPosition:  X:" + xPos + ", Y:" + yPos + "\nHP: " + Health + "\nCOLLECTOR STATS...\nType: "+rType+"\nStockpile: " +rGenTotal+ "\nEfficiency: "+rGenPerRound+"\nEstimated Reserves\n"+status;
        }

        public override void saveFile()
        {
            FileStream savefile = new FileStream(Environment.CurrentDirectory + "\\ResourceBuildings.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(savefile);
            //0= team, 1= x, 2= y, 3= health, 4 = rType , 5= total generated, 6 =gen speed, 7 = total pool
            writer.WriteLine(Team + "," + XPos + "," + YPos + "," + Health + "," + rType + "," + rGenTotal + "," + rGenPerRound + "," + rPool);
            Console.WriteLine("Saved!");
            writer.Close();
            savefile.Close();
        }
    }
}
