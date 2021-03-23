using System;
using System.Collections.Generic;

namespace Hack.JackCompiler.Lib.Parsing.Terminal
{
    public abstract class TerminalElement : IElement
    {
        public TerminalElement(string value)
        {
            Value = value ?? throw new ArgumentNullException(nameof(value));
        }

        public string Value { get; set; }
        
        public IElement Add(IElement childElement)
        {
            throw new System.InvalidOperationException("Keyword cannot have any children statements");
        }

        public IElement Add(IEnumerable<IElement> childStatements)
        {
            throw new System.InvalidOperationException("Keyword cannot have any children statements");
        }
    }
}