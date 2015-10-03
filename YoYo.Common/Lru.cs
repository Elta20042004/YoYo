using System;
using System.Collections.Generic;

namespace YoYo.Common
{
    public class Lru<TKey,TData>
    {
        private readonly Dictionary<TKey, LinkedListNode<Tuple<TData, TKey>>> _fastFind;
        private readonly LinkedList<Tuple<TData, TKey>> _priorityQueue;
        private readonly int _size;

        public Lru(int size)
        {
            _size = size;
            _fastFind = new Dictionary<TKey, LinkedListNode<Tuple<TData, TKey>>>();
            _priorityQueue = new LinkedList<Tuple<TData, TKey>>();
        }

        public TData Get(TKey key)
        {
            if (_fastFind.ContainsKey(key))
            {
                _priorityQueue.AddFirst(_fastFind[key].Value);
                _priorityQueue.Remove(_fastFind[key]);
                _fastFind[key] = _priorityQueue.First;
                return _fastFind[key].Value.Item1;
            }

            return default(TData);
        }

        public void Push(TKey key, TData value) //add data by index
        {
            if (!_fastFind.ContainsKey(key))
            {
                var newTuple = new Tuple<TData, TKey>(value, key);
                _priorityQueue.AddFirst(newTuple);
                LinkedListNode<Tuple<TData, TKey>> node = _priorityQueue.First;
                _fastFind.Add(key, node);
            }
            else
            {
                LinkedListNode<Tuple<TData, TKey>> node = _fastFind[key];
                _priorityQueue.AddFirst(node.Value);
                _priorityQueue.Remove(node);
                _fastFind[key] = _priorityQueue.First; //point on first
            }

            if (_fastFind.Count >= _size) //get from constructor
            {
                TKey k = _priorityQueue.Last.Value.Item2;
                _priorityQueue.Remove(_priorityQueue.Last);
                _fastFind.Remove(k);
            }
        }
    }
}
