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
    }
}
