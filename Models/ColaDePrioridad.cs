using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab4.Models
{
    public class ColaDePrioridad
    {        
        public int[] heapArray { get; set; }
        public List<DeveloperIndice> HeapBuscar = new List<DeveloperIndice>();
        public int capacity { get; set; }       
        public int current_heap_size { get; set; } 
        
        public ColaDePrioridad(int n)
        {
            capacity = n;
            heapArray = new int[capacity];
            current_heap_size = 0;            
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
        
        public int Left(int key)
        {
            return 2 * key + 1;
        }
        
        public int Right(int key)
        {
            return 2 * key + 2;
        }

        
        public bool insertar(int key, string titulo1)
        {
            if (current_heap_size == capacity)
            {                
                return false;
            }
           
            int i = current_heap_size;
            DeveloperIndice temp = new DeveloperIndice(titulo1, key);
            HeapBuscar.Add(temp);
            heapArray[i] = key;
            current_heap_size++;
            
            while (i != 0 && heapArray[i] <heapArray[Padre(i)])
            {
                Intercambiar(ref heapArray[i],ref heapArray[Padre(i)]);
                i = Padre(i);
            }
            return true;
        }
       
        public void decreaseKey(int key, int new_val)
        {
            heapArray[key] = new_val;

            while (key != 0 && heapArray[key] <heapArray[Padre(key)])
            {
                Intercambiar(ref heapArray[key],ref heapArray[Padre(key)]);
                key = Padre(key);
            }
        }
        
        public int Raiz()
        {
            return heapArray[0];
        }
        
        public int extraerRaiz()
        {
            if (current_heap_size <= 0)
            {
                return int.MaxValue;
            }

            if (current_heap_size == 1)
            {
                current_heap_size--;
                return heapArray[0];
            }

            int root = heapArray[0];

            heapArray[0] = heapArray[current_heap_size - 1];
            HeapBuscar[0] = HeapBuscar[current_heap_size - 1];
            current_heap_size--;
            MinHeapify(0);

            return root;
        }

       
        public void eliminar(int key)
        {
            decreaseKey(key, int.MinValue);
            extraerRaiz();
        }

              
        public void MinHeapify(int key)
        {
            int l = Left(key);
            int r = Right(key);

            int smallest = key;
            if (l < current_heap_size &&
                heapArray[l] < heapArray[smallest])
            {
                smallest = l;
            }
            if (r < current_heap_size &&
                heapArray[r] < heapArray[smallest])
            {
                smallest = r;
            }

            if (smallest != key)
            {
                Intercambiar(ref heapArray[key],ref heapArray[smallest]);
                MinHeapify(smallest);
            }
        }
                              
    }
}
