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

    public class Queue<T>
    {
        protected int head_;
        protected int tail_;
        protected T[] array_;

        protected int max_array_size_;

        protected Queue(int array_size)
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

        protected void resize()
        {
            T[] new_array = new T[max_array_size_ * 2];
            for (int i = 0; i < max_array_size_; i++)
            {
                new_array[i] = array_[(head_ + i) % max_array_size_];
            }
            tail_ = getQueueSize();
            head_ = 0;
            max_array_size_ *= 2;
            array_ = new_array;
        }
    }

    public class ArrayQueue<T>:Queue<T>
    {
        public ArrayQueue(int array_size): base(array_size)
        {         
        }

        public void Enqueue(T input)
        {
            if (getQueueSize() + 1 > max_array_size_)
                resize();

            array_[tail_ % max_array_size_] = input;
            tail_++;
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

    public class ArrayDeque<T>:Queue<T>
    {
        public ArrayDeque(int array_size):base(array_size)
        {
        }

        public T get(int index)
        {
            return array_[(head_ + index) % array_.Length];
        }

        public T set(int index, T set_value)
        {
            T return_code = array_[(head_ + index) % array_.Length];
            array_[(head_ + index) % array_.Length] = set_value;
            return return_code;
        }

        public void add(int index, T set_value)
        {
            if (getQueueSize() + 1 > max_array_size_)
                resize();
            if (index < getQueueSize() / 2)
            { // shift array_[0],..,array_[i-1] left one position
                head_ = (head_ == 0) ? array_.Length - 1 : head_ - 1; //(head_ - 1) mod array_.Length 
                for (int k = 0; k <= index - 1; k++)
                    array_[(head_ + k) % array_.Length] = array_[(head_ + k + 1) % array_.Length];
            }
            else
            { // shift array_[i],..,array_[n-1] right one position
                for (int k = getQueueSize(); k > index; k--)
                    array_[(head_ + k) % array_.Length] = array_[(head_ + k - 1) % array_.Length];
                tail_++;
            }
            array_[(head_ + index) % array_.Length] = set_value;
        }

        public T remove(int index)
        {
            T return_code = array_[(head_ + index) % array_.Length];
            if (index < getQueueSize() / 2)
            { // shift array_[0],..,array_[i-1] left one position 
                for (int k = index; k > 0; k--)
                    array_[(head_ + k) % array_.Length] = array_[(head_ + k - 1) % array_.Length];
                head_++;
            }
            else
            { // shift array_[i],..,array_[n-1] right one position
                for (int k = index; k > getQueueSize() - 1; k++)
                    array_[(head_ + k) % array_.Length] = array_[(head_ + k + 1) % array_.Length];
                tail_--;
            }
            if (3 * getQueueSize() < max_array_size_)
                resize();
            return return_code;
        }
    }
}