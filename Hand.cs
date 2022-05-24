using System;
using System.Collections.Generic;
using System.Linq;
namespace cards
{
    class Hand
    {
        public List<Card> cardsInHand = new List<Card>();
        public Hand(Deck deck)
        {
            if (deck.cardDeck.Count() - 1 >= 1)
            {
                Random rnd = new Random();
                for (int i = 0; i < 5; i++)
                {
                    int cardToTake = rnd.Next(0, deck.cardDeck.Count() - 1);
                    cardsInHand.Add(new Card(deck.cardDeck[cardToTake].Suit, deck.cardDeck[cardToTake].Number, deck.cardDeck[cardToTake].Value));
                    deck.cardDeck.RemoveAt(cardToTake);
                }
            }
        }
        
        public int PointsValue()
        {
            int handPoints = 0;
            for (int i = 0; i < 5; i++)
            {
                handPoints += this.cardsInHand[i].Value;
            }
            return handPoints;
        }
    }
}
