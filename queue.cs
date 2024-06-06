using System;

namespace Queue
{
    public class ArrayQueue<T>
    {
        private (int, string, bool)[] items;
        private int front;
        private int back;
        private int capacity;
        private int count;
        private int initCap = 4;

        public ArrayQueue()
        {
            capacity = initCap;
            items = new (int, string, bool)[capacity];
            front = 0;
            back = -1;
            count = 0;
        }

        public int Count
        {
            get { return count; }
        }

        public void Enqueue(int value, string txt, bool bl)
        {
            if (count == capacity)
            {
                MakeBigger();
            }

            back = (back + 1) % capacity;
            items[back] = (value, txt, bl);
            count++;
        }

        public (int, string, bool) Dequeue()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            var value = items[front];
            front = (front + 1) % capacity;
            count--;
            return value;
        }

        public (int, string, bool) Peek()
        {
            if (count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return items[front];
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        private void MakeBigger()
        {
            int new_size = capacity * 2;
            var neww = new (int, string, bool)[new_size];

            for (int i = 0; i < count; i++)
            {
                neww[i] = items[(front + i) % capacity];
            }

            items = neww;
            front = 0;
            back = count - 1;
            capacity = new_size;
        }

        public void Display()
        {
            for (int i = 0; i < count; i++)
            {
                var item = items[(front + i) % capacity];
                Console.WriteLine($"Task Number {item.Item1}: {item.Item2}");
                Console.WriteLine($"Status: {(item.Item3 ? "Completed" : "In process")}");
                Console.WriteLine("");
            }
        }
    }
}
