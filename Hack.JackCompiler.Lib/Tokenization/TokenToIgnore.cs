using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization
{
    public class TokenToIgnore : IToken
    {
        public TokenToIgnore(string value, TokenType tokenType)
        {
            Value = value;
            TokenType = tokenType;
        }

        public string Value { get; init; }
        public TokenType TokenType { get; init; }
    }
}