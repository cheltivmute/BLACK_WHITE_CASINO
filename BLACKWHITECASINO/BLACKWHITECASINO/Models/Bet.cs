using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetClass
{
    public class Bet
    {
        public static int betTotal { get; set; }


        public void betUp(int x)
        {
            
            if (betTotal <= 99999)
                betTotal += x;
            else
            {
                throw new Exception("Максимальная сумма ставки: 99999$");
            }
        }

        public void betDown(int x)
        {
            if (betTotal > 0)
                betTotal -= x;
            else
            {
                throw new Exception("Минимальная сумма ставки: 10$");
            }
        }

        public void betClear()
        {
            betTotal = 0;
        }

        public override string ToString()
        {
            return betTotal + "";
        }

    }
}

