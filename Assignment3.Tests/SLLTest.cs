using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assignment3.Utility;

namespace Assignment3.Tests
{
    public class SLLTest
    {
        SLL users;

        [SetUp]
        public void Setup()
        {
            users = new SLL();
        }

        [TearDown]
        public void TearDown()
        {
            users = null;
        }

        [Test]
        public void TestEmpty()
        {
            Assert.AreEqual(true, users.IsEmpty());
            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            Assert.AreEqual(false, users.IsEmpty());
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            Assert.AreEqual(false, users.IsEmpty());
            users.RemoveLast();
            Assert.AreEqual(false, users.IsEmpty());
            users.RemoveLast();
            Assert.AreEqual(true, users.IsEmpty());
        }

        [Test]
        public void TestPrepend()
        {
            User result;
            User input;

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            users.AddFirst(input);
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            users.AddFirst(input);
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            users.AddFirst(input);
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            users.AddFirst(input);
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            result = users.GetValue(3);
            Assert.AreEqual(input, result);
        }

        [Test]
        public void TestAppend()
        {
            User result;
            User input;

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            users.AddLast(input);
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            users.AddLast(input);
            result = users.GetValue(1);
            Assert.AreEqual(input, result);

            input = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            users.AddLast(input);
            result = users.GetValue(2);
            Assert.AreEqual(input, result);

            input = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            users.AddLast(input);
            result = users.GetValue(3);
            Assert.AreEqual(input, result);

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);
        }

        [Test]
        public void TestInsertAtIndex()
        {
            User result;
            User input;

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            users.Add(input, 0);
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            users.Add(input, 1);
            result = users.GetValue(1);
            Assert.AreEqual(input, result);

            input = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            users.Add(input, 0);
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            Assert.Throws<NullReferenceException>(() => users.Add(input, 4));

            users.Add(input, 3);
            result = users.GetValue(3);
            Assert.AreEqual(input, result);

            Assert.Throws<NullReferenceException>(() => users.Add(input, 6));
        }

        [Test]
        public void TestReplace()
        {
            User result;
            User input;

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.Throws<NullReferenceException>(() => users.Replace(input, 0));

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            input = new User(5, "Aaa Bbb", "aaa@gmail.com", "45kdhhjhk");
            users.Replace(input, 1);
            result = users.GetValue(1);
            Assert.AreEqual(input, result);

            input = new User(6, "Ccc Ddd", "ddd@outlook.com", "7yjejeyh");
            users.Replace(input, 2);
            result = users.GetValue(2);
            Assert.AreEqual(input, result);

            input = new User(7, "Eee Fff", "eeefff@gmail.com", "aerge");
            users.Replace(input, 1);
            result = users.GetValue(1);
            Assert.AreEqual(input, result);

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            result = users.GetValue(3);
            Assert.AreEqual(input, result);

            input = new User(8, "Ggg Hhh", "hhhggg@outlook.com", "fgvethsav");
            Assert.Throws<NullReferenceException>(() => users.Replace(input, 4));
        }

        [Test]
        public void TestDeleteBeginning()
        {
            User result;
            User input;

            Assert.Throws<NullReferenceException>(() => users.RemoveFirst());

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            users.RemoveFirst();
            input = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            users.RemoveFirst();
            input = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            users.RemoveFirst();
            input = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            users.RemoveFirst();
            Assert.Throws<NullReferenceException>(() => users.RemoveFirst());
        }

        [Test]
        public void TestDeleteEnd()
        {
            User result;
            User input;

            Assert.Throws<NullReferenceException>(() => users.RemoveLast());

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            users.RemoveLast();
            input = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            result = users.GetValue(2);
            Assert.AreEqual(input, result);

            users.RemoveLast();
            input = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            result = users.GetValue(1);
            Assert.AreEqual(input, result);

            users.RemoveLast();
            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            users.RemoveLast();
            Assert.Throws<NullReferenceException>(() => users.RemoveLast());
        }

        [Test]
        public void TestDeleteMiddle()
        {
            User result;
            User input;

            Assert.Throws<NullReferenceException>(() => users.Remove(0));

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            users.Remove(0);
            input = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            result = users.GetValue(1);
            Assert.AreEqual(input, result);

            users.Remove(2);
            input = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            users.Remove(1);
            input = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            users.Remove(0);
            Assert.Throws<NullReferenceException>(() => users.Remove(0));
        }

        [Test]
        public void TestFound()
        {
            User result;
            User input;

            Assert.Throws<NullReferenceException>(() => users.GetValue(0));

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            Assert.Throws<NullReferenceException>(() => users.GetValue(4));

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            result = users.GetValue(0);
            Assert.AreEqual(input, result);

            input = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            result = users.GetValue(2);
            Assert.AreEqual(input, result);

            input = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            result = users.GetValue(3);
            Assert.AreEqual(input, result);
        }

        [Test]
        public void TestConvertArray()
        {
            User input;
            User[] userArray;

            Assert.Throws<NullReferenceException>(() => users.ConvertArray());

            users.AddLast(new User(1, "Joe Blow", "jblow@gmail.com", "password"));
            users.AddLast(new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef"));
            users.AddLast(new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555"));
            users.AddLast(new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999"));

            userArray = users.ConvertArray();

            input = new User(1, "Joe Blow", "jblow@gmail.com", "password");
            Assert.AreEqual(userArray[0], input);

            input = new User(2, "Joe Schmoe", "joe.schmoe@outlook.com", "abcdef");
            Assert.AreEqual(userArray[1], input);

            input = new User(3, "Colonel Sanders", "chickenlover1890@gmail.com", "kfc5555");
            Assert.AreEqual(userArray[2], input);

            input = new User(4, "Ronald McDonald", "burgers4life63@outlook.com", "mcdonalds999");
            Assert.AreEqual(userArray[3], input);
        }
    }
}
