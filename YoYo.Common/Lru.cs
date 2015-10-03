using System;
using System.Collections.Generic;

namespace YoYo.Common
{
    public class Lru<T>
    {
        private readonly Dictionary<int, LinkedListNode<Tuple<T, int>>> _fastFind;
        private readonly LinkedList<Tuple<T, int>> _priorityQueue;
        private readonly int _counter;

        public Lru(int length)
        {
            _counter = length;
            _fastFind = new Dictionary<int, LinkedListNode<Tuple<T, int>>>(_counter);
            _priorityQueue = new LinkedList<Tuple<T, int>>();
        }

        public T Get(int id)
        {
            if (_fastFind.ContainsKey(id))
            {
                _priorityQueue.AddFirst(_fastFind[id].Value);
                _priorityQueue.Remove(_fastFind[id]);
                _fastFind[id] = _priorityQueue.First;
                return _fastFind[id].Value.Item1;
            }

            return default(T);
        }

        public void Push(int id, T value) //add data by index
        {
            if (!_fastFind.ContainsKey(id))
            {
                var newTuple = new Tuple<T, int>(value, id);
                _priorityQueue.AddFirst(newTuple);
                LinkedListNode<Tuple<T, int>> node = _priorityQueue.First;
                _fastFind.Add(id, node);
            }
            else
            {
                LinkedListNode<Tuple<T, int>> node = _fastFind[id];
                _priorityQueue.AddFirst(node.Value);
                _priorityQueue.Remove(node);
                _fastFind[id] = _priorityQueue.First; //point on first
            }

            if (_fastFind.Count >= _counter) //get from constructor
            {
                int k = _priorityQueue.Last.Value.Item2;
                _priorityQueue.Remove(_priorityQueue.Last);
                _fastFind.Remove(k);
            }
        }
    }
}
