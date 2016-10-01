using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _Trie;

namespace UnitTestProject
{
    [TestClass]
    public class TrieTest
    {
        [TestMethod]
        public void AddThenFind()
        {
            // arrange
            Trie trie = new Trie();

            // act
            string str = "TestString";
            trie.Add(str);

            // assert
            Assert.IsTrue(trie.Find(str));
        }
    }
}
