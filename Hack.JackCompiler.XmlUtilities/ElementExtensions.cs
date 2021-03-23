using System;
using System.Collections;
using System.IO;
using Hack.JackCompiler.Lib.Parsing;
using Hack.JackCompiler.Lib.Parsing.Terminal;
using Microsoft.Extensions.Options;
using Polenter.Serialization;

namespace Hack.JackCompiler.XmlUtilities
{
    public static class ElementExtensions
    {
        public static string ToXml(this IElement element)
        {
            // var serializer = new System.Xml.Serialization.SimpleXmlSerializer(element.GetType());
            // using var stream = new MemoryStream();
            // serializer.Serialize(stream, element);
            //
            // using var reader = new StreamReader(stream);
            // var data = reader.ReadToEnd();
            //
            // return data;

            // using var stream = new MemoryStream();
            // var serializer = new SharpSerializer();
            // serializer.Serialize(element, stream);
            // stream.Position = 0;
            // using var reader = new StreamReader(stream);
            // var data = reader.ReadToEnd();
            // return data;

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