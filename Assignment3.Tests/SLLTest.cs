using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3.Tests
{
    public class SLLTest
    {
        public SLL list;
        public User user1;
        public User user2;
        public User user3;

        [SetUp]
        public void SetUp()
        {
            list = new SLL();
            user1 = new User(1, "Alice", "alice@example.com", "pass1");
            user2 = new User(2, "Bob", "bob@example.com", "pass2");
            user3 = new User(3, "Charlie", "charlie@example.com", "pass3");
        }
        
        [Test]
        public void EmptyList_IsEmptyAndCountZero()
        {
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }

        [Test]
        public void RemoveFromEmpty_ThrowsInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => list.RemoveFirst());
            Assert.Throws<InvalidOperationException>(() => list.RemoveLast());
        }

        [Test]
        public void GetValueFromEmpty_ThrowsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(0));
        }

        [Test]
        public void AddFirst_IncreasesCountAndRetrievable()
        {
            list.AddFirst(user1);
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
        }

        [Test]
        public void AddLast_IncreasesCountAndRetrievable()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user2, list.GetValue(1));
        }

        [Test]
        public void AddAtIndex_InsertsAtCorrectPosition()
        {
            list.AddLast(user1);
            list.AddLast(user3);
            list.Add(user2, 1);
            Assert.AreEqual(3, list.Count());
            Assert.AreEqual(user2, list.GetValue(1));
        }

        [Test]
        public void Add_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Add(user1, -1));
            Assert.Throws<IndexOutOfRangeException>(() => list.Add(user1, 1));
        }

        [Test]
        public void Replace_ReplacesValueAtIndex()
        {
            list.AddLast(user1);
            list.Replace(user2, 0);
            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void Replace_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Replace(user1, 0));
        }

        [Test]
        public void RemoveFirst_RemovesHead()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveFirst();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user2, list.GetValue(0));
        }

        [Test]
        public void RemoveLast_RemovesTail()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.RemoveLast();
            Assert.AreEqual(1, list.Count());
            Assert.AreEqual(user1, list.GetValue(0));
        }

        [Test]
        public void RemoveAt_RemovesCorrectNode()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);
            list.Remove(1);
            Assert.AreEqual(2, list.Count());
            Assert.AreEqual(user3, list.GetValue(1));
        }

        [Test]
        public void Remove_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(-1));
            Assert.Throws<IndexOutOfRangeException>(() => list.Remove(0));
        }

        [Test]
        public void GetValue_InvalidIndex_ThrowsIndexOutOfRangeException()
        {
            list.AddLast(user1);
            Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(-1));
            Assert.Throws<IndexOutOfRangeException>(() => list.GetValue(1));
        }

        [Test]
        public void IndexOfAndContains_WorkCorrectly()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            Assert.IsTrue(list.Contains(user2));
            Assert.AreEqual(1, list.IndexOf(user2));
            Assert.IsFalse(list.Contains(user3));
            Assert.AreEqual(-1, list.IndexOf(user3));
        }

        [Test]
        public void Reverse_ReversesListOrder()
        {
            list.AddLast(user1);
            list.AddLast(user2);
            list.AddLast(user3);
            list.Reverse();
            Assert.AreEqual(user3, list.GetValue(0));
            Assert.AreEqual(user2, list.GetValue(1));
            Assert.AreEqual(user1, list.GetValue(2));
        }

        [Test]
        public void Clear_EmptiesList()
        {
            list.AddLast(user1);
            list.Clear();
            Assert.IsTrue(list.IsEmpty());
            Assert.AreEqual(0, list.Count());
        }
    }
}