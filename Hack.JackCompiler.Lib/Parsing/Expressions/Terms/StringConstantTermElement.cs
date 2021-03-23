using Hack.JackCompiler.Lib.Parsing.Terminal;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class StringConstantTermElement : TerminalElement
    {
        public StringConstantTermElement(string value) : base(value)
        {
        }
    }
}