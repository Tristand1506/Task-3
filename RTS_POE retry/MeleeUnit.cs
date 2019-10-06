using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RTS_POE
{
    class MeleeUnit : Unit
    {
        // yet another constructor that does constructing
        public MeleeUnit(string name, int xPos, int yPos, int health, int speed, int attack, int attackRange, int team, string symbol, bool isAttacking) : base(xPos, yPos, 110, 1, attack, 1, team, "O", false)
        {
            HEALTH_MAX = 200;
            this.name = name;
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

        //gets and sets/ propperties
        public int XPos 
        {   get{ return this.xPos; }  set{ xPos = value; }   }

        public int YPos
        { get { return this.yPos; } set { yPos = value; } }

        public int Health
        {
            get { return this.health; }

            set {
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


        ///
        //Methods start here
        ///

            // this is a move method. it makes stuff move based on the two ints given...
        public override void move(int DirectionLR, int DirectionUD)
        {
            // handles the horisontal movement
            switch (DirectionLR)
            {
                case 0: break;
                case 1: 
                    if (this.xPos+1 > 20)
                    {
                        XPos = 20;
                    }
                    else
                    {
                        this.xPos = this.xPos + 1; //Right
                    }
                    break;

                case 2:
                    if (this.XPos - 1 < 0)
                    {
                        XPos = 0;
                    }
                    else
                    {
                        this.xPos = this.xPos - 1;  //Left
                    }
                    break;


            }
            /// handles vertical movement
            switch (DirectionUD)
            {
                case 0: break;
                case 1:
                    if (this.YPos + 1 > 20)
                    {
                        YPos = 20;
                    }
                    else
                    {
                        this.YPos = this.YPos + 1;  //down
                    }
                    break;
                case 2:
                    if (this.YPos - 1 < 0)
                    {
                        YPos = 0;
                    }
                    else
                    {
                        this.yPos = this.yPos - 1;  //up
                    }
                    break;

            }


        }

        // does the combat thing
        public override void combat(Unit enemy)
        {
            enemy.Health = enemy.Health - this.attack;
        }

        // checks if the given unit is in attacking range
        public override bool inRange(Unit enemy)
        {
            // creates  a distance based on pi-thag
            double distance= Math.Sqrt(Math.Pow(Math.Abs( enemy.XPos- this.XPos), 2) + Math.Pow(Math.Abs(enemy.YPos- this.YPos), 2));
            if ( distance <= AttackRange)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // cheks the nearest unite
        public override Unit nearby(Unit[] units)
        {
            //self set as default so if left as last one alive will off them selfes due to PTSD...
            Unit closestUnit = this;

            //max out double to highest int so any distance should be lower than it...
            double closeestDistance = Int32.MaxValue;

            foreach (Unit u in units)
            {
                if (u.Team != this.Team)
                {
                    double distance = Math.Sqrt(Math.Pow(Math.Abs(u.XPos - this.XPos), 2) + Math.Pow(Math.Abs(u.YPos - this.YPos), 2));

                    if (distance < closeestDistance)
                    {
                        closeestDistance = distance;
                        closestUnit = u;
                    }
                }
            }
            return closestUnit;
        }
        
        

        public override void death()
        {
            // WHat is death ???
        }

        public override string ToString()
        {
            return Symbol + "  "+name + Symbol +"\nTeam: " + team + "\nPosition:  X:" + XPos + ", Y:" + YPos + "\nHP: " + Health + "\nAttack: " + Attack;

            
        }

        public override void saveFile()
        {
            FileStream savefile = new FileStream(Environment.CurrentDirectory +"\\MeleeUnits.txt", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(savefile);

            writer.WriteLine(Team + "," + XPos + "," + YPos + "," + Health + "," + attack);
            Console.WriteLine("Saved!");
            writer.Close();
            savefile.Close();
        }
    }
}
