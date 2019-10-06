using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace RTS_POE
{
    public partial class GameWindow : Form
    {
        
        //initialises game engine
        GameEngine engine;

        

        public void updateBattleLog(string info){
            lbxBattleLog.Items.Add(info);
        }

        //methos used to display the clicked buttons info in the rich textbox
        public void displaySelected(string unitInfo)
        {
            rtbUnitInfo.Clear();
            rtbUnitInfo.Text = unitInfo;
        }
        
        //this is just a normal everyday constructor ...
        public GameWindow()
        {
            InitializeComponent();
            engine = new GameEngine(this, this.gbxUntilUI,this.pnlBattleField);

            engine.UpdatePannle();
        }

        private void lblRound_Click(object sender, EventArgs e)
        {

        }

        //on start
        private void btnStartStop_Click(object sender, EventArgs e)
        {
            // start timer
            tmrClock.Start();
           
        }

        private void TmrClock_Tick(object sender, EventArgs e)
        {
            // this handles all the actions on a clock tick
            //like update units
            engine.UpdateUnits();
            //and buildings
            engine.UpdateBuilding();
            //and round increase
            lblRound.Text = "Round " + engine.Round;
            engine.Round += 1;
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            // this stops the clock.
            tmrClock.Stop();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            engine.Save();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            engine.Load();
        }
    } 
}
