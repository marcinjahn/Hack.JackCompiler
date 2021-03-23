using System.Collections.Generic;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class VarNameTermParser : ParserBase
    {
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;
        
        public VarNameTermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ParseResult Parse()
        {
            var element = ParseIdentifier();
            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}