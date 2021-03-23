using System;
using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Class
{
    public class VariableDeclarationAdditionalParser : ParserBase
    {
        public VariableDeclarationAdditionalParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.ClassVariableDeclaration;

        public override ParseResult Parse()
        {
            var element = new VariableDeclarationAdditionalElement();
            element
                .Add(ParseSymbol(Symbols.Comma))
                .Add(ParseIdentifier()); //varName
            
            return new ParseResult(ConsumedTokensCount, element);
        }

        public static bool IsValid(IToken token)
        {
            if (token == null) throw new ArgumentNullException(nameof(token));
            return token.TokenType == TokenType.Symbol && token.Value == Symbols.Comma;
        }
    }
}