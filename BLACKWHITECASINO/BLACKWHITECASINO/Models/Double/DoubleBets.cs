using BetClass;
using BLACKWHITECASINO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoubleBetsClass
{
    public class DoubleBets
    {
        public static int Red { get; set; }
        public static int Black { get; set; }
        public static int White { get; set; }
        public static int Even { get; set; }
        public static int NotEven { get; set; }
        public static int LowRange { get; set; }
        public static int BigRange { get; set; }

        public static int TotalBetRed { get; set; }
        public static int TotalBetBlack { get; set; }
        public static int TotalBetWhite { get; set; }
        public static int TotalBetEven { get; set; }
        public static int TotalBetNotEven { get; set; }
        public static int TotalBetLowRange { get; set; }
        public static int TotalBetBigRange { get; set; }


        public static int TotalBet { get; set; }

        //ставки и изменение их в тексте
        public void WhiteUp(Bet x)
        {
            White += Bet.betTotal;
        }
        public void BlackUp(Bet x)
        {
            Black += Bet.betTotal;
        }
        public void RedUp(Bet x)
        {
            Red += Bet.betTotal;
        }
        public void EvenUp(Bet x)
        {
            Even += Bet.betTotal;
        }
        public void NotEvenUp(Bet x)
        {
            NotEven += Bet.betTotal;
        }
        public void LowRangeUp(Bet x)
        {
            LowRange += Bet.betTotal;
        }
        public void BigRangeUp(Bet x)
        {
            BigRange += Bet.betTotal;
        }

        //Общая сумма ставок
        public void TotalBetUp(Bet x)
        {
            TotalBet += Bet.betTotal;
        }

        public void TotalBetClear()
        {
            TotalBet = 0;
        }


        //Общая сумма ставок по-отдельности
        public void TotalBetRedUp(Bet x)
        {
            TotalBetRed += Bet.betTotal;
        }

        public void TotalBetBlackUp(Bet x)
        {
            TotalBetBlack += Bet.betTotal;
        }

        public void TotalBetWhiteUp(Bet x)
        {
            TotalBetWhite += Bet.betTotal;
        }

        public void TotalBetEvenUp(Bet x)
        {
            TotalBetEven += Bet.betTotal;
        }

        public void TotalBetNotEvenUp(Bet x)
        {
            TotalBetNotEven += Bet.betTotal;
        }

        public void TotalBetLowRangeUp(Bet x)
        {
            TotalBetLowRange += Bet.betTotal;
        }

        public void TotalBetBigRangeUp(Bet x)
        {
            TotalBetBigRange += Bet.betTotal;
        }

        public void TotalBetRedClear()
        {
            TotalBetRed = 0;
        }

        public void TotalBetBlackClear()
        {
            TotalBetBlack = 0;
        }

        public void TotalBetWhiteClear()
        {
            TotalBetWhite = 0;
        }

        public void TotalBetEvenClear()
        {
            TotalBetEven = 0;
        }

        public void TotalBetNotEvenClear()
        {
            TotalBetNotEven = 0;
        }

        public void TotalBetLowRangeClear()
        {
            TotalBetLowRange = 0;
        }

        public void TotalBetBigRangeClear()
        {
            TotalBetBigRange = 0;
        }


        public void BetsClear()
        {
            Red = 0;
            Black = 0;
            White = 0;
            Even = 0;
            NotEven = 0;
            LowRange = 0;
            BigRange = 0;
        }

        public override string ToString()
        {
            if(Language.checkRu == true)
            {
                return "Белое: " + White +
                   "$\nЧёрное: " + Black +
                   "$\nКрасное: " + Red +
                   "$\nЧётное: " + Even +
                   "$\nНечётное: " + NotEven +
                   "$\n0-9: " + LowRange +
                   "$\n10-19: " + BigRange + "$";

            }
            else
            {
                return "White: " + White +
                "$\nBlack: " + Black +
                "$\nRed: " + Red +
                "$\nEven: " + Even +
                "$\nOdd: " + NotEven +
                "$\n0-9: " + LowRange +
                "$\n10-19: " + BigRange + "$";
            }
            
        }
    }
}

