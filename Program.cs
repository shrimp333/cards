using System;
using System.Collections.Generic;
using System.Linq;
namespace cards
{
    class Program
    {
        static void Main()
        {
            Deck cardDeck = createDeck();
            while (true)
            {
                while (true)
                {
                    int inputNum;
                    while (true)
                    {
                        Console.WriteLine("1. Create new Deck\n2. Shuffle Deck\n3. Deal New Hand\n4. Display Hand Total Points\n5. Exit\nEnter the number for the action you wish to complete");
                        string input = Console.ReadLine().Trim();

                        if (char.IsDigit(input, 0))
                        {

                            inputNum = (int)char.GetNumericValue(input[0]);
                            if (1 <= inputNum && inputNum <= 5)
                                break;
                        }
                        Console.Clear();
                        Console.WriteLine("Incorrect Input");
                        //checks to see if input was a digit between 1 and 5 if not loops back on itself
                    }
                    switch (inputNum)
                    {
                        case 1:
                            cardDeck = createDeck();
                            break;
                        case 2:
                            shuffle(cardDeck);
                            break;
                        case 3:

                            break;
                        case 4:
                            break;
                        case 5:
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }
        static Deck createDeck() => new Deck();

        static void shuffle(Deck deck)
        {
            deck.cardDeck.OrderBy(x => Guid.NewGuid()).ToList();
        }

        static void dealHand()
        {
            Random rnd = new Random();
        }
    }
}