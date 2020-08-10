using System;
using System.Collections.Generic;
using System.Text;

namespace Mancala
{
    class Player
    {
        public Pocket[] pockets = new Pocket[6];
        public Store store;

        public Player()
        {
            for (int i = 0; i < 6; i++)
                pockets[i] = new Pocket();
            store = new Store();
        }
        public String PrintPockets()
        {
            string printedPockets = "";

            for (int i = 0; i < 6; i++)
            {
                printedPockets = printedPockets + pockets[i].stones.ToString() + "  ";
            }
            return printedPockets;
        }

        public String ReversePrintPockets()
        {
            string printedPockets = "";

            for (int i = 5; i >= 0; i--)
            {
                printedPockets = printedPockets + pockets[i].stones.ToString() + "  ";
            }
            return printedPockets;
        }
    }
}
