namespace DeckTest
{
    using System;
    using NUnit.Framework;
    using Santase.Logic.Cards;
    [TestFixture]
    public class DeckTest
    {
        [TestCase(1,23)]
        [TestCase(5,19)]
        [TestCase(24,0)]
        public void GetNext_ShouldBeIncreaseDeckCount(int getCardNum, int result)
        {
            IDeck testDeck = new Deck();

            for (int i = 0; i < getCardNum; i++)
            {
                testDeck.GetNextCard();
            }

            Assert.AreEqual(testDeck.CardsLeft, result);
        }
    }
}
