using System;
using System.Collections.Generic;
using System.IO;
namespace cards
{
    class Deck
    {
        public List<Card> cardDeck = new List<Card>();
        public Deck(bool loading)
        {
            if (!loading)
            {
                Dictionary<int, string> cardDict = new Dictionary<int, string>()
                {
                    {1, "ace"},
                    {2, "2"},
                    {3, "3"},
                    {4, "4"},
                    {5, "5"},
                    {6, "6"},
                    {7, "7"},
                    {8, "8"},
                    {9, "9"},
                    {10, "10"},
                    {11, "Jack"},
                    {12, "Queen"},
                    {13, "King"}
                };
                for (int i = 1; i <= 13; i++)
                {
                    cardDeck.Add(new Card("Heart", cardDict[i], i));
                }
                for (int i = 1; i <= 13; i++)
                {
                    cardDeck.Add(new Card("Diamond", cardDict[i], i));
                }
                for (int i = 1; i <= 13; i++)
                {
                    cardDeck.Add(new Card("Spades", cardDict[i], i));
                }
                for (int i = 1; i <= 13; i++)
                {
                    cardDeck.Add(new Card("Club", cardDict[i], i));
                }
            }
            else
            {
                string filePath = "./hand.csv";
                if (File.Exists(filePath))
                {
                    string[] arr = File.ReadAllLines(filePath);
                    foreach (string s in arr)
                    {
                        string [] cardToAdd = s.Split(',');
                        cardDeck.Add(new Card(cardToAdd[1],cardToAdd[0],int.Parse(cardToAdd[2])));
                    }
                }
            }
        }
    }
}
