using System;

namespace Hack.JackCompiler.Lib.Parsing
{
    public class ParseResult
    {
        public ParseResult(int nextTokenIndex, IElement element)
        {
            NextTokenIndex = nextTokenIndex;
            Element = element ?? throw new ArgumentNullException(nameof(element));
        }

        public int NextTokenIndex { get; }
        public IElement Element { get; }
    }
}