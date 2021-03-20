using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;
using Hack.JackCompiler.Lib.Tokenization.Matchers;
using NUnit.Framework;

namespace Hack.JackCompiler.Lib.Tests
{
    public class KeywordMatcherTests
    {
        [TestCase("class MyClass", "class", 6)]
        [TestCase("function MyFunction", "function", 9)]
        [TestCase("do MyFunction()", "do", 3)]
        [TestCase("let variable = 4", "let", 4)]
        public void TryMatch_MatchingInputsAreGiven_ResultPropertiesAreValid(string input, string expectedTokenValue, int expectedNextIndex)
        {
            var matcher = new KeywordMatcher();
            var result = matcher.TryMatch(input);
            
            Assert.True(result.IsMatching);
            Assert.AreEqual(TokenType.Keyword, result.Token.TokenType);
            Assert.AreEqual(expectedTokenValue, result.Token.Value);
            Assert.AreEqual(expectedNextIndex, result.NextIndex);
        }
        
        [TestCase(" class MyClass")]
        [TestCase(" function MyFunction")]
        [TestCase(" do MyFunction()")]
        [TestCase(" let variable = 4")]
        [TestCase("whatever")]
        public void TryMatch_NonMatchingInputsAreGiven_ResultIsNonMatching(string input)
        {
            var matcher = new KeywordMatcher();
            var result = matcher.TryMatch(input);
            
            Assert.False(result.IsMatching);
        }
    }
}