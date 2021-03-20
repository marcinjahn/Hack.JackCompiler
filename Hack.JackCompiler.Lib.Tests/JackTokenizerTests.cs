using System.Linq;
using Hack.JackCompiler.Lib.Tokenization;
using Hack.JackCompiler.Lib.Tokenization.Matchers;
using NUnit.Framework;

namespace Hack.JackCompiler.Lib.Tests
{
    public class JackTokenizerTests
    {
        [Test]
        public void Tokenize_ValidJackCodeIsProvided_ValidOutputIsProduced()
        {
            const string jackCode = @"
                /** Represents a point object */
                class Point {
                    field int x, y;
                    static int pointCount;
                    
                    /* Constructs a new point */
                    constructor Point new(int ax, int ay) {
                        let x = ax;
                        let y = ay;
                        let pointCount = pointCount + 1;
                        return this;
                    }
                    
                    // More point methods
                }";

            var tokenizer = GetNewSut();

            var result = tokenizer.Tokenize(jackCode);

            Assert.AreEqual("class", result.ElementAt(0).Value);
            Assert.AreEqual("Point", result.ElementAt(1).Value);
            Assert.AreEqual("{", result.ElementAt(2).Value);
            Assert.AreEqual("field", result.ElementAt(3).Value);
            Assert.AreEqual("int", result.ElementAt(4).Value);
            Assert.AreEqual("x", result.ElementAt(5).Value);
            Assert.AreEqual(",", result.ElementAt(6).Value);
            Assert.AreEqual("y", result.ElementAt(7).Value);
            Assert.AreEqual(";", result.ElementAt(8).Value);
            Assert.AreEqual("static", result.ElementAt(9).Value);
            Assert.AreEqual("int", result.ElementAt(10).Value);
            Assert.AreEqual("pointCount", result.ElementAt(11).Value);
            Assert.AreEqual(";", result.ElementAt(12).Value);
            Assert.AreEqual("constructor", result.ElementAt(13).Value);
            Assert.AreEqual("Point", result.ElementAt(14).Value);
            Assert.AreEqual("new", result.ElementAt(15).Value);
            Assert.AreEqual("(", result.ElementAt(16).Value);
            Assert.AreEqual("int", result.ElementAt(17).Value);
            Assert.AreEqual("ax", result.ElementAt(18).Value);
            Assert.AreEqual(",", result.ElementAt(19).Value);
            Assert.AreEqual("int", result.ElementAt(20).Value);
            Assert.AreEqual("ay", result.ElementAt(21).Value);
            Assert.AreEqual(")", result.ElementAt(22).Value);
            Assert.AreEqual("{", result.ElementAt(23).Value);
            Assert.AreEqual("let", result.ElementAt(24).Value);
            Assert.AreEqual("x", result.ElementAt(25).Value);
            Assert.AreEqual("=", result.ElementAt(26).Value);
            Assert.AreEqual("ax", result.ElementAt(27).Value);
            Assert.AreEqual(";", result.ElementAt(28).Value);
            Assert.AreEqual("let", result.ElementAt(29).Value);
            Assert.AreEqual("y", result.ElementAt(30).Value);
            Assert.AreEqual("=", result.ElementAt(31).Value);
            Assert.AreEqual("ay", result.ElementAt(32).Value);
            Assert.AreEqual(";", result.ElementAt(33).Value);
            Assert.AreEqual("let", result.ElementAt(34).Value);
            Assert.AreEqual("pointCount", result.ElementAt(35).Value);
            Assert.AreEqual("=", result.ElementAt(36).Value);
            Assert.AreEqual("pointCount", result.ElementAt(37).Value);
            Assert.AreEqual("+", result.ElementAt(38).Value);
            Assert.AreEqual("1", result.ElementAt(39).Value);
            Assert.AreEqual(";", result.ElementAt(40).Value);
            Assert.AreEqual("return", result.ElementAt(41).Value);
            Assert.AreEqual("this", result.ElementAt(42).Value);
            Assert.AreEqual(";", result.ElementAt(43).Value);
            Assert.AreEqual("}", result.ElementAt(44).Value);
            Assert.AreEqual("}", result.ElementAt(45).Value);
            
            Assert.AreEqual(46, result.Count);
        }

        private static JackTokenizer GetNewSut()
        {
            return new JackTokenizer(
                new IMatcher[]
                {
                    new CodeDocumentationMatcher(),
                    new IdentifierMatcher(),
                    new IntegerConstantMatcher(),
                    new KeywordMatcher(),
                    new MultilineCommentMatcher(),
                    new SingleLineCommentMatcher(),
                    new StringConstantMatcher(),
                    new SymbolMatcher(),
                    new WhitespaceMatcher()
                });
        }
    }
}