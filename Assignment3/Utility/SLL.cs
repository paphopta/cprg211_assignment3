using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class SLL : ILinkedListADT<User>
    {
        public Node<User> Head { get; set; }

        public Node<User> Tail { get; set; }

        public int count { get; set; }

        public SLL()
        {
            Head = null;
            Tail = null;
            count = 0;
        }
        public int Count()
        {
            return count;
        }

        public void AddFirst(User data)
        {
            Node<User> node = new Node<User>(data);
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

        public bool IsEmpty()
        { 
            return count == 0; 
        }
        public void Clear()
        {
            Head = null;
            Tail = null;
            count = 0;
            Console.WriteLine("The list has been cleared.");
        }

        public void AddLast(User data)
        {
            Node<User> node = new Node<User>(data);
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
        public void Add(User value, int index)
        {
            if (index < 0 || index > count)
                throw new IndexOutOfRangeException("Index out of range");

            if (index == 0)
            {
                AddFirst(value);
                return;
            }
            if (index == count)
            {
                AddLast(value);
                return;
            }
            Node<User> newNode = new Node<User>(value);
            Node<User> current = Head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;
            newNode.Next = current.Next;
            current.Next = newNode;
            count++;
        }
        public void Replace(User value, int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index out of range");

            Node<User> current = Head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            current.Data = value;
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
                throw new InvalidOperationException("The list is empty");
            }
        }

        public void RemoveLast()
        {
            if (Head == null)
            {
                throw new InvalidOperationException("List is empty");
            }
            if (Head.Next == null)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Node<User> current = Head;
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
                throw new IndexOutOfRangeException("Index out of range");

            if (index == 0)
            {
                RemoveFirst();
                return;
            }

            Node<User> current = Head;
            for (int i = 0; i < index - 1; i++)
                current = current.Next;
            current.Next = current.Next.Next;
            if (index == count - 1)
                Tail = current;
            count--;
        }
        public User GetValue(int index)
        {
            if (index < 0 || index >= count)
                throw new IndexOutOfRangeException("Index out of range");

            Node<User> current = Head;
            for (int i = 0; i < index; i++)
                current = current.Next;
            return current.Data;
        }
        public int IndexOf(User value)
        {
            Node<User> current = Head;
            int index = 0;
            while (current != null)
            {
                if (current.Data.Equals(value))
                    return index;
                current = current.Next;
                index++;
            }
            return -1;
        }

        public bool Contains(User value)
        {
            return IndexOf(value) != -1;
        }
    }
}
