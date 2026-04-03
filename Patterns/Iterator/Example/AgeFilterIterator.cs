using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Example
{
    /// <summary>
    /// просто доп итератор на возраст как пример
    /// </summary>
    public class AgeFilterIterator : IIterator<Profile>
    {
        private IIterator<Profile> _innerIterator;
        private int _minAge;
        private int _maxAge;
        private Profile _nextItem;
        private bool _hasNextCached;

        public AgeFilterIterator(IIterator<Profile> iterator, int minAge, int maxAge)
        {
            _innerIterator = iterator;
            _minAge = minAge;
            _maxAge = maxAge;
            _hasNextCached = false;
            _nextItem = null;
        }

        public bool HasNext()
        {
            if (_hasNextCached)
                return true;

            while (_innerIterator.HasNext())
            {
                var item = _innerIterator.Next();
                if (item.Age >= _minAge && item.Age <= _maxAge)
                {
                    _nextItem = item;
                    _hasNextCached = true;
                    return true;
                }
            }

            return false;
        }

        public Profile Next()
        {
            if (!HasNext())
                throw new InvalidOperationException("Нет больше элементов");

            var result = _nextItem;
            _nextItem = null;
            _hasNextCached = false;
            return result;
        }

        public void Reset()
        {
            _innerIterator.Reset();
            _hasNextCached = false;
            _nextItem = null;
        }
    }
}
