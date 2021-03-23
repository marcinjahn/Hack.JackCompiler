using Hack.JackCompiler.Lib.Parsing;
using Hack.JackCompiler.Lib.Parsing.Terminal;
using Microsoft.Extensions.Options;

namespace Hack.JackCompiler.XmlUtilities
{
    public static class ElementExtensions
    {
        public static string ToXml(this IElement element)
        {
            var options = new SimpleXmlSerializerOptions<IElement>
            {
                Indentation = 2,
                IsValueElement = n => n is TerminalElement,
                ChildrenAccessor = n => (n as ElementWithChildren).Elements,
                ValueAccessor = n => (n as TerminalElement).Value,
                NodeNameGenerator = t => t.Name.Replace("Element", string.Empty)
            };

            var serializer = new SimpleXmlSerializer<IElement>(
                new OptionsWrapper<SimpleXmlSerializerOptions<IElement>>(options));

            return serializer.Serialize(element);
        }
    }
}