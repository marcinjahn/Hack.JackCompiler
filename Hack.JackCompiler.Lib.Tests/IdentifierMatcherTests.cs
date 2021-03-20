using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;
using Hack.JackCompiler.Lib.Tokenization.Matchers;
using NUnit.Framework;

namespace Hack.JackCompiler.Lib.Tests
{
    [TestFixture]
    public class IdentifierMatcherTests
    {
        [TestCase("myVar", "myVar", 5)]
        [TestCase("myVar = 4", "myVar", 5)]
        [TestCase("_myVar", "_myVar", 6)]
        [TestCase("abc345def", "abc345def", 9)]
        public void TryMatch_ValidIdentifiersAreGiven_ResultHasValidProperties(string input, string expectedTokenValue, int expectedNextIndex)
        {
            var matcher = new IdentifierMatcher();

            var result = matcher.TryMatch(input);
            
            Assert.True(result.IsMatching);
            Assert.AreEqual(expectedTokenValue, result.Token.Value);
            Assert.AreEqual(TokenType.Identifier, result.Token.TokenType);
            Assert.AreEqual(expectedNextIndex, result.NextIndex);
        }
        
        [TestCase("1myVar")]
        [TestCase(" myVar")]
        [TestCase(" ")]
        [TestCase("*")]
        public void TryMatch_InvalidIdentifiersAreGiven_ResultIsNonmatching(string input)
        {
            var matcher = new IdentifierMatcher();

            var result = matcher.TryMatch(input);
            
            Assert.False(result.IsMatching);
        }
    }
}