using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumpUnitTestProj.TestCode;
using TestWindowsApp.Source;

namespace PlumpUnitTestProj.UnitTests
{
    [TestClass]
    public class PlayersUnitTest
    {
        [TestMethod]
        public void TestAddPlayer()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");

            string kalle = "Kalle";

            Assert.AreEqual(1, game.players.Count);
            Assert.AreEqual(kalle, game.players[0].name);
            Assert.AreEqual(false, game.players[0].IsVirtualPlayer());
        }
        [TestMethod]
        public void TestAddVirtualPlayer()
        {
            Game game = new Game();
            game.AddVirtualPlayer("Virtual");

            string szVirtual = "Virtual";

            Assert.AreEqual(1, game.players.Count);
            Assert.AreEqual(szVirtual, game.players[0].name);
            Assert.AreEqual(true, game.players[0].IsVirtualPlayer());
        }

        [TestMethod]
        public void TestSeveralPlayer()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");
            game.AddVirtualPlayer("Virtual");
            game.AddPlayer("Lisa");
            game.AddVirtualPlayer("PC");

            Assert.IsTrue(0 < game.players.Count);
            Assert.IsTrue(4 == game.players.Count);
        }

        [TestMethod]
        public void TestMaximumPlayers()
        {
            Game game = new Game();
            game.AddPlayer("Number1");
            game.AddPlayer("Number2");
            game.AddPlayer("Number3");
            game.AddPlayer("Number4");
            game.AddPlayer("Number5");
            game.AddPlayer("Number6");
            game.AddPlayer("Number7");
            game.AddPlayer("Number8");
            game.AddPlayer("Number9");
            game.AddPlayer("Number10");
            Player notAllow = game.AddPlayer("Number11");

            Assert.IsTrue(0 < game.players.Count);
            Assert.IsTrue(10 == game.players.Count);
            Assert.IsNull(notAllow);
        }

        [TestMethod]
        public void TestNameAlreadyExistForPlayer()
        {
            Game game = new Game();
            game.AddPlayer("Number1");
            game.AddPlayer("Number2");
            game.AddPlayer("Number3");
            game.AddPlayer("Number4");
            var notAllow = game.AddPlayer("nUMBer1");
            Assert.IsNull(notAllow);

        }

        [TestMethod]
        public void TestRemovPlayer()
        {
            Game game = new Game();
            game.AddPlayer("Number1");
            game.AddPlayer("Number2");
            var toRemove = game.AddPlayer("Number3");
            game.AddPlayer("Number4");
            game.c_RemovePlayer(toRemove, null);
            Assert.AreEqual(3, game.players.Count);
            foreach(var player in game.players)
            {
                Assert.AreNotEqual("Number3", player.name);
            }

        }

        [TestMethod]
        public void TestSortCardsRanks()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.Ace));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.king));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.five));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.ten));

            player.SortMyCards();

            List<Card> sortedCards = new List<Card>();
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.four));
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.five));
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.eight));
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.ten));
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.jack));
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.king));
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.Ace));


            int i = 0;
            foreach (var card in player.GetCards())
            {
                Assert.AreEqual(card.ToString(), sortedCards[i].ToString());
                i++;
            }

        }

        [TestMethod]
        public void TestSortCardsSuits()
        {
            //CardDeck cardDeck = new CardDeck();
            //Assert.AreEqual(52, cardDeck.deck.Count);
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.clubs, CardRanks.Ace));
            player.DealAdd(new Card(CardSuits.clubs, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.diamonds, CardRanks.four));
            player.DealAdd(new Card(CardSuits.diamonds, CardRanks.king));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.five));
            player.DealAdd(new Card(CardSuits.spades, CardRanks.six));
            player.DealAdd(new Card(CardSuits.spades, CardRanks.queen));

            player.SortMyCards();

            List<Card> sortedCards = new List<Card>();
            sortedCards.Add(new Card(CardSuits.spades, CardRanks.six));
            sortedCards.Add(new Card(CardSuits.spades, CardRanks.queen));
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.five));
            sortedCards.Add(new Card(CardSuits.hearts, CardRanks.jack));
            sortedCards.Add(new Card(CardSuits.clubs, CardRanks.eight));
            sortedCards.Add(new Card(CardSuits.clubs, CardRanks.Ace));
            sortedCards.Add(new Card(CardSuits.diamonds, CardRanks.four));
            sortedCards.Add(new Card(CardSuits.diamonds, CardRanks.king));


            int i = 0;
            foreach (var card in player.GetCards())
            {
                Assert.AreEqual(card.ToString(), sortedCards[i].ToString());
                i++;
            }

        }

        [TestMethod]
        public void TestSelectAndPlayBestCardAsStartPlayer()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.Ace));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.SortMyCards();
            player.SetStickToWin(2);
            Card playedCard = player.PlayCard();

            Assert.AreEqual(playedCard.ToString(), new Card(CardSuits.hearts, CardRanks.Ace).ToString());

        }
        [TestMethod]
        public void TestSelectAndPlayBestCardToBeatCardToBeat()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.six));
            player.SortMyCards();
            player.SetStickToWin(2);
            player.cardToBeat = new Card(CardSuits.hearts, CardRanks.seven);
            Card playedCard = player.PlayCard();

            Assert.AreEqual(playedCard.ToString(), new Card(CardSuits.hearts, CardRanks.jack).ToString());

        }

        [TestMethod]
        public void TestSelectAndPlayBestCardToNotBeatCardToBeat()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.six));
            player.SortMyCards();
            player.SetStickToWin(2);
            player.AddStick();
            player.AddStick();
            player.cardToBeat = new Card(CardSuits.hearts, CardRanks.seven);
            Card playedCard = player.PlayCard();

            Assert.AreEqual(playedCard.ToString(), new Card(CardSuits.hearts, CardRanks.six).ToString());

        }

        [TestMethod]
        public void TestSelectAndPlayBestCardFollowSuitLower1()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.spades, CardRanks.eight));
            player.SortMyCards();
            player.SetStickToWin(2);
            player.cardToBeat = new Card(CardSuits.spades, CardRanks.ten);
            Card playedCard = player.PlayCard();

            Assert.AreEqual(playedCard.ToString(), new Card(CardSuits.spades, CardRanks.eight).ToString());

        }

        [TestMethod]
        public void TestSelectAndPlayBestCardToNotWin1()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.six));
            player.SortMyCards();
            player.SetStickToWin(2);
            player.AddStick();
            player.AddStick();
            player.cardToBeat = new Card(CardSuits.spades, CardRanks.seven);
            Card playedCard = player.PlayCard();

            Assert.AreEqual(playedCard.ToString(), new Card(CardSuits.hearts, CardRanks.jack).ToString());

        }

        [TestMethod]
        public void TestSelectAndPlayBestCardToNotWin2()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.six));
            player.SortMyCards();
            player.SetStickToWin(2);
            player.cardToBeat = new Card(CardSuits.spades, CardRanks.seven);
            Card playedCard = player.PlayCard();

            Assert.AreEqual(playedCard.ToString(), new Card(CardSuits.hearts, CardRanks.four).ToString());

        }

        [TestMethod]
        public void TestSelectAndPlayBestCardFollowSuit()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.spades, CardRanks.eight));
            player.SortMyCards();
            player.SetStickToWin(2);
            player.AddStick();
            player.AddStick();
            player.cardToBeat = new Card(CardSuits.spades, CardRanks.seven);
            Card playedCard = player.PlayCard();

            Assert.AreEqual(playedCard.ToString(), new Card(CardSuits.spades, CardRanks.eight).ToString());

        }
        [TestMethod]
        public void TestSelectAndPlayBestCardFollowSuitLower2()
        {
            Player player = new Player("Kalle", false);
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.eight));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.four));
            player.DealAdd(new Card(CardSuits.hearts, CardRanks.jack));
            player.DealAdd(new Card(CardSuits.spades, CardRanks.six));
            player.DealAdd(new Card(CardSuits.spades, CardRanks.eight));
            player.SortMyCards();
            player.SetStickToWin(2);
            player.AddStick();
            player.AddStick();
            player.cardToBeat = new Card(CardSuits.spades, CardRanks.seven);
            Card playedCard = player.PlayCard();

            Assert.AreEqual(playedCard.ToString(), new Card(CardSuits.spades, CardRanks.six).ToString());

        }

    }
}
