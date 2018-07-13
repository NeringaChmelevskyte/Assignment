using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public class Node<T>
    {
        private T _value;
        private Node<T> _nextNode = null;

        public T Value { get { return _value; } set { _value = value; } }
        public Node<T> Next { get { return _nextNode;  } set { _nextNode = value; } }
    }

    // Implement linked list datastructure and all missing members for it
    public class SpecialLinkedList<T> : IEnumerable<T>
    {
        private int _count = 0;
        private Node<T> _head = null;
        private Node<T> _tail = null;

        public T Head
        {
            
            get
            {
                if (_head == null)
                    throw new EmptyListException();

                return _head.Value; // returns first element of list
            } 
        }
        
        public int Count
        {
            get
            {
                return _count;
               
            }
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return new SpecialLinkedListEnum<T>(_head);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public void Add(T item)
        {
           
            if (_head == null)
            {
                _head = new Node<T>();
                _head.Value = item;
                _tail = _head;

            }
            else
            {
                _tail.Next = new Node<T>();
                _tail = _tail.Next;
                _tail.Value = item;
            }
            _count++;
        }

        public void Remove(T item)
        {
            if (_count == 0)
                throw new EmptyListException();

            if(_head.Value.Equals(item))
            {
                if (_head == _tail)
                {
                    _tail = null;
                }
                _head = _head.Next;
                
                _count--;
                return;
            }

            Node<T> current = _head;
            while(current.Next != null)
            {
                if (current.Next.Value.Equals(item))
                {
                    
                    current.Next = current.Next.Next;
                    if (current.Next == null)
                    {
                        _tail = current;
                    }
                    _count--;
                    return;
                }
                current = current.Next;
            }
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= _count)
                throw new IndexOutOfRangeException();

            if(index == 0)
            {
                if (_head == _tail)
                {
                    _tail = null;
                }
                _head = _head.Next;
                _count--;
                return;
            }

            Node<T> current = _head;
            for (int i = 1; i < index; i++)
                current = current.Next;

            current.Next = current.Next.Next;
            _count--;
            if (current.Next == null)
            {
                _tail = current;
            }
                
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> current = _head;
            while (current != null)
            {
                if (sb.Length > 0)
                    sb.Append(',');
                sb.Append(current.Value);
                current = current.Next;
            }
            return sb.ToString();
        }

        public string ToStringReverse()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> current = _head;
            while (current != null)
            {
                if (sb.Length > 0)
                    sb.Insert(0, ',');
                sb.Insert(0, current.Value);
                current = current.Next;
            }
            return sb.ToString();
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();

                Node<T> current = _head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                return current.Value;
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new IndexOutOfRangeException();

                Node<T> current = _head;
                for (int i = 0; i < index; i++)
                    current = current.Next;

                current.Value = value;
            }
        }
    }
}
