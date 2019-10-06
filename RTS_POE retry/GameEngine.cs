using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace RTS_POE
{
    class GameEngine
    {


        int round = 1;

        Object selected;

        //builds map and sets number of starting units and buildings
        public Map battleMap = new Map(10,5);

        //global random number generator
        Random rnd = new Random();

        //trags objects from the starting form
        private GameWindow gameWindow;
        private GroupBox groupBox;
        private Panel pnlBattelField;

        //constructor for game engine takes in ui elements form main form
        public GameEngine(GameWindow gw, GroupBox gb, Panel pnl)
        {
            // assigns them to local variables
            groupBox = gb;
            gameWindow = gw;
            pnlBattelField = pnl;
        }


        public int Round
        {
            get { return round; }
            set { round = value; }
        }


        //called when u choose to update the pannle that hold the units...
        public void UpdatePannle()
        {
            // clears the pannle for new unit placement
            pnlBattelField.Controls.Clear();
            
            // foreach loop handles unit placment
            foreach (Unit u in battleMap.units)
            {
                Button b = new Button();
                //sets the location of a button to corrospond to a unit in the array
                b.Location = new Point(u.XPos * 35, u.YPos * 35);// the * 35 creates a psudo grid bassed on the size of the pannle
                //sets the size of a button...
                b.Size = new Size(30, 30);
                //sets text for button to the unite symbol
                b.Text = u.Symbol;
                b.Font = new Font(b.Font.FontFamily, 13);
                //assigns a color based on unit and team
                if (u.Team == 0)
                {
                    b.BackColor = Color.Black;
                    b.ForeColor = Color.AntiqueWhite;
                }
                else
                {
                    b.BackColor = Color.AntiqueWhite;
                    b.ForeColor = Color.Black;
                }
                //gives a click event
                b.Click += unitClick;
                //adds button to pannle
                pnlBattelField.Controls.Add(b);
                
            }

            // has simmilar structure to unit foreach loop..
            foreach (Building bu in battleMap.buildings)
            {
                Button b = new Button();
                b.Location = new Point(bu.XPos * 35, bu.YPos * 35);
                b.Size = new Size(35, 35);
                b.Text = bu.Symbol;
                b.Font = new Font(b.Font.FontFamily, 13);
                if (bu.Team == 0)
                {
                    b.BackColor = Color.Black;
                    b.ForeColor = Color.AntiqueWhite;
                }
                else
                {
                    b.BackColor = Color.AntiqueWhite;
                    b.ForeColor = Color.Black;
                }
                b.Click += buildingClick;
                pnlBattelField.Controls.Add(b);

            }
            gameWindow.Controls.Add(pnlBattelField);
        }

        // triggers on the clicking of a unit
        public void unitClick(Object selectedUnit , EventArgs e)
        {
            foreach (Unit u in battleMap.units)
            {
                //checks if the button clicks matches the x and y of the unit
                if (((((Button)selectedUnit).Location.X / 35)==u.XPos) && ((((Button)selectedUnit).Location.Y / 35) == u.YPos))
                {
                    // writes unit tostring to richtextbox
                    gameWindow.displaySelected(u.ToString());
                }
            }
        }

        // triggers on the clicking of a buildigs
        public void buildingClick(Object selectedBuilding, EventArgs e)
        {
            
            foreach (Building u in battleMap.buildings)
            {
                //checks if the button clicks matches the x and y of the building
                if (((((Button)selectedBuilding).Location.X / 35) == u.XPos) && ((((Button)selectedBuilding).Location.Y / 35) == u.YPos))
                {
                    // writes building tostring to richtextbox
                    gameWindow.displaySelected(u.ToString());
                }
            }
        }

        public void UpdateBuilding()
        {
            foreach (Building b in battleMap.buildings)
            {
                //checks building subclass type
                if ((b.GetType()).Equals(typeof(ResourceBuilding)))
                {
                    ((ResourceBuilding)b).Extract(); // mines reasources
                }
                
                else if ((b.GetType()).Equals(typeof(FactoryBuilding))) 
                {
                    // checks if the raound number is divisible by the spawn rate
                    if (Round % (((FactoryBuilding)b).ProductionSpeed) == 0)
                    {
                        //realoading array with the new unit
                        Unit[] newUnits = new Unit[(battleMap.units.Length) + 1];
                        for (int i = 0; i < newUnits.Length-1; i++)
                        {
                            newUnits[i] = battleMap.units[i];
                        }
                        newUnits[newUnits.Length-1] = ((FactoryBuilding)b).Spawn();

                        battleMap.units = newUnits;
                    }
                }

            }
            this.UpdatePannle();

        }

        public void UpdateUnits()
        {
            foreach (Unit u in battleMap.units)
            {
                //checks if they should die
                if (u.Health<=0)
                {
                    //deletes from array cause i coulnt figure out how to do this from the subclass death method.
                    var unitList = battleMap.units.ToList();
                    unitList.Remove(u);
                    battleMap.units = unitList.ToArray();
                }
                //checks iff they should run
                else if (u.Health <= (u.HealthMax * 0.25))
                {
                    //runs in a random direction
                    u.move(rnd.Next(0, 3), rnd.Next(0, 3));
                }
                else
                {
                    //chscks if the unite that is closes is in range of attack
                    if (u.inRange(u.nearby(battleMap.units)))
                    {
                        //douse an attack
                        u.combat(u.nearby(battleMap.units));
                    }
                    //this is where they run headlong at the enemy
                    else
                    {
                        Unit enemy = u.nearby(battleMap.units);

                        // horisontal check
                        if ((u.XPos - enemy.XPos) == 0)
                        {
                            u.move(0, 0);
                        }
                        else if ((u.XPos-enemy.XPos) < 0)
                        {
                            u.move(1, 0);
                        }
                        else
                        {
                            u.move(2, 0);
                        }

                        //vertical check
                        if ((u.YPos - enemy.YPos) == 0)
                        {
                            u.move(0, 0);
                        }
                        else if ((u.YPos - enemy.YPos) < 0)
                        {
                            u.move(0, 1);
                        }
                        else
                        {
                            u.move(0, 2);
                        }
                    }
                }
            }
            this.UpdatePannle();
            
        }

        //was gonna use this for collision detection but gave up...
        //public bool ChekLocation(int x, int y)
        //{
        //    bool isOpen = true;
        //    foreach (Unit u in battleMap.units)
        //    {
        //        if ((u.XPos == x) &&(u.YPos==y))
        //        {
        //            isOpen = false;
        //        }
        //    }
        //    foreach (Building b in battleMap.buildings)
        //    {
        //        if ((b.XPos == x) && (b.YPos == y))
        //        {
        //            isOpen = false;
        //        }
        //    }
        //    return isOpen;
        //}

        public void Save()
        {
            battleMap.Save();
        }
        public void Load()
        {
            battleMap.Load();
            UpdatePannle();
        }
    }

    

}
