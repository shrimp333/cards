using System;
namespace cards
{
    class Card
    {
        public string Suit { get; set; }
        public string Number { get; set; }
        public int Value { get; set; }
        public Card(string pSuit, string pNumber, int pValue)
        {
            Suit = pSuit;
            Number = pNumber;
            Value = pValue;
        }
    }
}