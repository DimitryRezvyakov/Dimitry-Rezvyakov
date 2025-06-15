namespace ConcurrentCollections
{
    internal class ConcurrentDictionary
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing SpinLockDictionary implementation");
        }
    }

    public class SpinLockDictionary<TKey, TValue> where TKey : notnull
    {
        private readonly Dictionary<TKey, TValue> _dictionary = new();
        private volatile int _lockFlag = 0;
        private readonly SpinWait _spinWait = new();

        public bool TryAdd(TKey key, TValue value)
        {
            AcquireLock();
            try
            {
                if (_dictionary.ContainsKey(key))
                    return false;

                _dictionary.Add(key, value);
                return true;
            }
            finally
            {
                ReleaseLock();
            }
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            return _dictionary.TryGetValue(key, out value);
        }


        public bool TryRemove(TKey key, out TValue value)
        {
            AcquireLock();
            try
            {
                if (_dictionary.TryGetValue(key, out value))
                {
                    _dictionary.Remove(key);
                    return true;
                }
                value = default!;
                return false;
            }
            finally
            {
                ReleaseLock();
            }
        }

        public bool TryUpdate(TKey key, TValue newValue)
        {
            AcquireLock();
            try
            {
                if (_dictionary.ContainsKey(key))
                {
                    _dictionary[key] = newValue;
                    return true;
                }
                return false;
            }
            finally
            {
                ReleaseLock();
            }
        }

        private void AcquireLock()
        {
            while (true)
            {
                if (Interlocked.CompareExchange(ref _lockFlag, 1, 0) == 0)
                    return;

                _spinWait.SpinOnce();
            }
        }

        private void ReleaseLock()
        {
            Volatile.Write(ref _lockFlag, 0);
        }

        public int Count
        {
            get
            {
                AcquireLock();
                try
                {
                    return _dictionary.Count;
                }
                finally
                {
                    ReleaseLock();
                }
            }
        }
    }

    public class ConcurrentBinaryTree<T> where T : IComparable<T>
    {
        private class TreeNode
        {
            public T Value { get; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
            public readonly object NodeLock = new object();

            public TreeNode(T value)
            {
                Value = value;
            }
        }

        private TreeNode _root;
        private readonly object _rootLock = new object();
        public void Add(T value)
        {
            if (_root == null)
            {
                lock (_rootLock)
                {
                    if (_root == null)
                    {
                        _root = new TreeNode(value);
                        return;
                    }
                }
            }

            InsertNode(_root, value);
        }

        private void InsertNode(TreeNode node, T value)
        {
            while (true)
            {
                int comparison = value.CompareTo(node.Value);

                if (comparison < 0)
                {
                    if (node.Left == null)
                    {
                        lock (node.NodeLock)
                        {
                            if (node.Left == null)
                            {
                                node.Left = new TreeNode(value);
                                return;
                            }
                        }
                    }
                    node = node.Left;
                }
                else if (comparison > 0)
                {
                    if (node.Right == null)
                    {
                        lock (node.NodeLock)
                        {
                            if (node.Right == null)
                            {
                                node.Right = new TreeNode(value);
                                return;
                            }
                        }
                    }
                    node = node.Right;
                }
                else
                {
                    return;
                }
            }
        }

        public bool Contains(T value)
        {
            TreeNode current = _root;
            while (current != null)
            {
                int comparison = value.CompareTo(current.Value);
                if (comparison == 0)
                {
                    return true;
                }

                current = comparison < 0 ? current.Left : current.Right;
            }
            return false;
        }

        public void ParallelTraversal(Action<T> action)
        {
            if (_root == null) return;

            using (var countdown = new CountdownEvent(1))
            {
                ParallelVisit(_root, action, countdown);
                countdown.Signal();
                countdown.Wait();
            }
        }

        private void ParallelVisit(TreeNode node, Action<T> action, CountdownEvent countdown)
        {
            if (node == null) return;

            countdown.AddCount(1);
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    action(node.Value);
                }
                finally
                {
                    countdown.Signal();
                }
            });

            countdown.AddCount(1);
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    ParallelVisit(node.Left, action, countdown);
                }
                finally
                {
                    countdown.Signal();
                }
            });

            countdown.AddCount(1);
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    ParallelVisit(node.Right, action, countdown);
                }
                finally
                {
                    countdown.Signal();
                }
            });
        }

        public IEnumerable<T> GetInOrderSequence()
        {
            if (_root == null) yield break;

            var stack = new Stack<TreeNode>();
            TreeNode current = _root;

            while (stack.Count > 0 || current != null)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    current = stack.Pop();
                    yield return current.Value;
                    current = current.Right;
                }
            }
        }
    }
}