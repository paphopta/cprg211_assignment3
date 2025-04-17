using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment3.Utility
{
    public class SLL : ILinkedListADT
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int count;
        public SLL()
        {
            Head = null;
            Tail = null;
            count = 0;
        }

        public bool IsEmpty()
        {
            if(count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }    
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
        }
        public void AddLast(User value)
        {
            Node node = new Node(value);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                Tail.Next = node;
                Tail = node;
            }
            count++;
        }
        public void AddFirst(User value)
        {
            Node node = new Node(value);
            if (Head == null)
            {
                Head = node;
                Tail = node;
            }
            else
            {
                node.Next = Head;
                Head = node;
            }
            count++;
        }
        public void Add(User value, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                AddFirst(value);
            }
            else if (index == count)
            {
                AddLast(value);
            }
            else if (index < count)
            {
                int i = 0;
                Node current = Head;
                Node node = new Node(value);
                for (i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                node.Next = current.Next;
                current.Next = node;
                count++;
                if (current == Tail)
                {
                    Tail = node;
                }
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public void Replace(User value, int index)
        {
            if (index < 0)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index < count)
            {
                int i = 0;
                Node current = Head;
                for (i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                current.user = value;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public int Count()
        {
            return count;
        }
        public void RemoveFirst()
        {
            if (Head != null)
            {
                Head = Head.Next;
                if (Head == null)
                {
                    Tail = null;
                }
                count--;
            }
            else
            {
                throw new Exception("CannotRemoveException");
            }
        }
        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new Exception("CannotRemoveException");
            }
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Node current = Head;
                while (current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
                Tail = current;
            }
            count--;
        }
        public void Remove(int index)
        {
            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index == 0)
            {
                RemoveFirst();
            }
            else if (index == count - 1)
            {
                RemoveLast();
            }
            else if (index < count - 1)
            {
                int i = 0;
                Node current = Head;
                for (i = 0; i < index - 1; i++)
                {
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                count--;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public User GetValue(int index)
        {
            int i = 0;
            Node current = Head;

            if (index < 0 || index >= count)
            {
                throw new IndexOutOfRangeException();
            }
            else if (index < count)
            {
                for (i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current.user;
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
        public int IndexOf(User value)
        {
            int index = 0;
            Node current = Head;
            while (current != null)
            {
                if (current.user.Equals(value))
                {
                    return index;
                }
                index++;
                current = current.Next;
            }
            return -1;
        }
        public bool Contains(User value)
        {
            Node current = Head;
            while (current != null)
            {
                if (current.user.Equals(value))
                {
                    return true;
                }
                current = current.Next;
            }
            return false;
        }
        public User[] ConvertArray()
        {
            if (count > 0)
            {
                int i = 0;
                Node current = Head;
                User[] userArray = new User[count];

                for (i = 0; i < count; i++)
                {
                    userArray[i] = current.user;
                    current = current.Next;
                }

                return userArray;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        public void PrintAllNodes()
        {
            Node current = Head;
            while (current != null)
            {
                Console.WriteLine($"{current.user.Id} {current.user.Name} {current.user.Email} {current.user.Password}");
                current = current.Next;
            }
        }
    }
}
