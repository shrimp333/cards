using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace cards
{
    class Program
    {
        static void Main()
        {

            Deck cardDeck = new Deck(true);
            Hand hand = new Hand(cardDeck);
            Console.Clear();

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
                            Console.Clear();
                            Console.WriteLine("Deck Created");
                            break;
                        case 2:
                            cardDeck = shuffle(cardDeck);
                            Console.Clear();
                            Console.WriteLine("Deck Shuffled");
                            break;
                        case 3:
                            if (cardDeck.cardDeck.Count() >= 5)
                            {
                                hand = dealHand(cardDeck);
                                Console.Clear();
                                Console.WriteLine("Hand Dealt");
                            }
                            else
                                Console.WriteLine("Deck is out of cards");
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine($"The value of your hand is {hand.PointsValue()}");
                            break;
                        case 5:
                            Console.Clear();
                            exit(hand);
                            break;
                    }
                }
            }
        }
        static Hand dealHand(Deck cardDeck) => new Hand(cardDeck);
        static Deck createDeck() => new Deck(false);
        static Deck shuffle(Deck deck)
        {
            Random rnd = new Random();
            deck.cardDeck = deck.cardDeck.OrderBy(x => rnd.Next()).ToList();
            return deck;
        }
        static void exit(Hand hand)
        {
            using (StreamWriter writer = new StreamWriter("./hand.csv", false))
            {
                for (int i = 0; i < 5; i++)
                {
                    writer.WriteLine($"{hand.cardsInHand[i].Number},{hand.cardsInHand[i].Suit},{hand.cardsInHand[i].Value}");
                }
            }
            Environment.Exit(0);
        }
    }
}