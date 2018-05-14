using System.Collections.Generic;

namespace TrieLib
{
    public class Trie<T>
    {
        private readonly Node<T> root = new Node<T>();

        public void Add(string key, T value)
        {
            var node = root;
            foreach (var ch in key)
            {
                Node<T> newNode;
                if (node.Data.ContainsKey(ch))
                    newNode = node.Data[ch];
                else
                {
                    newNode = new Node<T>();
                    node.Data.Add(ch, newNode);
                }

                node = newNode;
            }
            node.Value = value;
        }

        public T this[string key]
        {
            get
            {
                var node = GetNodeByKey(key);

                if (node == null)
                    return default(T);

                return node.Value;
            }   
        }

        private Node<T> GetNodeByKey(string key)
        {
            var node = root;
            foreach (var ch in key)
            {
                if (node.Data.ContainsKey(ch) == false)
                    return null;
                else
                {
                    node = node.Data[ch];
                }
            }

            return node;
        }

        public IEnumerable<T> GetByPrefix(string prefix)
        {
            var node = GetNodeByKey(prefix);
            return node.GetSubTrieValues();
        }

        public static Trie<T> LoadFromDb(IDatabaseReader reader)
        {
            var data = reader.LoadData<T>();

            var trie = new Trie<T>();

            foreach (var keyValuePair in data)
            {
                trie.Add(keyValuePair.Key, keyValuePair.Value);
            }

            return trie;
        }
    }
}