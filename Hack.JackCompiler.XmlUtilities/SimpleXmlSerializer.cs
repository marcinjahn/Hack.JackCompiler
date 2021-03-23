using System.Text;
using Microsoft.Extensions.Options;

namespace Hack.JackCompiler.XmlUtilities
{
    public class SimpleXmlSerializer<T>
    {
        private readonly SimpleXmlSerializerOptions<T> _options;

        public SimpleXmlSerializer(IOptions<SimpleXmlSerializerOptions<T>> options)
        {
            _options = options.Value;
        }
        
        public string Serialize(T thing)
        {
            var stringBuilder = new StringBuilder();
            Serialize(thing, stringBuilder, 0);
            return stringBuilder.ToString();
        }

        private void Serialize(T thing, StringBuilder stringBuilder, int indentation)
        {
            var nodeName = _options.NodeNameGenerator(thing.GetType());

            if (_options.IsValueElement(thing))
            {
                stringBuilder.Append($"{GetSpaces(indentation)}<{nodeName}>");
                stringBuilder.Append($" {_options.ValueAccessor(thing)} ");
                stringBuilder.AppendLine($"</{nodeName}>");
            }
            else
            {
                stringBuilder.AppendLine($"{GetSpaces(indentation)}<{nodeName}>");
                
                foreach (var child in _options.ChildrenAccessor(thing))
                {
                    Serialize(child, stringBuilder, indentation + _options.Indentation);
                }
                
                stringBuilder.AppendLine($"{GetSpaces(indentation)}</{nodeName}>");
            }
        }

        private static string GetSpaces(int n)
        {
            return new(' ', n);
        }
    }
}