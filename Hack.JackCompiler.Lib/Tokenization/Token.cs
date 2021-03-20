using System;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization
{
    public class Token : IToken
    {
        public string Value { get; init; }
        public TokenType TokenType { get; init; }

        public Token(string value, TokenType tokenType)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
            TokenType = tokenType;
        }
    }
}