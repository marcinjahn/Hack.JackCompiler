namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class TermElement : ElementWithChildren
    {
        public override IElement Add(IElement childElement)
        {
            if (childElement is ArrayAccessTermElement arrayAccess)
            {
                Elements.AddRange(arrayAccess.Elements);
                return this;
            }
            else
            {
                return base.Add(childElement);
            }

        }
    }
}