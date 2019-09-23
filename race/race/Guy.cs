using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace race
{
    public class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;
        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            if (this.MyBet != null)
            {
                this.MyLabel.Text = this.MyBet.GetDescription();
            }
            else
            {
                MyLabel.Text = this.Name + " nie zawarł zakładu";
            }
            this.MyRadioButton.Text = this.Name + " ma " + this.Cash + " zł";
        }
        public void ClearBet()
        {
            this.MyBet.Amount = 0;
        }
        public bool PlaceBet(int Amount, int DogToWin)
        {
            if(this.Cash >= Amount)
            {
                this.MyBet = new Bet() { Amount = Amount, Dog = DogToWin, Bettor = this };
                this.MyBet.Amount = Amount;
                return true;
            }
            return false;
        }

        public void Collect(int Winner)
        {
            this.Cash += this.MyBet.PayOut(Winner);
        }
    }
}
