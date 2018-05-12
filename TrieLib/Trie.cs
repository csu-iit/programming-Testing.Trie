using System.Collections.Generic;

namespace TrieLib
{
    public class Trie<T>
    {
        private readonly Dictionary<string,T> _data = new Dictionary<string, T>();

        public void Add(string key, T value)
        {
            _data.Add(key, value);
        }

        public T this[string key]
        {
            get
            {
                if (_data.ContainsKey(key))
                    return _data[key];
                else
                    return default(T);
            }   
        }
    }
}