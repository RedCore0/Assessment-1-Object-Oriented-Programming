using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //The 'set' methods for these properties could have some validation
        public int Value { get; set; }
        public int Suit { get; set; }

        public Card(int value, int suit)
        {
            //Checks if card value is possible, if it is the value is assigned to the card
            if(value >= 1 && value <= 13)
            {
                Value = value;
            }
            else
            {
                throw new Exception("Card cannot have a value of " + value);
            }

            //Checks if card suit is possible, if it is the suit is assigned to the card
            if (suit >= 1 && suit <= 4)
            {
                Suit = suit;
            }
            else
            {
                throw new Exception("Card cannot have a suit of " + suit);
            }
        }
    }
}
