using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task3;


namespace Task3
{
    public class Set<T>: ISet<T>, IEquatable<T> where T : class
    {
        private T[] set;
        private int size;
        private int capacity = 10;
        private static readonly int coeffGrowing=2;

        public int Count => size;

        public bool IsReadOnly => true;

        public Set()
        {
            size = -1;
            set=new T[capacity];
            
        }
        public Set(T[] array,int size)
        {
            set =new T[capacity];
            this.size = size;
            Array.Copy(array, set, array.Length);
        }

        public static Set<T> operator+(Set<T> firstSet, Set<T> secondSet)
        {
            Set<T> newSet = CopyTo(firstSet);
            for (int i = 0; i < secondSet.size; i++)
            {
                if (Array.IndexOf<T>(firstSet.set, secondSet.set[i]) == -1)
                {
                    if (newSet.size+1 % newSet.capacity == 0 && newSet.size != 1)
                        newSet.set.GetMemory<T>(ref newSet.set,ref newSet.capacity,coeffGrowing);
                    newSet.Add(secondSet.set[i]);
                }
            }
            return newSet;
        }

        public static Set<T> operator -(Set<T> firstSet, Set<T> secondSet)
        {
            Set<T> newSet = new Set<T>();
            for (int i = 0; i < firstSet.size; i++)
            {
                if (Array.IndexOf(secondSet.set, firstSet.set[i]) == -1)
                {

                    if (newSet.size+1%newSet.capacity == 0 && newSet.size!=-1)
                        newSet.set.GetMemory<T>(ref newSet.set, ref newSet.capacity, coeffGrowing);
                    if(newSet.size==-1)newSet.size++;
                    newSet.Add(firstSet.set[i]);
                }
            }
            return newSet;
        }

        public static Set<T> operator*(Set<T> firstSet,Set<T> secondSet )
        {
            Set<T> newSet=new Set<T>();
            for (int i = 0; i < secondSet.size; i++)
            {
                if (Array.IndexOf<T>(firstSet.set, secondSet.set[i]) != -1)
                {
                    if (newSet.size + 1 % newSet.capacity == 0 && newSet.size != -1)
                        newSet.set.GetMemory<T>(ref newSet.set, ref newSet.capacity, coeffGrowing);
                    if (newSet.size == -1) newSet.size++;
                    newSet.Add(secondSet.set[i]);
                }
            }
            return newSet;
        }

        public static Set<T> Union(Set<T> firstSet, Set<T> secondSet) => firstSet + secondSet;
        public static Set<T> Intersect(Set<T> firstSet, Set<T> secondSet) => firstSet * secondSet;
        public static Set<T> Except(Set<T> firstSet, Set<T> secondSet) => firstSet - secondSet;
        public static Set<T> SymmetricExcept(Set<T> firstSet, Set<T> secondSet)
            => Union(Except(firstSet, secondSet), Except(secondSet, firstSet));

        public bool Add(T item)
        {
            if (size%capacity == 0 && size!=0)
                return false;
            set[size++] = item;
            return true;
        }

        public void UnionWith(IEnumerable<T> other)=> Union(CopyTo(this), (Set<T>)other);
        public void IntersectWith(IEnumerable<T> other) => Intersect(this, (Set<T>) other);
        public void ExceptWith(IEnumerable<T> other) => Except(this, (Set<T>) other);
        public void SymmetricExceptWith(IEnumerable<T> other)=>SymmetricExcept(this, (Set<T>)other);
        

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Add(T item)
        {
            if (size%capacity == 0 && size != 0)
                throw new IndexOutOfRangeException();
            set[size++] = item;
            
        }

        public void Clear()
        {
            Array.Clear(this.set,0,this.size);
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex) => Array.Copy(this.set, array, arrayIndex);
        public static Set<T> CopyTo(Set<T> set) => new Set<T>(set.set,set.size) ;

        public bool Remove(T item)
        {
            int i = Array.IndexOf(this.set, item);
            T[] newArray=new T[this.size-1];
            if (i != -1)
            {
                newArray = this.set.Where(val => val!= set.GetValue(i)).ToArray();
                this.set = newArray;
                return true;
            }
            else return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var element in set)
                yield return element;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Equals(T other)
        {
            throw new NotImplementedException();
        }
    }
    static class  ForExtension {
        public static void GetMemory<T>(this Array array,ref T[] set, ref int capacity,int coeffGrowing)
        {
            T[] newSet = new T[capacity*=coeffGrowing];
            Array.Copy(set,newSet, set.Length);
            set = newSet;
        }
    }
}
