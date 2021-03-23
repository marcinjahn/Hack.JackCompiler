namespace Hack.JackCompiler.Lib.Parsing.Subroutine
{
    public class ParameterListElement : ElementBase
    {
        public override IElement Add(IElement childElement)
        {
            
            if (childElement is ParameterListAdditionalParameterElement additionalParameter)
                Elements.AddRange(additionalParameter.Elements);
            else
            {
                base.Add(childElement);
            }
            
            return this;
        }
    }
}