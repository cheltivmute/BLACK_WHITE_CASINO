using BetClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalClass
{
    public class Total
    {
        public static double TotalSumm { get; set; }

        public Total(double x)
        {
            TotalSumm = x;
        }

        public void TotalUp(double x)
        {
            TotalSumm += x;
        }

        public void TotalDown(double x)
        {
            TotalSumm -= x;
        }

        public void TotalDown(Bet x)
        {
            TotalSumm -= Bet.betTotal;
        }

        public override string ToString()
        {
            return Convert.ToString(TotalSumm);
        }
    }
}
