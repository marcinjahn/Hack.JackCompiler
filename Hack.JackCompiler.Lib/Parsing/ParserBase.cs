using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Parsing.Terminal;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing
{
    public interface IParser
    {
        ElementCategory SupportedElementCategory { get; }
        ParseResult Parse();
    }

    public abstract class ParserBase : IParser
    {
        protected readonly ParserFactory ParserFactory;
        
        protected IEnumerable<IToken> Tokens { get; set; }
        protected int ConsumedTokensCount { get; set; }

        protected ParserBase(IEnumerable<IToken> tokens, ParserFactory parserFactory)
        {
            Tokens = tokens ?? throw new ArgumentNullException(nameof(tokens));
            ParserFactory = parserFactory ?? throw new ArgumentNullException(nameof(parserFactory));
        }

        public abstract ElementCategory SupportedElementCategory { get; }
        
        public abstract ParseResult Parse();

        protected IEnumerable<IElement> ParseZeroOrMore(Predicate<IToken> predicate, ElementCategory elementCategory)
        {
            var statements = new List<IElement>();
            while (predicate(Tokens.FirstOrDefault()))
            {
                var parser = ParserFactory.Create(elementCategory, Tokens);
                var parseResult = parser.Parse();
                statements.Add(parseResult.Element);
                Tokens = Tokens.Skip(parseResult.NextTokenIndex);
                ConsumedTokensCount += parseResult.NextTokenIndex;
            }

            return statements;
        }
        
        protected IEnumerable<IElement> ParseZeroOrMore(IEnumerable<Tuple<Predicate<IToken>, ElementCategory>> possibilities)
        {
            var statements = new List<IElement>();
            var parsedAll = false;

            while (!parsedAll)
            {
                parsedAll = true;
                foreach (var possibility in possibilities)
                {
                    if (!possibility.Item1(Tokens.FirstOrDefault())) continue;
                    
                    var parser = ParserFactory.Create(possibility.Item2, Tokens);
                    var parseResult = parser.Parse();
                    statements.Add(parseResult.Element);
                    Tokens = Tokens.Skip(parseResult.NextTokenIndex);
                    ConsumedTokensCount += parseResult.NextTokenIndex;
                    parsedAll = false;
                    break;
                }
            }

            return statements;
        }

        protected IElement ParseOptional(
            Predicate<IToken> predicate, 
            ElementCategory elementCategory, 
            IElement elementToReturnIfPredicateNotSatisfied = null)
        {
            if (!predicate(Tokens.FirstOrDefault()))
            {
                return elementToReturnIfPredicateNotSatisfied ?? new VoidElement();
            }
            
            var parser = ParserFactory.Create(elementCategory, Tokens);
            var parseResult = parser.Parse();
                
            Tokens = Tokens.Skip(parseResult.NextTokenIndex);
            ConsumedTokensCount += parseResult.NextTokenIndex;

            return parseResult.Element;
        }

        protected IElement ParseElement(ElementCategory elementCategory)
        {
            var parser = ParserFactory.Create(elementCategory, Tokens);
            var result = parser.Parse();
            
            Tokens = Tokens.Skip(result.NextTokenIndex);
            ConsumedTokensCount += result.NextTokenIndex;
            
            return result.Element;
        }

        protected IElement ParseKeyword(params string[] expectedKeyword)
        {
            var token = Tokens.FirstOrDefault();
            if (token?.TokenType != TokenType.Keyword || !expectedKeyword.Contains(token.Value))
            {
                // TODO: Use custom exception type
                throw new InvalidOperationException("Provided token is not a keyword");
            }

            Tokens = Tokens.Skip(1);
            ConsumedTokensCount++;

            return new KeywordElement(token.Value);
        }
        
        protected IElement ParseIdentifier()
        {
            var token = Tokens.FirstOrDefault();
            if (token?.TokenType != TokenType.Identifier)
            {
                // TODO: Use custom exception type
                throw new InvalidOperationException("Provided token is not an identifier");
            }
            
            Tokens = Tokens.Skip(1);
            ConsumedTokensCount++;

            return new IdentifierElement(token.Value);
        }

        protected IElement ParseSymbol(params string[] expectedSymbols)
        {
            var token = Tokens.FirstOrDefault();
            if (token?.TokenType != TokenType.Symbol || !expectedSymbols.Contains(token.Value))
            {
                // TODO: Use custom exception type
                throw new InvalidOperationException("Provided token is not an expected symbol");
            }

            Tokens = Tokens.Skip(1);
            ConsumedTokensCount++;

            return new SymbolElement(token.Value);
        }
    }
}