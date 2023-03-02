using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    internal class Testing
    {
        public void Test()
        {
            new Pack();
            Pack.shuffleCardPack(2);
            Pack.shuffleCardPack(1);
            Pack.deal();
            Pack.dealCard(5);
        }

    }
}
