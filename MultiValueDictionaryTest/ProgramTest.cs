using MultiValueDictionary;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MultiValueDictionaryTest
{

    [TestFixture]
    public class Tests
    {
        private DictionaryExtensionHelper DictionaryExtensionHelper;

        [SetUp]
        public void SetUp()
        {
            DictionaryExtensionHelper = new DictionaryExtensionHelper();
        }

        [TearDown]
        public void TearDown()
        {
            DictionaryExtensionHelper.map.Clear();
        }

        [Test]
        public void TestKeys()
        {
            string[] values = new string[] { "foo", "baz" };
            DictionaryExtensionHelper.Add(values);
            DictionaryExtensionHelper.Keys();
            Assert.IsTrue(DictionaryExtensionHelper.map.ContainsKey("foo"));
            Assert.AreEqual(DictionaryExtensionHelper.map.Count, 1);
        }

        [Test]
        public void TestMembers()
        {
            string[] values = new string[] { "foo", "baz" };
            List<String> strlist = new List<String>();
            DictionaryExtensionHelper.Add(values);
            DictionaryExtensionHelper.Members(values);
            DictionaryExtensionHelper.map.TryGetValue(values[0], out strlist);
            Assert.IsTrue(DictionaryExtensionHelper.map.ContainsValue(strlist));

        }

        [Test]
        public void TestAdd()
        {
            string[] values = new string[] { "foo", "baz" };

            DictionaryExtensionHelper.Add(values);

            Assert.IsTrue(DictionaryExtensionHelper.map.ContainsKey("foo"));

            Assert.AreEqual(DictionaryExtensionHelper.map.Count, 1);

        }

        [Test]
        public void TestRemove()
        {
            string[] values = new string[] { "foo", "bad" };

            DictionaryExtensionHelper.Add(values);
            DictionaryExtensionHelper.Remove(values);
            Assert.IsFalse(DictionaryExtensionHelper.map.ContainsKey("foo"));
            Assert.AreEqual(DictionaryExtensionHelper.map.Count, 0);

        }

        [Test]
        public void TestRemoveAll()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values2 = new string[] { "foo", "bar" };

            DictionaryExtensionHelper.Add(values);
            DictionaryExtensionHelper.Add(values2);
            DictionaryExtensionHelper.RemoveAll(new string[] { "foo"});

            Assert.IsFalse(DictionaryExtensionHelper.map.ContainsKey("foo"));

            Assert.AreEqual(DictionaryExtensionHelper.map.Count, 0);

        }

        [Test]
        public void TestClear()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values2 = new string[] { "foo", "bar" };

            DictionaryExtensionHelper.Add(values);
            DictionaryExtensionHelper.Add(values2);
            DictionaryExtensionHelper.Clear();

            Assert.IsFalse(DictionaryExtensionHelper.map.ContainsKey("foo"));

            Assert.AreEqual(DictionaryExtensionHelper.map.Count, 0);

        }

        [Test]
        public void TestKeyExists()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values2 = new string[] { "foo", "bar" };

            DictionaryExtensionHelper.Add(values);
            DictionaryExtensionHelper.Add(values2);
            DictionaryExtensionHelper.KeyExists(new string[] { "foo" });
            Assert.IsTrue(DictionaryExtensionHelper.map.ContainsKey("foo"));
            Assert.AreEqual(DictionaryExtensionHelper.map.Count, 1);
        }

        [Test]
        public void TestMemberExists()
        {
            string[] values = new string[] { "foo", "baz" };

            DictionaryExtensionHelper.Add(values);
            Assert.IsTrue(DictionaryExtensionHelper.MemberExists(values));
            Assert.AreEqual(DictionaryExtensionHelper.map.Count, 1);
        }

        [Test]
        public void TestAllMembers()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values1 = new string[] { "foo", "bar" };
            List<String> strlist = new List<String>();
            DictionaryExtensionHelper.Add(values);
            DictionaryExtensionHelper.Add(values1);
            DictionaryExtensionHelper.AllMembers();
            DictionaryExtensionHelper.map.TryGetValue(values[0], out strlist);
            Assert.IsTrue(DictionaryExtensionHelper.map.ContainsValue(strlist));
        }

        [Test]
        public void TestItems()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values1 = new string[] { "foo", "bar" };
            List<String> strlist = new List<String>();
            DictionaryExtensionHelper.Add(values);
            DictionaryExtensionHelper.Add(values1);
            DictionaryExtensionHelper.Items();
            DictionaryExtensionHelper.map.TryGetValue(values[0], out strlist);
            Assert.IsTrue(DictionaryExtensionHelper.map.ContainsValue(strlist));
        }



    }
}
