namespace TrieLib
{
    public class Trie<T>
    {
        private T temp;

        public void Add(string key, T value)
        {
            temp = value;
        }

        public T this[string first]
        {
            get { return temp; }
        }
    }
}