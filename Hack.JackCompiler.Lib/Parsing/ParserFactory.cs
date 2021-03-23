using System;
using System.Collections.Generic;
using Hack.JackCompiler.Lib.Parsing.Class;
using Hack.JackCompiler.Lib.Parsing.Expressions;
using Hack.JackCompiler.Lib.Parsing.Expressions.Terms;
using Hack.JackCompiler.Lib.Parsing.Statements;
using Hack.JackCompiler.Lib.Parsing.Subroutine;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing
{
    public class ParserFactory
    {
        public IParser Create(ElementCategory elementType, IEnumerable<IToken> tokens)
        {
            return elementType switch
            {
                ElementCategory.Class => new ClassParser(tokens, this),
                ElementCategory.ClassVariableDeclaration => new ClassVariableDeclarationParser(tokens, this),
                ElementCategory.AdditionalVariable => new ClassVariableDeclarationParser(tokens, this),
                ElementCategory.ClassSubroutineDeclaration => new ClassSubroutineDeclarationParser(tokens, this),
                ElementCategory.Type => new TypeParser(tokens, this),
                ElementCategory.ParameterList => new ParameterListParser(tokens, this),
                ElementCategory.SubroutineBody => new SubroutineBodyParser(tokens, this),
                ElementCategory.ParameterListAdditionalParameter => new ParameterListAdditionalParameterParser(tokens,
                    this),
                ElementCategory.SubroutineBodyVariableDeclaration => new VariableDeclarationParser(tokens, this),
                ElementCategory.LetStatement => new LetStatementParser(tokens, this),
                ElementCategory.IfStatement => new IfStatementParser(tokens, this),
                ElementCategory.WhileStatement => new WhileStatementParser(tokens, this),
                ElementCategory.DoStatement => new DoStatementParser(tokens, this),
                ElementCategory.ReturnStatement => new ReturnStatementParser(tokens, this),
                ElementCategory.ArrayAccessor => new ArrayAccessorParser(tokens, this),
                ElementCategory.ElseStatement => new ElseParser(tokens, this),
                ElementCategory.SubroutineCall => new SubroutineCallParser(tokens, this),
                ElementCategory.Expression => new ExpressionParser(tokens, this),
                ElementCategory.Term => new TermParser(tokens, this),
                ElementCategory.AdditionalExpressionTerm => new AdditionalExpressionParser(tokens, this),
                ElementCategory.ExpressionList => new ExpressionListParser(tokens, this),
                ElementCategory.ExpressionListAdditionalElement => new AdditionalExpressionParser(tokens, this),
                ElementCategory.Statements => new StatementsParser(tokens, this),
                _ => throw new ArgumentOutOfRangeException(nameof(elementType), elementType, null)
            };
        }
        
        public ParserBase Create(TermType termType, IEnumerable<IToken> tokens)
        {
            return termType switch
            {
                TermType.IntegerConstant => new IntegerConstantTermParser(tokens, this),
                TermType.StringConstant => new StringConstantTermParser(tokens, this),
                TermType.KeywordConstant => new KeywordConstantTermParser(tokens, this),
                TermType.VarName => new VarNameTermParser(tokens, this),
                TermType.ArrayAccess => new ArrayAccessTermParser(tokens, this),
                TermType.SubroutineCall => new SubroutineCallTermParser(tokens, this),
                TermType.ExpressionInBrackets => new ExpressionInBracketsTermParser(tokens, this),
                TermType.UnaryOperatorAndTerm => new UnaryOperatorTermParser(tokens, this),
                _ => throw new ArgumentOutOfRangeException(nameof(termType), termType, null)
            };
        }
    }
}