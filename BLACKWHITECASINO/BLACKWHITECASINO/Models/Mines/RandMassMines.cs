using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandMassMinesClass
{
    public class RandMassMines
    {
        Random elemPick = new Random();
        public int[] elemMass = new int[3];
        
        //for (int fori = 0; fori <= 5; fori++)
        //                {
        //                    totalElemMass[i] = rndMssMns.RandMass();
        //                }

        public void RandMass()
        {
            int bHelp = 0;
            do
            {
                elemMass[0] = elemPick.Next(1, 4);
                elemMass[1] = elemPick.Next(1, 4);
                elemMass[2] = elemPick.Next(1, 4);

                if (elemMass[1] == elemMass[0])
                    elemMass[1] = elemPick.Next(1, 4);
                else if (elemMass[2] == elemMass[1] || elemMass[2] == elemMass[0])
                    elemMass[2] = elemPick.Next(1, 4);
                else
                    bHelp++;
            }
            while (bHelp != 3);


        }
    }
}