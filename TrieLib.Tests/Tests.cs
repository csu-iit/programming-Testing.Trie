using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TrieLib.Tests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void AddDataToTrie()
        {
            //arrange
            var trie = new Trie<int>();

            //act
            trie.Add("first", 10);

            //assert
            Assert.AreEqual(10, trie["first"]);
        }

        [TestMethod]
        public void AddAnotherDataToTrie()
        {
            //arrange
            var trie = new Trie<int>();
            trie.Add("second", 99);
            trie.Add("first", 10);

            //act
            var actual = trie["second"];

            //assert
            Assert.AreEqual(99, actual);
        }

        [TestMethod]
        public void ShouldReturnDefaultValueWhenKeyNotFound()
        {
            //arrange
            var trie = new Trie<string>();

            //act
            var actual = trie["second"];

            //assert
            Assert.AreEqual(default(string), actual);
        }

        [TestMethod]
        public void ShouldReturnSeveralItemIfRequestByPrefix()
        {
            //arrange
            var trie = new Trie<int>();
            trie.Add("firstValue", 99);
            trie.Add("first", 10);

            //act
            var list = trie.GetByPrefix("first");

            //assert
            Assert.IsTrue(list.Contains(99));
            Assert.IsTrue(list.Contains(10));
        }



        [TestMethod]
        public void LoadFromDb()
        {
            //act
            var trie = Trie<int>.LoadFromDb(new FakeDatabaseReader());

            //assert
            Assert.AreEqual(10, trie["first"]);

        }
    }

    public class FakeDatabaseReader : IDatabaseReader
    {
        public List<KeyValuePair<string, T>> LoadData<T>()
        {
            return new List<KeyValuePair<string, T>>
            {
                new KeyValuePair<string, T>("first", (T) (object) 10)
            };
        }
    }
}
