namespace TDD_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void CardToString_ShouldBeCardFaceAndCardSuitToString()
        {
            ICard testCard = new Card(CardFace.Four, CardSuit.Diamonds);

            string result = testCard.ToString();

            Assert.AreEqual((CardFace.Four.ToString() + CardSuit.Diamonds.ToString()), result);
        }

        [TestMethod]
        public void HandToStrind_ShouldBeCardsInHandToString()
        {
            IHand hand = new Hand ( new List<ICard> {
                new Card(CardFace.Four, CardSuit.Diamonds ),
                new Card(CardFace.Four, CardSuit.Clubs ),
                new Card(CardFace.Four, CardSuit.Hearts ),
                new Card(CardFace.Four, CardSuit.Spades ),
                new Card(CardFace.Four, CardSuit.Diamonds )
            } );

            string handToStr = String.Join("\n", hand);

            Assert.AreEqual(hand.ToString(), handToStr);
        } 
    }
}
