using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class ColaDePrioridad<T> where T : IComparable
    {
        public int[] heapArray { get; set; }
        public int capacidad { get; set; }
        public int tamaño_A { get; set; }
        public ColaDePrioridad(int n)
        {
            capacidad = n;
            heapArray = new int[capacidad];
            tamaño_A = 0;
        }
        public static void Intercambiar<T>(ref T lhs, ref T rhs)
        {
            T temp = lhs;
            lhs = rhs;
            rhs = temp;
        }
        public int Padre(int key)
        {
            return (key - 1) / 2;
        }
        public int Izquierda(int key)
        {
            return 2 * key + 1;
        }
        public int Derecha(int key)
        {
            return 2 * key + 2;
        }
        public bool insertKey(string title, int key)
        {
            DeveloperIndice temp = new DeveloperIndice();
            temp.prioridad = key;
            temp.titulo = title;
            if (tamaño_A == capacidad)
            {
                return false;
            }
            int i = tamaño_A;
            heapArray[i] = key;
            Singleton.Instance.prioridad.Insert(i,temp);
            tamaño_A++;
            while (i != 0 && heapArray[i] < heapArray[Padre(i)])
            {
                Intercambiar(ref heapArray[i], ref heapArray[Padre(i)]);
                i = Padre(i);
            }
            return true;
        }
        public void decreaseKey(int key, int new_val)
        {
            heapArray[key] = new_val;

            while (key != 0 && heapArray[key] < heapArray[Padre(key)])
            {
                Intercambiar(ref heapArray[key], ref heapArray[Padre(key)]);
                key = Padre(key);
            }
        }
        public int Raiz()
        {
            return heapArray[0];
        }
        public int EliminarRaiz()
        {
            if (tamaño_A <= 0)
            {
                return int.MaxValue;
            }
            if (tamaño_A == 1)
            {
                tamaño_A--;
                return heapArray[0];
            }
            int root = heapArray[0];
            heapArray[0] = heapArray[tamaño_A - 1];
            tamaño_A--;
            MinHeapify(0);
            return root;
        }
        public void deleteKey(int key)
        {
            decreaseKey(key, int.MinValue);
            EliminarRaiz();
        }

        public void MinHeapify(int key)
        {
            int l = Izquierda(key);
            int r = Derecha(key);

            int smallest = key;
            if (l < tamaño_A &&
                heapArray[l] < heapArray[smallest])
            {
                smallest = l;
            }
            if (r < tamaño_A &&
                heapArray[r] < heapArray[smallest])
            {
                smallest = r;
            }

            if (smallest != key)
            {
                Intercambiar(ref heapArray[key], ref heapArray[smallest]);
                MinHeapify(smallest);
            }
        }
        public void increaseKey(int key, int new_val)
        {
            heapArray[key] = new_val;
            MinHeapify(key);
        }
        public void changeValueOnAKey(int key, int new_val)
        {
            if (heapArray[key] == new_val)
            {
                return;
            }
            if (heapArray[key] < new_val)
            {
                increaseKey(key, new_val);
            }
            else
            {
                decreaseKey(key, new_val);
            }
        }
    }
}
