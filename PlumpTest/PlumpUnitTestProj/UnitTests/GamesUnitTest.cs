using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumpUnitTestProj.TestCode;
using TestWindowsApp.Source;

namespace PlumpUnitTestProj.UnitTests
{
    [TestClass]
    public class GamesUnitTest
    {
        [TestMethod]
        public void TestSetFirstBetter()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");
            game.AddVirtualPlayer("Virtual");
            game.AddPlayer("Lisa");
            game.AddVirtualPlayer("PC");

            var firstBetter = game.SetFirstBetter();

            string kalle = "Kalle";

            Assert.AreEqual(kalle, firstBetter.name);
        }

        [TestMethod]
        public void TestDeal()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");
            game.AddVirtualPlayer("Virtual");
            game.AddPlayer("Lisa");
            game.AddVirtualPlayer("PC");

            var firstBetter = game.SetFirstBetter();

            game.Deal();

            Assert.IsTrue(4 == game.players.Count);
            foreach (var player in game.players)
            {
                Assert.IsTrue(10 == player.cards.Count);
            }

        }

        [TestMethod]
        public void TestSetBet()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");
            game.AddVirtualPlayer("Virtual");
            game.AddPlayer("Lisa");
            game.AddVirtualPlayer("PC");

            var firstBetter = game.SetFirstBetter();

            game.Deal();

            firstBetter.SetStickToWin(4);

            Assert.AreEqual(4, game.players[0].stickToWin);
        }

        [TestMethod]
        public void TestSetBetValidationNOk()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");
            game.AddPlayer("Sluggo");
            game.AddPlayer("Stina");
            game.AddPlayer("Lisa");

            var firstBetter = game.SetFirstBetter();

            game.Deal();

            int testTotalSticks = 2;
            firstBetter.SetStickToWin(2);
            game.SetStick(firstBetter);

            testTotalSticks = TestCodeFunctions.incBet(game, 2, testTotalSticks);
            testTotalSticks = TestCodeFunctions.incBet(game, 2, testTotalSticks);
            var next = game.selPlayer;
            next.SetStickToWin(10 - testTotalSticks);
            bool res = game.SetStick(next);
            Assert.IsFalse(res);

        }

        [TestMethod]
        public void TestSetBetValidationOk()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");
            game.AddPlayer("Sluggo");
            game.AddPlayer("Stina");
            game.AddPlayer("Lisa");

            var firstBetter = game.SetFirstBetter();

            game.Deal();

            int testTotalSticks = 2;
            firstBetter.SetStickToWin(2);
            game.SetStick(firstBetter);

            testTotalSticks = TestCodeFunctions.incBet(game, 2, testTotalSticks);
            testTotalSticks = TestCodeFunctions.incBet(game, 2, testTotalSticks);
            var next = game.selPlayer;
            next.SetStickToWin(9 - testTotalSticks);
            bool res = game.SetStick(next);
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void TestStartPlayGame()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");
            game.AddPlayer("Sluggo");
            game.AddPlayer("Stina");
            game.AddPlayer("Lisa");

            var firstBetter = game.SetFirstBetter();

            game.Deal();

            int testTotalSticks = 2;
            firstBetter.SetStickToWin(2);
            game.SetStick(firstBetter);

            testTotalSticks = TestCodeFunctions.incBet(game, 2, testTotalSticks);
            testTotalSticks = TestCodeFunctions.incBet(game, 2, testTotalSticks);
            var next = game.selPlayer;
            next.SetStickToWin(9 - testTotalSticks);
            bool res = game.SetStick(next);
            Assert.IsTrue(res);
            Player start = game.GetStartPlayer();
            Assert.AreEqual(start.name, "Lisa");
            game.StartRound(start);
            start.PlayCard();
            Card playedCard = start.selected;
            game.Play(start);
            Assert.AreEqual(playedCard.ToString(), game.cardToBeat.ToString());
            Card myCardTobeat = TestCodeFunctions.GetBestCard(playedCard, game.cardToBeat);

            var tmpPlayer = TestCodeFunctions.PlayNextCard(game);
            Assert.AreEqual(tmpPlayer.name, "Kalle");
            myCardTobeat = TestCodeFunctions.GetBestCard(tmpPlayer.selected, myCardTobeat);

            tmpPlayer = TestCodeFunctions.PlayNextCard(game);
            Assert.AreEqual(tmpPlayer.name, "Sluggo");
            myCardTobeat = TestCodeFunctions.GetBestCard(tmpPlayer.selected, myCardTobeat);

            tmpPlayer = TestCodeFunctions.PlayNextCard(game);
            Assert.AreEqual(tmpPlayer.name, "Stina");

            var tmpWinner = game.winnerRound;
            Assert.IsNotNull(tmpWinner);

            Assert.AreEqual(myCardTobeat, game.cardToBeat);

        }

        [TestMethod]
        public void TestSetStartPlayer()
        {
            Game game = new Game();
            game.AddPlayer("Kalle");
            game.AddPlayer("Sluggo");
            game.AddPlayer("Stina");
            game.AddPlayer("Lisa");

            var firstBetter = game.SetFirstBetter();
            //goto next player..
            firstBetter = game.SetFirstBetter();
            Assert.AreEqual(firstBetter.name, "Sluggo");

            game.Deal();

            int testTotalSticks = 2;
            firstBetter.SetStickToWin(2);
            game.SetStick(firstBetter);

            testTotalSticks = TestCodeFunctions.incBet(game, 3, testTotalSticks);
            testTotalSticks = TestCodeFunctions.incBet(game, 2, testTotalSticks);
            var next = game.selPlayer;
            next.SetStickToWin(9 - testTotalSticks);
            bool res = game.SetStick(next);

            Player temp = game.GetStartPlayer();
            Assert.AreEqual(temp.name, "Stina");

        }

        [TestMethod]
        public void TestSetCardsPerPlayer()
        {
            Game game = new Game();
            game.AddPlayer("Number1");
            game.AddPlayer("Number2");
            game.AddPlayer("Number3");

            game.SetCardsPerPlayer();
            var firstBetter = game.SetFirstBetter();
            game.Deal();

            int iCards = game.SetCardsPerPlayer();
            Assert.AreEqual(9, game.cardsPerPlayer);



        }

        [TestMethod]
        public void TestCardsNotTen()
        {
            Game game = new Game();
            game.AddPlayer("Number1");
            game.AddPlayer("Number2");
            game.AddPlayer("Number3");
            game.AddPlayer("Number4");
            game.AddPlayer("Number5");
            game.AddPlayer("Number6");

            game.SetCardsPerPlayer();
            var firstBetter = game.SetFirstBetter();
            game.Deal();

            Assert.AreNotEqual(10, game.cardsPerPlayer);
            Assert.IsTrue((game.cardsPerPlayer * game.players.Count) <= 52);

        }

    }
}
