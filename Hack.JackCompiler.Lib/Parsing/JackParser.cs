using System;
using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing
{
    public class JackParser
    {
        private readonly ParserFactory _parserFactory;

        public JackParser(ParserFactory parserFactory)
        {
            _parserFactory = parserFactory ?? throw new ArgumentNullException(nameof(parserFactory));
        }

        public IElement Parse(IEnumerable<IToken> tokens)
        {
            var classParser = _parserFactory.Create(ElementCategory.Class, tokens);
            var result = classParser.Parse();

            if (result.NextTokenIndex < tokens.Count())
            {
                throw new InvalidOperationException(
                    "Provided file contains invalid content - it should be just one class");
            }

            return result.Element;
        }
    }
}