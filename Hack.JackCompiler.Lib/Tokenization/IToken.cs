using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization
{
    public interface IToken
    {
        string Value { get; init; }
        TokenType TokenType { get; init; }
    }
}