using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace race
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            string description = "";
            if (this.Amount == 0)
            {
                return description += this.Bettor.Name + " nie zawarł zakładu";
            }
            else
                return description += this.Bettor.Name + " postawił " + this.Amount + " zł na psa numer " + this.Dog;
        }

        public int PayOut(int Winner)
        {
            if (this.Dog == Winner)
            {
                return Amount;
            }
            return -Amount;
        }
    }
}
