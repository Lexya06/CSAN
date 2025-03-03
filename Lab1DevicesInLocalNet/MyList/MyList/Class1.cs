using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyList
{
    public class MyList<T>
    {
        public ListEl First { get; set; }
        public int Length { get; set; }
        public ListEl Last { get; set; }
        public T[] toArray()
        {
            ListEl first = this.First;
            T[] array = new T[Length];
            for (int i = 0; i < Length; i++)
            {
                if (first != null && first.Data != null)
                {
                    array[i] = first.Data;
                    first = first.Next;
                }

            }
            return array;
        }
        public void Add(T data)
        {
            if (Last == null)
            {
                Last = new ListEl(data, null);
                this.First = Last;
                this.Length++;

            }
            else
            {
                ListEl pred = Last;
                Last = new ListEl(data, null);
                pred.Next = Last;
                this.Length++;
            }
        }
        public class ListEl
        {
            public T Data { get; set; }
            public ListEl Next { get; set; }

            public ListEl(T data, ListEl next)
            {
                Data = data;
                Next = next;

            }
            public ListEl(ListEl next)
            {
                Next = next;

            }

            public ListEl()
            {

            }

            public ListEl(T data)
            {
                Data = data;

            }
        }



    }
}
