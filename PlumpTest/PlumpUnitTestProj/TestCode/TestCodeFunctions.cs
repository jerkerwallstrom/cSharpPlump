using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWindowsApp.Source;

namespace PlumpUnitTestProj.TestCode
{
    public static class TestCodeFunctions
    {
        public static int incBet(Game game, int sticks, int testTotalSticks)
        {
            var next = game.selPlayer;
            if (next.IsVirtualPlayer())
            {
                testTotalSticks = testTotalSticks + next.stickToWin;
            }
            else
            {
                next.SetStickToWin(sticks);
                testTotalSticks = testTotalSticks + sticks;
            }
            game.SetStick(next);
            return testTotalSticks;
        }

        public static Player PlayNextCard(Game game)
        {
            var next = game.selPlayer;

            next.PlayCard();
            Card playedCard = next.selected;
            game.Play(next);

            return next;
        }

        public static Card GetBestCard(Card playedCard, Card cardToBeat)
        {
            if (cardToBeat==null)
            {
                return playedCard;
            }
            if (playedCard == null)
            {
                return cardToBeat;
            }
            if (cardToBeat.suit == playedCard.suit)
            {
                if (playedCard.rank > cardToBeat.rank)
                {
                    return playedCard;
                }
            }
            return cardToBeat;
        }
    }
}
