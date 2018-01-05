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
}
