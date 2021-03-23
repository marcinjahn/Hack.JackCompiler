using System;
using Hack.JackCompiler.Lib.Parsing;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib
{
    public class JackCompiler
    {
        private readonly JackTokenizer _tokenizer;
        private readonly JackParser _parser;

        public JackCompiler(JackTokenizer tokenizer, JackParser parser)
        {
            _tokenizer = tokenizer ?? throw new ArgumentNullException(nameof(tokenizer));
            _parser = parser ?? throw new ArgumentNullException(nameof(parser));
        }

        public void Compile(string jackClass)
        {
            var tokens = _tokenizer.Tokenize(jackClass);
            var parsedTree = _parser.Parse(tokens);
        }
    }
}