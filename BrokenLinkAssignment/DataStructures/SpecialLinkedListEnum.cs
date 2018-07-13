using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    internal class SpecialLinkedListEnum<T> : IEnumerator<T>
    {
        private Node<T> _beforeHead;
        private Node<T> _current;

        public SpecialLinkedListEnum(Node<T> head)
        {
            _beforeHead = new Node<T>();
            _beforeHead.Next = head;
            _current = _beforeHead;
        }

        public T Current
        {
           get {
                return _current.Value;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void Dispose()
        {
            _beforeHead = null;
            _current = null;
        }

        public bool MoveNext()
        {
            _current = _current.Next;
            return _current != null;
        }

        public void Reset()
        {
            _current = _beforeHead;
        }
    }
}