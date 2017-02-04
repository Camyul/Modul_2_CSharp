namespace TDD_Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Poker;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using Moq;
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

        [TestMethod]
        public void IsValidHand_ShouldBeTrueIfAllCardsIsDifferent()
        {
            //Arange
            IHand hand = new Hand(new List<ICard> {
                new Card(CardFace.Four, CardSuit.Diamonds ),
                new Card(CardFace.Four, CardSuit.Clubs ),
                new Card(CardFace.Four, CardSuit.Hearts ),
                new Card(CardFace.Four, CardSuit.Spades ),
                new Card(CardFace.Five, CardSuit.Diamonds )
            });
            IPokerHandsChecker check = new PokerHandsChecker();

            //Act & Assert
            Assert.AreEqual(true,  check.IsValidHand(hand));
        }

        [TestMethod]
        public void IsValidHand_ShouldBeTrueIfCountOfCardsIsFive()
        {
            //Arange
            int countOfCargs = 5;
            IHand hand = new Hand(new List<ICard> {
                new Card(CardFace.Four, CardSuit.Diamonds ),
                new Card(CardFace.Four, CardSuit.Clubs ),
                new Card(CardFace.Four, CardSuit.Hearts ),
                new Card(CardFace.Four, CardSuit.Spades ),
                new Card(CardFace.Five, CardSuit.Diamonds )
            });

            //Act & Assert
            Assert.AreEqual(countOfCargs, hand.Cards.Count);
        }
    }
}
