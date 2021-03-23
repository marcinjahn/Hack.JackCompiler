using System;
using System.Collections.Generic;

namespace Hack.JackCompiler.XmlUtilities
{
    public class SimpleXmlSerializerOptions<T>
    {
        public int Indentation { get; set; } = 2;
        public Func<Type, string> NodeNameGenerator { get; set; } = type => type.Name;
        public Predicate<T> IsValueElement { get; set; }
        public Func<T, IEnumerable<T>> ChildrenAccessor { get; set; }
        public Func<T, string> ValueAccessor { get; set; }
    }
}