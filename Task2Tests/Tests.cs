using System;
using System.Linq.Expressions;
using NUnit.Framework;
using Task2;

namespace Task2Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test1()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Enqueue(8);
            queue.Enqueue(10);
            queue.Enqueue(9);
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(3033333);
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(4);
            queue.Enqueue(5);
            foreach (var element in queue)
                Console.WriteLine(element);
        }
        [Test]
        public void Test2()
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(10);
            queue.Dequeue();
            queue.Enqueue(8);
            queue.Dequeue();
            queue.Enqueue(10);
            queue.Dequeue();
            queue.Enqueue(9);
            queue.Dequeue();
            queue.Enqueue(10);
            queue.Dequeue();
            queue.Enqueue(10);
            queue.Dequeue();
            queue.Enqueue(10);
            queue.Dequeue();
            queue.Enqueue(1);
            queue.Dequeue();
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(3033333);
            queue.Enqueue(10);
            queue.Enqueue(10);
            queue.Dequeue();
            queue.Dequeue();
            queue.Enqueue(4);
            queue.Enqueue(5);
            foreach (var element in queue)
                Console.WriteLine(element);


    }
}
}
