using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsApp.Source
{
    public enum CardSuits { spades, hearts, clubs, diamonds };

    public enum CardRanks { two=2, three=3, four=4, five=5,
        six=6, seven=7, eight=8, nine=9, ten=10, 
        jack=11, queen=12, king=13, Ace = 14};
    public class Card
    {
        private string[] suits = { "Spader", "Hjärter", "Klöver", "Ruter" };
        private string[] ranks = { "", "", "2", "3", "4", "5", "6", "7", "8", "9", "10",
            "knekt", "dam", "kung", "Ace" };
        public CardSuits suit;
        public CardRanks rank;
        public Image image;
        public Card(CardSuits aSuit, CardRanks aRank)
        {
            suit = aSuit;
            rank = aRank;
        }

        public string presentation()
        {
            return suits[(int)suit] + " " + ranks[(int)rank];
        }

        public override string ToString()
        {
            return presentation();
        }
    }
}
