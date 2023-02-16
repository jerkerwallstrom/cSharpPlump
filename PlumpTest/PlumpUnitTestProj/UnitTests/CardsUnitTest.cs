using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumpUnitTestProj.TestCode;
using TestWindowsApp.Source;

namespace PlumpUnitTestProj.UnitTests
{
    [TestClass]
    public class CardsUnitTest
    {
        [TestMethod]
        public void TestCreateCard()
        {
            Card cardH = new Card(CardSuits.hearts, CardRanks.queen);
            string szCardInfo = cardH.ToString();
            Assert.AreEqual("Hjärter dam", szCardInfo);

            Card cardS = new Card(CardSuits.spades, CardRanks.Ace);
            Assert.AreEqual("Spader Ace", cardS.ToString());

            Card cardR = new Card(CardSuits.diamonds, CardRanks.seven);
            Assert.AreEqual("Ruter 7", cardR.ToString());

            Card cardK = new Card(CardSuits.clubs, CardRanks.ten);
            Assert.AreEqual("Klöver 10", cardK.ToString());
        }

        [TestMethod]
        public void TestCreateCardDeck()
        {
            CardDeck cardDeck = new CardDeck();
            Assert.AreEqual(52, cardDeck.deck.Count);
            //Get Diamonds
            List<Card> diamonds = new List<Card>();
            foreach (var card in cardDeck.deck)
            {
                if (card.suit == CardSuits.diamonds)
                {
                    diamonds.Add(card);
                }
            }
            Assert.AreEqual(13, diamonds.Count);
            for (int i = 0; i < diamonds.Count; i++)
            {
                for (int j = 0; j < diamonds.Count; j++)
                {
                    if (i != j)
                    {
                        Assert.AreNotEqual(diamonds[i].rank, diamonds[j].rank);
                    }
                }
            }
        }

        [TestMethod]
        public void TestShuffleCardDeck()
        {
            CardDeck cardDeck = new CardDeck();
            Assert.AreEqual(52, cardDeck.deck.Count);
            List<Card> startDeck = new List<Card>();
            foreach (var card in cardDeck.deck)
            {
                Card newCard = new Card(card.suit, card.rank);
                startDeck.Add(newCard);
            }
            cardDeck.Shuffle();
            Assert.AreEqual(52, cardDeck.deck.Count);
            List<Card> shuffledDeck = new List<Card>();
            foreach (var card in cardDeck.deck)
            {
                Card newCard = new Card(card.suit, card.rank);
                shuffledDeck.Add(newCard);
            }
            bool bResult = true;
            int iResult = 0;
            for (int i = 0; i < 52; i++)
            {
                if (startDeck[i].ToString() != shuffledDeck[i].ToString())
                {
                    bResult = false;
                    iResult++;
                }
            }
            Assert.IsFalse(bResult);
        }
        [TestMethod]
        public void TestGetCardFromDeck()
        {
            CardDeck cardDeck = new CardDeck();
            Assert.AreEqual(52, cardDeck.deck.Count);
            List<Card> startDeck = new List<Card>();
            foreach (var card in cardDeck.deck)
            {
                Card newCard = new Card(card.suit, card.rank);
                startDeck.Add(newCard);
            }
            foreach(var testCard in startDeck)
            {
                var card = cardDeck.GetCard();
                Assert.AreEqual(card.ToString(), testCard.ToString());

            }
            var tmpCard = cardDeck.GetCard();
            Assert.IsNull(tmpCard);
        }
    }
}
