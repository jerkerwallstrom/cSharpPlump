using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsApp.Source
{
    public class ImageInfo
    {
        public CardSuits suit;
        public CardRanks rank;
        public Image image;
        public string fileName;
    }

    public class CardDeck
    {
        public List<Card> deck = null;

        private List<ImageInfo> images = new List<ImageInfo>();
        public CardDeck()
        {
            LoadImages();
            SetupDeck();
        }

        private void LoadImages()
        {
            //Read files from folder images
            string targetDirectory = "C:\\Users\\a403326\\Documents\\TestProj\\TestWindowsApp\\Images";
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            //Create an image (ImageInfo) from info in one file

            foreach (string jpgFile in fileEntries)
            {
                string uniqueName = Path.GetFileNameWithoutExtension(jpgFile);
                string[] sep = uniqueName.Split('_');
                string szSuit = sep[0];
                string szRank = sep[1];
                //Set Suit
                CardSuits aSuit = GetSuit(szSuit);
                CardRanks aRank = GetRank(szRank);

                ImageInfo imageInfo = new ImageInfo();
                imageInfo.rank = aRank;
                imageInfo.suit = aSuit;
                imageInfo.fileName = jpgFile;
                imageInfo.image = Image.FromFile(jpgFile);

                //Add image to images list
                images.Add(imageInfo);
            }

        }

        private CardRanks GetRank(string szRank)
        {
            switch (szRank.ToUpper())
            {
                case "A": { return CardRanks.Ace; }
                case "2": { return CardRanks.two; }
                case "3": { return CardRanks.three; }
                case "4": { return CardRanks.four; }
                case "5": { return CardRanks.five; }
                case "6": { return CardRanks.six; }
                case "7": { return CardRanks.seven; }
                case "8": { return CardRanks.eight; }
                case "9": { return CardRanks.nine; }
                case "10": { return CardRanks.ten; }
                case "J": { return CardRanks.jack; }
                case "Q": { return CardRanks.queen; }
                case "K": { return CardRanks.king; }
            }
            return CardRanks.two;

        }

        private CardSuits GetSuit(string szSuit)
        {
            switch (szSuit.ToLower())
            {
                case "spade":
                    {
                        return CardSuits.spades;
                        break;
                    }
                case "heart":
                    {
                        return CardSuits.hearts; break;
                    }
                case "diamond":
                    {
                        return CardSuits.diamonds; break;
                    }
                case "club":
                    {
                        return CardSuits.clubs; break;
                    }
            }
            return CardSuits.clubs;
        }

        private void SetupDeck()
        {
            if (deck == null)
            {
                deck = new List<Card>();
            }
            else
            {
                deck.Clear();
            }
            foreach (CardSuits suit in Enum.GetValues(typeof(CardSuits)))
            {
                foreach (CardRanks rank in Enum.GetValues(typeof(CardRanks)))
                {
                    Card card = new Card(suit, rank);
                    card.image = GetImages(suit, rank);
                    deck.Add(card);
                }
            }
        }

        private Image GetImages(CardSuits suit, CardRanks rank)
        {
            foreach(var imageInfo in images)
            {
                if ((imageInfo.rank == rank) && (imageInfo.suit == suit))
                {
                    return imageInfo.image;
                }
            }
            return null;
        }

        private void ResetDeck()
        {
            if (deck == null)
            {
                deck = new List<Card>();
            }
            else
            {
                deck.Clear();
            }
        }

        public Card GetCard()
        {
            if (deck.Count() > 0)
            {
                Card aCard = deck[0];
                deck.Remove(aCard);
                return aCard;
            }
            return null;
        }

        public void Shuffle()
        {
            ResetDeck();
            SetupDeck();
            Shuffle(deck); //<Card>();
        }

        //public static void Shuffle<T>(this IList<T> list)
        private void Shuffle(List<Card> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

}
