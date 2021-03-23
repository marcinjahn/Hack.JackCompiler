using System;
using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Parsing.Expressions.Terms;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions
{
    public static class ExpressionUtilities
    {
        public static bool IsValid(IToken token)
        {
            return TermParser.IsValid(token);
        }

        public static TermType GetTermType(IEnumerable<IToken> tokens)
        {
            if (tokens == null) throw new ArgumentNullException(nameof(tokens));
            if (tokens.Count() < 2)
                throw new ArgumentException("At least two tokens need to be supplied in the collection",
                    nameof(tokens));

            var token1 = tokens.ElementAt(0);
            var token2 = tokens.ElementAt(1);

            switch (token1.TokenType)
            {
                case TokenType.IntegerConst:
                    return TermType.IntegerConstant;
                case TokenType.StringConst:
                    return TermType.StringConstant;
                default:
                {
                    if (KeywordConstantTermParser.IsValid(token1)) return TermType.KeywordConstant;
                    else switch (token1.TokenType)
                    {
                        case TokenType.Identifier when token2.Value != Symbols.OpeningSquareBracket:
                            return TermType.VarName;
                        case TokenType.Identifier when token2.TokenType == TokenType.Symbol && token2.Value == Symbols.OpeningSquareBracket:
                            return TermType.ArrayAccess;
                        case TokenType.Identifier when token2.TokenType == TokenType.Symbol && token2.Value == Symbols.OpeningBrace:
                            return TermType.SubroutineCall;
                        case TokenType.Symbol when token1.Value == Symbols.OpeningBrace:
                            return TermType.ExpressionInBrackets;
                        default:
                        {
                            if (UnaryOperatorTermParser.IsValid(token1)) return TermType.UnaryOperatorAndTerm;
                            else throw new InvalidOperationException("Provided tokens are not a valid term"); // TODO: Custom exception?
                        }
                    }
                }
            }
        }
    }
}