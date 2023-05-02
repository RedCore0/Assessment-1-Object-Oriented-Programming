using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CMP1903M_A01_2223
{

    class Calculation : LinCode
    {
        private List<Card> cards;

        //Input handling function manages user's input
        public void InputHandling(int NumberOfCards)
        {
            //creates a pack which is then shuffled and cards are dealt
            new Pack();
            Pack.shuffleCardPack(1);
            cards = Pack.dealCard(NumberOfCards);
            //Cards Value and suit are read and an equation is made based on them.
            string problem = Equation();
            Console.WriteLine(problem+"=");
            //sum is calculated
            DataTable dt = new DataTable();
            int sum;
            try { sum = (int)dt.Compute(problem, ".0"); }
            catch { sum = Convert.ToInt32((double)dt.Compute(problem, ".0")); }
            //code below allows user to input the answer which is then checked and program displays if answer is correct or not
            string input = Console.ReadLine();
            int RealInput = 0;
            try
            {
                RealInput = int.Parse(input);
            }
            catch { Console.WriteLine("Incorrect"); }

            if(RealInput == sum)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
            }
            //This gives user an option to deal again or to go back to main menu
            Console.WriteLine("1: Deal again 2: Back to menu");
            Options(NumberOfCards);
        }
        
        //This function is recursive. recusrion stops when user provides a valid input
        private void Options(int NumberOfCards)
        {
            string input = Console.ReadLine();
            switch (input) {
                case "1":
                    InputHandling(NumberOfCards);
                    break;
                case "2":
                    break;
                default:
                    Options(NumberOfCards);
                    break;
            }
        }

        //This function returns a string with an equation
        private string Equation() {
            string equation = "";
            //This for loop goes through all cards that have been dealt
            for (int i = 0; i < cards.Count; i++)
            {
                //this code checks if card represents a value or an operator based on its position in the list
                if (i%2 == 0)
                {
                    //if card represents a value its value is added to the string
                    equation += cards[i].Value.ToString();
                }
                else
                {
                    //if card represents an operator its suit is read and operator is added to the equation based on suit
                    switch (cards[i].Suit)
                    {
                        case 1:
                            equation += "+";
                            break;
                        case 2:
                            equation += "-";
                            break;
                        case 3:
                            equation += "*";
                            break;
                        case 4:
                            equation += "/";
                            break;
                    }
                }
            }
            //returns full equation as a string
            return equation;
        }
    }
}
