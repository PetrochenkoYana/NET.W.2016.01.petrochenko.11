using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;

namespace Task2
{
    public class Queue<T>:IEnumerable<T>
    {
        private T[] queue;
        private int capacity;
        private int coeffGrowing;
        private int size;
        private int head;
        private int tail;

        public Queue()
        {
            capacity = int.Parse(ConfigurationManager.AppSettings["capacity"]);
            coeffGrowing = int.Parse(ConfigurationManager.AppSettings["coeffGrowing"]);
            queue =new T[capacity];
            size = 0;
            head = 0;
            tail = -1;
        }
        /// <summary>
        /// The method to insert an element into collection
        /// </summary>
        /// <param name="element">The element which must be in collection</param>
        public void Enqueue(T element)
        {
            if (this.size==this.capacity)
                Array.Resize(ref queue, capacity*=coeffGrowing);
            size++;
            queue[++tail%capacity] = element;
        }

        /// <summary>
        /// The method to remove an element out of collection
        /// </summary>
        public void Dequeue()
        {
            if (this.size == 0)
            {
                throw new InvalidOperationException();
            }
            queue[head] = default(T);
            head = (++head) % capacity;
            size--;
        }
  
        /// <summary>
        /// The method is implemented IEnumerable<T> interface, created for iterating through collection
        /// </summary>
        /// <returns>An iteratator which implements IEnumerator<T>, an object for iterating, includes methods like MoveNext,Reset and property Current</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new QueueEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Custom iterator
        /// </summary>
        /// <typeparam name="T">Type of elements in queue</typeparam>
        public class QueueEnumerator<T> : IEnumerator<T>
        {
            private Queue<T> values;
            private int position;

            public QueueEnumerator(Queue<T> values )
            {
                if (values != null)
                {
                    this.values = values;
                    position = values.head-1;
                }
                else throw new ArgumentNullException();

            }

            public T Current
            {
                get
                {
                    if (position == values.tail+1)
                    {
                        throw new InvalidOperationException();
                    }
                    return values.queue[position];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
               
            }

            public bool MoveNext()
            {
                if (position != values.size+values.head)
                {
                    position++;
                }
                return position < values.size+values.head;
            }

            public void Reset()
            {
                position = values.head-1;
            }
        }
    }
}
