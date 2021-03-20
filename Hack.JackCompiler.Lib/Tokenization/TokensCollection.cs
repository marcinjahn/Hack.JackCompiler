using System.Collections;
using System.Collections.Generic;

namespace Hack.JackCompiler.Lib.Tokenization
{
    public class TokensCollection : ICollection<IToken>
    {
        private readonly List<IToken> _tokens = new();
        
        public void Add(IToken item)
        {
            if (item is TokenToIgnore)
            {
                return;
            }

            _tokens.Add(item);
        }
        
        public IReadOnlyCollection<IToken> AsReadOnly()
        {
            return _tokens.AsReadOnly();
        }
        
        public bool IsReadOnly => false;
        
        # region No overrides
        
        public IEnumerator<IToken> GetEnumerator()
        {
            return _tokens.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Clear()
        {
            _tokens.Clear();
        }

        public bool Contains(IToken item)
        {
            return _tokens.Contains(item);
        }

        public void CopyTo(IToken[] array, int arrayIndex)
        {
            _tokens.CopyTo(array, arrayIndex);
        }

        public bool Remove(IToken item)
        {
            return _tokens.Remove(item);
        }

        public int Count => _tokens.Count;
        
        #endregion
    }
}