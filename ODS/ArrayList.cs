using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODS
{
    class ArrayStack
    {
        void resize<T>(ref T[] a, int n)
        {
            T[] b = new T[n * 2];
            for (int i = 0; i < n; i++)
            {
                b[i] = a[i];
            }
            a = b;
        }

        void add<T>(ref T[] a, ref int n, int i, T x)
        {
            if (n + 1 > a.Length)
                resize(ref a, n);
            for (int j = n; j > i; j--)
                a[j] = a[j - 1];
            a[i] = x;
            n++;
        }

        T remove<T>(ref T[] a, ref int n, int i)
        {
            T x = a[i];
            for (int j = i; j < n - 1; j++)
                a[j] = a[j + 1];
            n--;
            if (a.Length >= 3 * n)
                resize(ref a, n);
            return x;
        }
    }

    class FastArrayStack
    {
        void resize<T>(ref T[] a, int n)
        {
            Array.Resize<T>(ref a, 2 * n);
        }

        void add<T>(ref T[] a, ref int n, int i, T x)
        {
            if (n + 1 > a.Length)
                resize(ref a, n);

            Array.Copy(a, i, a, i + 1, n - i);

            a[i] = x;
            n++;
        }

        T remove<T>(ref T[] a, ref int n, int i)
        {
            T x = a[i];
            if (n + 1 > a.Length)
                resize(ref a, n);

            Array.Copy(a, i + 1, a, i, n - i - 1);
            n--;

            if (a.Length >= 3 * n)
                resize<T>(ref a, n);

            return x;
        }
    }

    public class ArrayQueue<T>
    {
        int head_;
        int tail_;
        T[] array_;

        int max_array_size_;

        public ArrayQueue(int array_size)
        {
            head_ = 0;
            tail_ = 0;
            max_array_size_ = array_size;

            array_ = new T[max_array_size_];
        }

        public int getQueueSize()
        {
            return tail_ - head_;
        }

        public void Enqueue(T input)
        {
            if (getQueueSize() + 1 > max_array_size_)
                resize();

            array_[tail_ % max_array_size_] = input;
            tail_++;
        }

        private void resize()
        {
            T[] new_array = new T[max_array_size_ * 2];
            for(int i = 0; i < max_array_size_; i++)
            {
                new_array[i] = array_[(head_ + i) % max_array_size_];
            }
            tail_ = getQueueSize();
            head_ = 0;
            max_array_size_ *= 2;
            array_ = new_array;
        }

        public T Dequeue()
        {
            if (getQueueSize() == 0)
                return default(T);

            T return_code = array_[head_ % max_array_size_];
            head_++;
            return return_code;
        }
    }
}