using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace race
{
    public class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random MyRandom;

        public bool Run()
        {
            
            int distance = MyRandom.Next(0, 30);
            UpdateMyPictureBox(distance);
            Location += distance;
            if(Location > (RacetrackLength - StartingPosition))
                return true;
            return false;

        }

        public void UpdateMyPictureBox(int distance)
        {
            var x = MyPictureBox.Location;
            x.X += distance;
            MyPictureBox.Location = x;
        }

        public void TakeStartingPosition()
        {
            this.MyPictureBox.Left = this.StartingPosition;
            this.Location = 0;
        }
    }
}

