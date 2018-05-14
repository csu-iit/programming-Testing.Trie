using System.Collections.Generic;
using System.Linq;

namespace TrieLib
{
    internal class Node<T>
    {
        public Dictionary<char, Node<T>> Data = new Dictionary<char, Node<T>>();

        public T Value;

        public IEnumerable<T> GetSubTrieValues()
        {
           var results = new List<T>();

            if (Value.Equals(default(T)) == false)
                results.Add(Value);

            results.AddRange(Data.SelectMany(x => x.Value.GetSubTrieValues()));

            return results;
        }
    }
}