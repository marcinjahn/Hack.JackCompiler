namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class IfStatementElement : ElementBase
    {
        public override IElement Add(IElement childElement)
        {
            if (childElement is ElseElement elseElement)
            {
                Elements.AddRange(elseElement.Elements);
                return this;
            }
            return base.Add(childElement);
        }
    }
}