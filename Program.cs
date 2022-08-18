using System;
using System.Collections;

namespace LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CircularLinkedList<string> MyLl = new CircularLinkedList<string>();
            MyLl.AddFirst("Aysun");
            MyLl.AddFirst("Konul");
            MyLl.AddFirst("AYSUN");
            MyLl.AddFirst("Zehra");
            MyLl.AddFirst("Zeyneb");
            MyLl.AddFirst("Ikram");

           
            MyLl.Remove("AYSUN");
            Console.WriteLine("Count=" + MyLl.Count);

            foreach (var item in MyLl)
            {
                Console.WriteLine(item);
            }
        }
    }
    class CircularLinkedList<T> : IEnumerable
    {
        public Node<T> title { get; set; }
        public int Count { get; set; }

        public Node<T> AddFirst(T value)
        {

            if (title == null)
            {
                var newNode = new Node<T> { Value = value };
                title = newNode;
                Count++;
                return newNode;
            }
            else
            {
                var oldTitle = title;
                var newNode = new Node<T> { Value = value, Next = oldTitle };
                title = newNode;
                oldTitle.Previous = newNode.Next;
                oldTitle.Next = newNode.Previous;
                Count++;
                return title;

            }

        }
        public Node<T> AddLast(T value)
        {
            var lastNode = title;
            while (!lastNode.Next.Equals(lastNode.Previous))
            {
                lastNode = lastNode.Next;

            }
            var newNode = new Node<T> { Value = value, Previous = lastNode };
            lastNode.Next = newNode;
            Count++;
            return newNode;

        }
        public Node<T> AddAfter(Node<T> node, T value)
        {
            var newNode = new Node<T> { Value = value, Previous = node, Next = node.Next };
            node.Next.Previous = newNode;
            node.Next = newNode;
            Count++;
            return newNode;

        }
        public Node<T> AddBefore(Node<T> node, T value)
        {
            var newNode = new Node<T> { Value = value, Previous = node.Previous, Next = node };
            node.Previous.Next = newNode;
            node.Previous = newNode;
            Count++;
            return newNode;

        }
        public bool Remove(T value)
        {
            var node = title;
            while (node != null)
            {
                if (node.Value.Equals(value))

                {
                    if (node.Previous == null)
                    {
                        RemoveFirst();
                    }
                    else if (node.Next == null)
                    {
                        RemoveLast();
                    }
                    else
                    {
                        node.Next.Previous = node.Previous;
                        node.Previous.Next = node.Next;
                        Count--;
                        return true;
                    }

                }
                node = node.Next;
            }
            return false;
        }
        public void RemoveFirst()
        {
            var oldHead = title;
            title = title.Next;
            title.Previous = null;
            Count--;
        }
        public void RemoveLast()
        {
            var lastNode = title;
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
            }
            lastNode.Previous.Next = null;
            Count--;
        }

        public IEnumerator GetEnumerator()
        {
            var node = title;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;

            }
        }
    }
    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }

    }
}