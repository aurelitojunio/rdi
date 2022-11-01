using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Application.Utils.Tests
{
    [TestClass()]
    public class TokenValidationTests
    {
        [TestMethod]
        public void ValidTokenAlgorith()
        {
            var input = TokenValidation.ShiftRight(new[] { 1, 2, 3 }, 2).ToArray();
            var result = new[] { 2, 3, 1 };
            Assert.IsTrue(input.SequenceEqual(result));
        }

        [TestMethod]
        public void InvalidTokenAlgorith()
        {
            var input = TokenValidation.ShiftRight(new[] { 1, 2, 3 }, 2).ToArray();
            var result = new[] { 3, 1, 2 };
            Assert.IsFalse(input.SequenceEqual(result));
        }

        //IsTokenCreationDateValid
        [TestMethod]
        public void ValidTokenCreationDate()
        {
            var dt = DateTime.Now.AddMinutes(-30);
            Assert.IsTrue(TokenValidation.IsTokenCreationDateValid(dt));
        }

        [TestMethod]
        public void InvalidTokenCreationDate()
        {
            var dt = DateTime.Now.AddMinutes(-31);
            Assert.IsFalse(TokenValidation.IsTokenCreationDateValid(dt));
        }
    }
}