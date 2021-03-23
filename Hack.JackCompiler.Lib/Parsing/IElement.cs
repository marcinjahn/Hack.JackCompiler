using System.Collections.Generic;

namespace Hack.JackCompiler.Lib.Parsing
{
    public interface IElement
    {
        IElement Add(IElement childElement);
        IElement Add(IEnumerable<IElement> childStatements);
    }
}