using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    internal class LinCode
    {
        //This function handles main menu interaction
        public void Menu()
        {
            //options in main menu
            Console.WriteLine("1: Instructions \n" +
                "2: Deal 3 cards \n" +
                "3: Deal 5 cards \n" +
                "4: Quit \n");
            //input allows user to navigate the math tutor 
            string Input = Console.ReadLine();
            int RealInput = 0;
            try
            {
                RealInput = int.Parse(Input);
            }
            catch { Menu(); }
            //this switch statement checks which option was selected
            switch (RealInput) {
                case 1:
                    //Instructions display all information on how to use this application
                    Instructions();
                    Console.ReadLine();
                    Menu();
                    break;
                case 2:
                    //this selection deals 3 cards and prints out an equation for user to solve
                    new Calculation().InputHandling(3);
                    Menu();
                    break;
                case 3:
                    //this selection deals 5 cards and prints out an equation for user to solve
                    new Calculation().InputHandling(5);
                    Menu();
                    break;
                case 4:
                    //this option closes the application
                    Console.WriteLine("GoodBye");
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("invalid input");
                    Menu();
                    break;
            }
        }

        //this function displays the instruction by reading the text file in which they are contained.
        private void Instructions()
        {
            string[] lines = File.ReadAllLines("Instructions.txt");
            foreach(string line in lines){
                Console.WriteLine(line);
            }
        }
    }
}
