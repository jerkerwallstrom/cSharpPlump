using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsApp.Source
{
    public enum GamePhase { startGame, downCount, OneCard, upCount };
    public class Game
    {
        public List<Player> players;
        public CardDeck cardDeck;
        public int maxCards { get; private set; } = 10;
        public int minCards { get; private set; } = 1;

        public GamePhase gamePhase = GamePhase.startGame;
        public int cardsPerPlayer { get; private set; } = 10;

        public Player selPlayer = null;
        public Card cardToBeat = null;

        public Player winnerRound { get; private set; } = null;
        public string szError { get; private set; }

        const int MaxNumberOfPlayers = 10;

        private List<Player> round = null;

        public Game()
        {
            players = new List<Player>();
            cardDeck = new CardDeck();
        }

        public int SetCardsPerPlayer()
        {
            switch (gamePhase)
            {
                case GamePhase.startGame:
                    cardsPerPlayer = CheckNumberOfCards();
                    gamePhase = GamePhase.downCount;
                    break;
                case GamePhase.downCount:
                    cardsPerPlayer = cardsPerPlayer - 1;

                    if (cardsPerPlayer > CheckNumberOfCards())
                    {
                        cardsPerPlayer = CheckNumberOfCards();
                    }
                    if (cardsPerPlayer <= 1)
                    {
                        gamePhase = GamePhase.OneCard;
                    }
                    break;
                case GamePhase.OneCard:
                    cardsPerPlayer = cardsPerPlayer + 1;
                    gamePhase = GamePhase.upCount;
                    break;
                case GamePhase.upCount:
                    cardsPerPlayer = cardsPerPlayer + 1;
                    //if (cardsPerPlayer > CheckNumberOfCards())
                    //{
                    //    //gamePhase.
                    //}
                    break;
            }
            return cardsPerPlayer;
        }

        private Player AddPlayer(string name, bool avirtual)
        {
            if (players.Count >= MaxNumberOfPlayers)
            {
                szError = "Can't add more players, already " +
                              players.Count().ToString() + " in the game";
                return null;
            }
            if (!NameUnique(name))
            {
                szError = "Player with name: " + name + " already exist";
                return null;
            }
            szError = "";
            Player aPlayer = new Player(name, avirtual);
            players.Add(aPlayer);
            return aPlayer;

        }

        private bool NameUnique(string name)
        {
            foreach (var player in players)
            {
                if (player.name.ToLower().Equals(name.ToLower()))
                {
                    return false;
                }
            }
            return true;
        }

        public Player AddPlayer(string name)
        {
            return AddPlayer(name, false);
        }
        public Player AddVirtualPlayer(string name)
        {
            return AddPlayer(name, true);
        }

        public void Deal()
        {
            foreach (Player player in players)
            {
                player.ResetCards();
                player.SetBetRound(true);
            }

            cardDeck.Shuffle();
            for (int i = 0; i < cardsPerPlayer; i++)
            {
                foreach (Player player in players)
                {
                    Card card = cardDeck.GetCard();
                    player.DealAdd(card);
                }
            }
            foreach (var player in players)
            {
                if (player.IsFirstBetter())
                {
                    StartBetRound(player);
                    break;
                }
            }
        }

        public void c_RemovePlayer(object sender, EventArgs e)
        {
            Player toRemove = sender as Player;
            RemovePlayer(toRemove);
        }
        private void RemovePlayer(Player toRemove)
        {

            if (round != null)
            {
                foreach (var player in round)
                {
                    if (player.name.Equals(toRemove.name))
                    {
                        round.Remove(player);
                        break;
                    }
                }
            }

            if (players != null)
            {
                foreach (var player in players)
                {
                    if (player.name.Equals(toRemove.name))
                    {
                        if (player.IsDriver())
                        {
                            SetNextPlayer();
                        }
                        players.Remove(player);
                        break;
                    }
                }
            }
        }

        public Player GetWinner()
        {
            Player winner = null;
            if (players.Count > 0)
            {
                int maxPoints = 0;
                foreach (var player in players)
                {
                    if (player.points > maxPoints)
                    {
                        winner = player;
                        maxPoints = player.points;
                    }
                }
            }
            return winner;
        }

        public bool IsDealOver()
        {
            bool bZero = true;
            foreach (Player player in players)
            {
                if (player.cards.Count() > 0)
                {
                    bZero = false;
                }
            }
            return bZero;
        }

        public bool SetStick(Player player)
        {
            //Return true if each player have set a vild bet!
            if (round.Count() == players.Count - 1)
            {
                int betCnt = 0;
                foreach (var tmpP in round)
                {
                    betCnt = betCnt + tmpP.stickToWin;
                }
                if ((player.stickToWin + betCnt) == cardsPerPlayer)
                {
                    player.SetBetAgain();
                    return false;
                }
            }
            if (players.Exists(x => x.name == player.name))
            {
                round.Add(player);
            }
            if (round.Count() == players.Count)
            {
                return true;
            }
            else
            {
                SetNextPlayer();
                return false;
            }
        }

        internal string GetCardToBeatInfo()
        {
            return (cardToBeat != null) ? cardToBeat.ToString() : "";
        }

        public Player GetStartPlayer()
        {
            int maxStick = -1;
            Player start = null;

            int n = 0;
            foreach (Player player in players)
            {
                if (player.IsFirstBetter())
                {
                    start = player;
                    maxStick = player.stickToWin;
                    break;
                }
                n++;
            }
            for (int i = 0; i < players.Count(); i++)
            {
                Player player = players[n];
                player.SetBetRound(false);
                if (player.stickToWin > maxStick)
                {
                    start = player;
                    maxStick = player.stickToWin;
                }
                n++;
                if (n >= players.Count)
                {
                    n = 0;
                }
            }
            //foreach (Player player in players)
            //{
            //    player.SetBetRound(false);
            //    if (player.stickToWin > maxStick)
            //    {
            //        start = player;
            //        maxStick = player.stickToWin;
            //    }
            //}
            return start;
        }

        private void StartBetRound(Player aSelPlayer)
        {
            if (selPlayer != null)
            {
                selPlayer.SetDriver(false);
                selPlayer.UpdateGUI(null);
            }
            selPlayer = aSelPlayer;
            if (selPlayer != null)
            {
                selPlayer.cardToBeat = null;
                selPlayer.SetDriver(true);
                selPlayer.UpdateGUI(null);
            }
            if ((round != null) && (round.Count() > 0))
            {
                round.Clear();
            }
            if (round == null)
            {
                round = new List<Player>();
            }
        }

        internal bool IsGameOver()
        {
            if (gamePhase == GamePhase.upCount)
            {
                if (cardsPerPlayer >= CheckNumberOfCards())
                {
                    gamePhase = GamePhase.startGame;
                    return true;
                }
            }
            return false;
            //return (cardsPerPlayer < minCards);
        }

        internal void PrepareFornewGame()
        {
            cardsPerPlayer = maxCards;
        }

        internal void SetPoints()
        {
            foreach (Player player in players)
            {
                player.SetPoint();
            }
        }

        public void StartRound(Player aSelPlayer)
        {
            cardToBeat = null;
            if (selPlayer != null)
            {
                selPlayer.SetDriver(false);
                selPlayer.UpdateGUI(null);
            }
            selPlayer = aSelPlayer;
            if (selPlayer != null)
            {
                selPlayer.cardToBeat = null;
                selPlayer.SetDriver(true);
                selPlayer.UpdateGUI(null);
            }
            if ((round != null) && (round.Count() > 0))
            {
                round.Clear();
            }
            if (round == null)
            {
                round = new List<Player>();
            }
        }

        private int CheckNumberOfCards()
        {
            int tmpMaxCards = maxCards;
            if ((tmpMaxCards * players.Count) > 52)
            {
                tmpMaxCards = 52 / players.Count;
            }
            return tmpMaxCards;
        }

        public Player SetFirstBetter()
        {
            Player firstBetter = null;
            bool bSet = false;
            for (int i = 0; i < players.Count(); i++)
            {
                Player player = players[i];
                if (player.IsFirstBetter())
                {
                    player.SetAsFirstBetter(false);
                    //Set next to first better
                    int iNext = i + 1;
                    if (iNext >= players.Count)
                    {
                        iNext = 0;
                    }
                    players[iNext].SetAsFirstBetter(true);
                    firstBetter = players[iNext];
                    bSet = true;
                    break;
                }
            }
            if (!bSet)
            {
                players[0].SetAsFirstBetter(true);
                firstBetter = players[0];
            }
            return firstBetter;
        }

        internal void UpdateUI()
        {
            foreach (var player in players)
            {
                player.UpdateGUI(null);
            }
        }

        internal void AutomaticSetStick()
        {
            if (selPlayer != null)
            {
                if (selPlayer.IsDriver() && selPlayer.IsVirtualPlayer())
                {
                    selPlayer.SetSelectedStick(null);
                }
            }
        }

        internal void AutomaticPlay()
        {
            if (selPlayer != null)
            {
                if (selPlayer.IsDriver() && selPlayer.IsVirtualPlayer())
                {
                    selPlayer.PlaySelectedCard(null);
                }
            }
        }

        public Player Play(Player aPlayer)
        {
            if (players.Exists(x => x.name == aPlayer.name))
            {
                round.Add(aPlayer);
            }
            if (round.Count == players.Count)
            {
                winnerRound = GetWinnerOfRound(round);
                return winnerRound;
            }
            else
            {
                if (cardToBeat == null)
                {
                    cardToBeat = aPlayer.selected;
                }
                else
                {
                    cardToBeat = SetCardToBeat(round, cardToBeat);
                }
                SetNextPlayer();
                return null;
            }
        }

        private Player GetWinnerOfRound(List<Player> round)
        {
            Player winner = null;
            Card cardToBeat = null;
            foreach (Player player in round)
            {
                if (cardToBeat == null)
                {
                    cardToBeat = player.selected;
                    winner = player;
                }
                else
                {
                    if (CheckIfCardBetter(player.selected, cardToBeat))
                    {
                        cardToBeat = player.selected;
                        winner = player;
                    }
                }
            }
            return winner;
        }

        private Card SetCardToBeat(List<Player> round, Card cardToBeat)
        {
            Card newCardToBeat = cardToBeat;
            Player bestSoFar;
            foreach (Player player in round)
            {
                if (newCardToBeat == null)
                {
                    newCardToBeat = player.selected;
                    bestSoFar = player;
                }
                else
                {
                    if (CheckIfCardBetter(player.selected, newCardToBeat))
                    {
                        newCardToBeat = player.selected;
                        bestSoFar = player;
                    }
                }
            }
            return newCardToBeat;
        }

        private bool CheckIfCardBetter(Card selected, Card cardToBeat)
        {
            bool result = false;
            if (selected.suit == cardToBeat.suit)
            {
                result = selected.rank > cardToBeat.rank;
            }
            return result;
        }

        private void SetNextPlayer()
        {
            if (selPlayer == null)
            {
                selPlayer = players[0];
                selPlayer.cardToBeat = cardToBeat;
                selPlayer.SetDriver(true);
            }
            else
            {
                selPlayer.SetDriver(false);
                selPlayer.UpdateGUI(null);
                int i = players.IndexOf(selPlayer);
                i++;
                if (i >= players.Count())
                {
                    i = 0;
                }
                selPlayer = players[i];
                selPlayer.cardToBeat = cardToBeat;
                selPlayer.SetDriver(true);
            }
            selPlayer.UpdateGUI(null);
        }

    }
}
