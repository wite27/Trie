using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _Trie;
using System.Collections.Generic;
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
            string str1 = "TestString";
            trie.Add(str1);
            string str2 = "TestString2";
            trie.Add(str2);
            string str3 = "Test";
            trie.Add(str3);

            // assert
            Assert.IsTrue(trie.Find(str1) && trie.Find(str2) && trie.Find(str3) && !trie.IsEmpty);
        }

        [TestMethod]
        public void AddThenDelete()
        {
            // arrange
            Trie trie = new Trie();

            // act
            string str1 = "TestString";
            trie.Add(str1);
            string str2 = "TestString2";
            trie.Add(str2);
            string str3 = "Test";
            trie.Add(str3);

            trie.Remove(str1);
            trie.Remove(str3);

            // assert
            Assert.IsTrue(!trie.Find(str1) && trie.Find(str2) && !trie.Find(str3) && !trie.IsEmpty);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DeleteNotExisting()
        {
            // arrange
            Trie trie = new Trie();

            // act
            string str1 = "TestString";
            trie.Add(str1);
            string str2 = "TestString2";
            trie.Add(str2);

            string str3 = "Test";

            // assert
            trie.Remove(str3);
        }
    }
}
