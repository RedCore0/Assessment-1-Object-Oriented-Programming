using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        static List<Card> pack = new List<Card>();

        public Pack()
        {
            //creates a pack of cards
            for (int Value = 1; Value <= 13; Value++)
            {
                for (int Suit = 1; Suit <= 4; Suit++)
                {
                    Card card = new Card(Value, Suit);
                    pack.Add(card);
                }
            }
            Show();
        }
        
        public static void Show()
        {
            for (int i = 0; i < pack.Count; i++)
            {
                Console.WriteLine(pack[i].Value + " " + pack[i].Suit);
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle
            //when shuffled returns true else: return false
            switch (typeOfShuffle)
            {
                case 1:
                    //Fisher-Yates Shuffle
                    //creates new list and places random cards from pack into it
                    Console.WriteLine("Fisher-Yates Shuffle");
                    List<Card> shuffled_cards = new List<Card>();
                    Random random = new Random();
                    for (int i = 0; i < 52; i++)
                    {
                        int Rnd = random.Next(pack.Count);
                        shuffled_cards.Add(pack[Rnd]);
                        pack.Remove(pack[Rnd]);
                        Console.WriteLine(shuffled_cards[i].Value + " " + shuffled_cards[i].Suit);
                    }
                    pack = shuffled_cards;
                    return true;
                case 2:
                    //Riffle Shuffle
                    //Splits list into two and then puts cards from both halves in between eachother
                    Console.WriteLine("Riffle Shuffle");
                    
                    //////////////////////////
                    var Splitted = Split(pack);
                    List<List<T>> Split<T>(List<T> items, int size = 26)
                    {
                        //Splits deck in half for riffle shuffle
                        var list = new List<List<T>>();

                        for (int i = 0; i < items.Count; i += size)
                        {
                            list.Add(items.GetRange(i, Math.Min(size, items.Count - 1)));
                        }
                        return list;
                    }
                    //////////////////////////
                    pack.Clear();
                    int packOne = 0;
                    int packTwo = 0;
                    for (int i = 0; i < 52; i++)
                    {
                        if (i % 2 == 0)
                        {
                            pack.Add(Splitted[0][packOne]);
                            packOne++;
                        }
                        else
                        {
                            pack.Add(Splitted[1][packTwo]);
                            packTwo++;
                        }
                    }
                    Show();
                    return true;
                case 3:
                    //No Shuffle
                    return false;
                default:
                    throw new Exception("Shuffle type with this index does not exist");

            }
        }

        public static List<Card> dealCard(int amount)
        {
            //Deals the number of cards specified by 'amount'
            List<Card> list = new List<Card>();
            for (int i = 0; i < amount; i++)
            {
                list.Add(pack[i]);
                deal();
            }
            return list;
        }

        public static Card deal()
        {
            //Deals one card
            if(pack.Count > 0)
            {
                Card CardToDeal = pack[0];
                pack.Remove(pack[0]);
                Console.WriteLine("Deal " + CardToDeal.Value + " " + CardToDeal.Suit);
                return CardToDeal;
            }
            else { 
                throw new Exception("There are no more cards in the pack"); }
        }
    }
}
