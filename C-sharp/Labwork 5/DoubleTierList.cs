using System.Collections;

namespace Labwork_5
{
    public class DoublyTierList<T> : IEnumerable<T>
    {
        private DoubleTierNode<T>? _head;
        private DoubleTierNode<T>? _tail;
        private int _count;
        public int Count { get => _count; }
        public bool IsEmpty { get => _count == 0; }
 
        public void Add(T data)
        {
            ip15_pluhatyrov_05.ValidateData(data);
            DoubleTierNode<T>? node = new DoubleTierNode<T>(data);
 
            if (_head == null)
            {
                _head = node;
            }
            else
            {
                _tail.Next = node;
                node.Previous = _tail;
            }

            _tail = node;
            _count++;
        }

        public void AddFirst(T data)
        {

            DoubleTierNode<T>? node = new DoubleTierNode<T>(data);
            DoubleTierNode<T>? tempNode = _head;
            node.Next = tempNode;
            _head = node;

            if (_count == 0)
            {
                _tail = _head;
            }
            else
            {
                tempNode.Previous = node;
            }

            _count++;
        }
        
        public bool Remove(T data)
        {
            DoubleTierNode<T>? current = _head;
 
            while (current != null && !current.Data.Equals(data))
            {
                current = current.Next;
            }

            if(current != null)
            {
                if(current.Next != null)
                {
                    current.Next.Previous = current.Previous;
                }
                else
                {
                    _tail = current.Previous;
                }
 
                if(current.Previous!=null)
                {
                    current.Previous.Next = current.Next;
                }
                else
                {
                    _head = current.Next;
                }

                _count--;

                return true;
            }

            return false;
        }
 
        public void Clear()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }
 
        public bool Contains(T data)
        {
            DoubleTierNode<T>? currentNode = _head;

            while (currentNode != null)
            {
                if (currentNode.Data.Equals(data))
                {
                    return true;
                }

                currentNode = currentNode.Next;
            }

            return false;
        }
         
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
 
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoubleTierNode<T>? currentNode = _head;

            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Next;
            }
        }
 
        public IEnumerable<T> BackEnumerator()
        {
            DoubleTierNode<T>? currentNode = _tail;

            while (currentNode != null)
            {
                yield return currentNode.Data;
                currentNode = currentNode.Previous;
            }
        }
    }
}