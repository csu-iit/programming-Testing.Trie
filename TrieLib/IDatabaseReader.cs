using System.Collections.Generic;

namespace TrieLib
{
    public interface IDatabaseReader
    {
        List<KeyValuePair<string, T>> LoadData<T>();
    }

    class DatabaseReader : IDatabaseReader
    {
        public List<KeyValuePair<string, T>> LoadData<T>()
        {
            //TODO 
            return null;
        }
    }
}