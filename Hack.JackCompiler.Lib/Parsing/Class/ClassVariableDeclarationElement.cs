namespace Hack.JackCompiler.Lib.Parsing.Class
{
    public class ClassVariableDeclarationElement : ElementBase
    {
        public override IElement Add(IElement childElement)
        {
            if (childElement is VariableDeclarationAdditionalElement additionalVariables)
                Elements.AddRange(additionalVariables.Elements);
            else
            {
                base.Add(childElement);
            }
            
            return this;
        }
    }
}