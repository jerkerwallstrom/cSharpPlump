using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWindowsApp.Source
{
    public class Player
    {
        private bool virtualPlayer = false;
        public string name;
        public Card selected;

        public bool betRound { get; private set; } = false;
        public int points = 0;

        public List<Card> cards;
        public Card cardToBeat = null;

        private bool driver = false;
        private bool firstBetter = false;

        public int stickToWin { get; private set; }
        public int sticks { get; private set; }

        public void SetDriver(bool aValue)
        {
            driver = aValue;
            if (driver && virtualPlayer)
            {
                if (betRound)
                {
                    stickToWin = SetVirtualStickToWin();
                }
                else
                {
                    selected = SelectCard();
                }
            }
        }

        private int SetVirtualStickToWin()
        {
            int posSticks = 0;
            int lowSticks = 0;
            foreach (Card card in cards)
            {
                if ((int)card.rank > 10)
                {
                    posSticks++;
                }
                if ((int)card.rank > 7)
                {
                    lowSticks++;
                }
            }
            if ((posSticks < 1) && (lowSticks > 1))
            {
                posSticks++;
            }
            return posSticks;
        }

        public bool IsDriver()
        {
            return driver;
        }

        public void SetBetRound(bool value)
        {
            betRound = value;
        }

        public bool IsVirtualPlayer()
        {
            return virtualPlayer;
        }
        public Player(string aName, bool aVirtualPlayer)
        {
            virtualPlayer = aVirtualPlayer;
            name = aName;
            cards = new List<Card>();
        }

        public void DealAdd(Card aCard)
        {
            cards.Add(aCard);
        }

        public void ResetCards()
        {
            cards.Clear();
            selected = null;
            cardToBeat = null;
            stickToWin = 0;
            sticks = 0;
        }

        public IEnumerable<Card> GetCards()
        {
            return cards;
        }

        public Card PlayCard()
        {
            if (selected == null)
            {
                selected = SelectCard();
            }
            Card rtnCard = selected;
            cards.Remove(selected);
            return rtnCard;
        }

        private Card SelectCard()
        {
            return FindBestCard();
        }

        internal void SetBetAgain()
        {
            if (virtualPlayer)
            {
                if (stickToWin <= 0)
                {
                    stickToWin = 1;
                }
                else
                {
                    stickToWin = stickToWin - 1;
                }
                SetSelectedStick(null);
            }
            else
            {
                UpdateGUI(null);
            }
        }

        private bool ValidateCard(Card aCard)
        {
            bool res = true;
            if (cardToBeat != null)
            {
                if (cardToBeat.suit != aCard.suit)
                {
                    foreach (var card in cards)
                    {
                        if (card.suit == cardToBeat.suit)
                        {
                            res = false;
                            break;
                        }
                    }
                }

            }
            return res;
        }

        public bool SetSelected(Card aCard)
        {
            bool res = ValidateCard(aCard);
            selected = aCard;
            return res;
        }
        private Card FindBestCard()
        {
            List<Card> selCards = new List<Card>();

            foreach (Card card in cards)
            {
                if (IsBetter(card, cardToBeat))
                {
                    selCards.Add(card);
                }
            }
            if (selCards.Count() > 0)
            {
                Card highest = null;
                foreach (Card card in selCards)
                {
                    if ((highest == null) || (card.rank > highest.rank))
                    {
                        highest = card;
                    }
                }
                return highest;
            }
            else
            {
                if (cardToBeat == null)
                {
                    if (sticks < stickToWin)
                    {
                        return GetHighest();
                    }
                    else
                    {
                        return GetLowest();
                    }
                }
                else
                {
                    foreach (Card card in cards)
                    {
                        if (card.suit == cardToBeat.suit)
                        { 
                            selCards.Add(card);
                        }
                    }
                    if (selCards.Count > 0)
                    {
                        if (sticks<stickToWin)
                        {
                            return Lowest(selCards);
                        }
                        else 
                        {
                            return Highest(selCards);
                        }
                    }
                    else
                    {
                        if (sticks < stickToWin)
                        {
                            return Lowest(cards);
                        }
                        else
                        {
                            return Highest(cards);
                        }

                    }
                }
            }
        }

        private Card Highest(List<Card> selCards)
        {
            Card best = null;
            if (selCards.Count > 0)
            {
                best = selCards[0];
                foreach (Card card in selCards)
                {
                    if (card.rank > best.rank)
                    {
                        best = card;
                    }
                }
            }
            return best;
        }

        private Card Lowest(List<Card> selCards)
        {
            Card best = null;
            if (selCards.Count > 0)
            {
                best = selCards[0];
                foreach (Card card in selCards)
                {
                    if (card.rank < best.rank)
                    {
                        best = card;
                    }
                }
            }
            return best;
        }

        public void AddStick()
        {
            sticks++;
        }

        private Card GetLowest()
        {
            List<Card> selCards = new List<Card>();
            foreach (Card card in cards)
            {
                if (IsLower(card, cardToBeat))
                {
                    selCards.Add(card);
                }
            }
            if (selCards.Count() > 0)
            {
                Card lowest = null;
                foreach (Card card in selCards)
                {
                    if ((lowest == null) || (card.rank < lowest.rank))
                    {
                        lowest = card;
                    }
                }
                return lowest;
            }
            else
            {
                Card lowest = null;
                foreach (Card card in cards)
                {
                    if ((lowest == null) || (card.rank < lowest.rank))
                    {
                        lowest = card;
                    }
                }
                return lowest;
            }
        }
        private Card GetHighest()
        {
            List<Card> selCards = new List<Card>();
            foreach (Card card in cards)
            {
                if (IsHigher(card, cardToBeat))
                {
                    selCards.Add(card);
                }
            }
            if (selCards.Count() > 0)
            {
                Card highest = null;
                foreach (Card card in selCards)
                {
                    if ((highest == null) || (card.rank > highest.rank))
                    {
                        highest = card;
                    }
                }
                return highest;
            }
            else
            {
                Card highest = null;
                foreach (Card card in cards)
                {
                    if ((highest == null) || (card.rank > highest.rank))
                    {
                        highest = card;
                    }
                }
                return highest;
            }
        }

        public void SortMyCards()
        {
            List<Card> tmpCards = new List<Card>();
            foreach (CardSuits suit in Enum.GetValues(typeof(CardSuits)))
            {
                List<Card> suitCards = new List<Card>();
                foreach (Card card in cards)
                {
                    if (card.suit == suit)
                    {
                        suitCards.Add(card);
                    }
                }
                SortOnRank(ref suitCards);
                foreach (var card in suitCards)
                {
                    tmpCards.Add(card);
                }
            }

            cards.Clear();
            //cards = tmpCards;
            foreach (var card in tmpCards)
            {
                cards.Add(card);
            }
            UpdateGUI(null);
        }

        internal void Remove()
        {
            OnPlayerRemove(null);
        }

        public event EventHandler PlayerRemove;

        protected virtual void OnPlayerRemove(EventArgs e)
        {
            EventHandler handler = PlayerRemove;
            handler?.Invoke(this, e);
        }

        internal void SetAsFirstBetter(bool value)
        {
            firstBetter = value;
        }

        internal bool IsFirstBetter()
        {
            return firstBetter;
        }

        private void SortOnRank(ref List<Card> suitCards)
        {
            for (int i = 0; i < (suitCards.Count() - 1); i++)
            {
                //int start = i;
                int start = 0;
                if (suitCards[start].rank > suitCards[start + 1].rank)
                {
                    Card tmp = suitCards[start];
                    suitCards[start] = suitCards[start + 1];
                    suitCards[start + 1] = tmp;
                }
                for (int j = 1; j < (suitCards.Count() - 1); j++)
                {
                    if (suitCards[j].rank > suitCards[j + 1].rank)
                    {
                        Card tmp = suitCards[j];
                        suitCards[j] = suitCards[j + 1];
                        suitCards[j + 1] = tmp;
                    }
                }
            }
        }

        internal void SetPoint()
        {
            if (stickToWin == sticks)
            {
                int tmpPoints = (stickToWin > 0) ? stickToWin * 10 : 5;
                AddPoints(tmpPoints);
            }

        }

        public void SetStickToWin(int bet)
        {
            stickToWin = bet;
        }

        private bool IsLower(Card card, Card cardToBeat)
        {
            if ((cardToBeat != null) && (card.suit == cardToBeat.suit))
            {
                return card.rank < cardToBeat.rank;
            }
            return false;
        }

        private bool IsHigher(Card card, Card cardToBeat)
        {
            if ((cardToBeat != null) && (card.suit == cardToBeat.suit))
            {
                return card.rank > cardToBeat.rank;
            }
            return false;
        }

        private bool IsBetter(Card card, Card cardToBeat)
        {
            if ((cardToBeat != null) && (card.suit == cardToBeat.suit))
            {
                if (stickToWin > sticks)
                {
                    return card.rank > cardToBeat.rank;
                }
                else
                {
                    return card.rank < cardToBeat.rank;
                }
            }
            return false;
        }

        public int AddPoints(int aPoints)
        {
            points = points + aPoints;
            return points;
        }

        public void UpdateGUI(EventArgs e)
        {
            OnPlayerUpdateGUI(e);
        }

        public event EventHandler PlayerUpdateGUI;

        protected virtual void OnPlayerUpdateGUI(EventArgs e)
        {
            EventHandler handler = PlayerUpdateGUI;
            handler?.Invoke(this, e);
        }

        public void SetSelectedStick(EventArgs e)
        {
            OnPlayerSetStick(e);
        }
        public event EventHandler PlayerSetStick;

        protected virtual void OnPlayerSetStick(EventArgs e)
        {
            EventHandler handler = PlayerSetStick;
            handler?.Invoke(this, e);
        }

        //PlayerPlayCard
        public void PlaySelectedCard(EventArgs e)
        {
            OnPlayerPlayCard(e);
        }

        public event EventHandler PlayerPlayCard;

        protected virtual void OnPlayerPlayCard(EventArgs e)
        {
            EventHandler handler = PlayerPlayCard;
            handler?.Invoke(this, e);
        }
    }
}
