using System.Collections.Generic;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class SubroutineCallTermParser : ParserBase
    {
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;
        
        public SubroutineCallTermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ParseResult Parse()
        {
            var element = ParseElement(ElementCategory.SubroutineCall);
            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}