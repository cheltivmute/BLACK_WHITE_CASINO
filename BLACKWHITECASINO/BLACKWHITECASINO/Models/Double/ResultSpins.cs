using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResultSpins
{
    public class ResultsSpins
    {
        public static string InfoResultSpinText = "";

        public static bool LowRangeWin { get; set; }
        public static bool BigRangeWin { get; set; }
        public static bool EvenWin { get; set; }
        public static bool NotEvenWin { get; set; }
        public static bool BlackWin { get; set; }
        public static bool WhiteWin { get; set; }
        public static bool RedWin { get; set; }

        public static bool LowRangeBet { get; set; }
        public static bool BigRangeBet { get; set; }
        public static bool EvenBet { get; set; }
        public static bool NotEvenBet { get; set; }
        public static bool BlackBet { get; set; }
        public static bool WhiteBet { get; set; }
        public static bool RedBet { get; set; }

        public static int[] LowRange = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        public static int[] BigRange = { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
        public static int[] Even = { 0, 2, 4, 6, 8, 10, 12, 14, 16, 18 };
        public static int[] NotEven = { 1, 3, 5, 7, 9, 11, 13, 15, 17, 19 };
        public static string Black = "Чёрное";
        public static string White = "Белое";
        public static string Red = "Красное";

        public static int WinNumber { get; set; }
        public static string WinColor { get; set; }

        public static string ResultSpin(int winNumber, string winColor)
        {
            WinNumber = winNumber;
            WinColor = winColor;

            foreach (int num1 in LowRange)
            {
                if (WinNumber == num1)
                    LowRangeWin = true;
            }
            foreach (int num2 in BigRange)
            {
                if (WinNumber == num2)
                    BigRangeWin = true;
            }
            foreach (int num3 in Even)
            {
                if (WinNumber == num3)
                    EvenWin = true;
            }
            foreach (int num4 in NotEven)
            {
                if (WinNumber == num4)
                    NotEvenWin = true;
            }
            if (winColor == Black)
                BlackWin = true;
            if (winColor == White)
                WhiteWin = true;
            if (winColor == Red)
                RedWin = true;

            return InfoResultSpinText + Convert.ToString(WinNumber) + ", " + WinColor;
        }
    }
}
