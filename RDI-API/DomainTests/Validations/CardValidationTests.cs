using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Validations.Tests
{
    [TestClass()]
    public class CardValidationTests
    {
        [TestMethod()]
        public void ValidCardNumber()
        {
            long cardNo = 1298123412341234;
            Assert.IsTrue(CardValidation.CardNumberValidation.IsCardNumberValid(cardNo));
        }

        [TestMethod()]
        public void InvalidCardNumber()
        {
            long cardNo = 1234123412341234;
            Assert.IsFalse(CardValidation.CardNumberValidation.IsCardNumberValid(cardNo));
        }
        [TestMethod()]
        public void ValidCVV()
        {
            int cvv = 1;
            Assert.IsTrue(CardValidation.CardCvvValidation.IsCardCvvValid(cvv));
        }

        [TestMethod()]
        public void InvalidCVV()
        {
            int cvv = 123456;
            Assert.IsFalse(CardValidation.CardCvvValidation.IsCardCvvValid(cvv));
        }
    }
}