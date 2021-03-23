using Hack.JackCompiler.Lib.Parsing.Expressions;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class DoStatementElement : ElementBase
    {
        public override IElement Add(IElement childElement)
        {
            if (childElement is SubroutineCallElement subroutineCall)
            {
                Elements.AddRange(subroutineCall.Elements);
                return this;
            }
            
            return base.Add(childElement);
        }
    }
}