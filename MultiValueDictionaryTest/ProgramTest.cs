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
        private Program program;

        [SetUp]
        public void SetUp()
        {
            program = new Program();
        }

        public void TearDown()
        {
            Program.map.Clear();
        }

        [Test]
        public void TestKeys()
        {
            string[] values = new string[] { "foo", "baz" };
            Program.Add(values);
            Program.Keys();
            Assert.IsTrue(Program.map.ContainsKey("foo"));
            Assert.AreEqual(Program.map.Count, 1);
        }

        [Test]
        public void TestMembers()
        {
            string[] values = new string[] { "foo", "baz" };
            List<String> strlist = new List<String>();
            Program.Add(values);
            Program.Members(values);
            Program.map.TryGetValue(values[0], out strlist);
            Assert.IsTrue(Program.map.ContainsValue(strlist));

        }

        [Test]
        public void TestAdd()
        {
            string[] values = new string[] { "foo", "baz" };

            Program.Add(values);

            Assert.IsTrue(Program.map.ContainsKey("foo"));

            Assert.AreEqual(Program.map.Count, 1);

        }

        [Test]
        public void TestRemove()
        {
            string[] values = new string[] { "foo", "bad" };

            Program.Add(values);
            Program.Remove(values);
            Assert.IsFalse(Program.map.ContainsKey("foo"));
            Assert.AreEqual(Program.map.Count, 0);

        }

        [Test]
        public void TestRemoveAll()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values2 = new string[] { "foo", "bar" };

            Program.Add(values);
            Program.Add(values2);
            Program.RemoveAll(new string[] { "foo"});

            Assert.IsFalse(Program.map.ContainsKey("foo"));

            Assert.AreEqual(Program.map.Count, 0);

        }

        [Test]
        public void TestClear()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values2 = new string[] { "foo", "bar" };

            Program.Add(values);
            Program.Add(values2);
            Program.Clear();

            Assert.IsFalse(Program.map.ContainsKey("foo"));

            Assert.AreEqual(Program.map.Count, 0);

        }

        [Test]
        public void TestKeyExists()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values2 = new string[] { "foo", "bar" };

            Program.Add(values);
            Program.Add(values2);
            Program.KeyExists(new string[] { "foo" });
            Assert.IsTrue(Program.map.ContainsKey("foo"));
            Assert.AreEqual(Program.map.Count, 1);
        }

        [Test]
        public void TestMemberExists()
        {
            string[] values = new string[] { "foo", "baz" };

            Program.Add(values);
            Assert.IsTrue(Program.MemberExists(values));
            Assert.AreEqual(Program.map.Count, 1);
        }

        [Test]
        public void TestAllMembers()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values1 = new string[] { "foo", "bar" };
            List<String> strlist = new List<String>();
            Program.Add(values);
            Program.Add(values1);
            Program.AllMembers();
            Program.map.TryGetValue(values[0], out strlist);
            Assert.IsTrue(Program.map.ContainsValue(strlist));
        }

        [Test]
        public void TestItems()
        {
            string[] values = new string[] { "foo", "baz" };
            string[] values1 = new string[] { "foo", "bar" };
            List<String> strlist = new List<String>();
            Program.Add(values);
            Program.Add(values1);
            Program.Items();
            Program.map.TryGetValue(values[0], out strlist);
            Assert.IsTrue(Program.map.ContainsValue(strlist));
        }



    }
}
