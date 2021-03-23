using System.Collections.Generic;

namespace Hack.JackCompiler.Lib.Parsing
{
    public abstract class ElementWithChildren : IElement
    {
        public List<IElement> Elements { get; set; } = new();
        
        public virtual IElement Add(IElement childElement)
        {
            if (childElement is not VoidElement)
            {
                Elements.Add(childElement);
            }
            
            return this;
        }
        
        public virtual IElement Add(IEnumerable<IElement> childStatements)
        {
            Elements.AddRange(childStatements);
            return this;
        }
    }
}