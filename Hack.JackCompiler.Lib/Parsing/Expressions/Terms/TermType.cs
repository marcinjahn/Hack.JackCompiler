namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public enum TermType
    {
        IntegerConstant,
        StringConstant,
        KeywordConstant,
        VarName,
        ArrayAccess,
        SubroutineCall,
        ExpressionInBrackets,
        UnaryOperatorAndTerm
    }
}