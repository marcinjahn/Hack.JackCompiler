namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public interface IMatcher
    {
        MatchResult TryMatch(string input);
    }
}