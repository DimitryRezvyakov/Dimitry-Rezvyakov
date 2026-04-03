using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Example.Collections
{
    public class FriendsHashSetCollection : ISocialCollection
    {
        private HashSet<Profile> _friends;

        public FriendsHashSetCollection()
        {
            _friends = new HashSet<Profile>();
        }

        public void AddFriend(Profile profile)
        {
            _friends.Add(profile);
        }

        public void RemoveFriend(Profile profile)
        {
            _friends.Remove(profile);
        }

        public IIterator<Profile> CreateIterator()
        {
            return new HashSetIterator(_friends);
        }

        private class HashSetIterator : IIterator<Profile>
        {
            private Profile[] _array;
            private int _position = 0;

            public HashSetIterator(HashSet<Profile> hashSet)
            {
                _array = hashSet.ToArray();
            }

            public bool HasNext()
            {
                return _position < _array.Length;
            }

            public Profile Next()
            {
                if (!HasNext())
                    throw new InvalidOperationException("Нет больше элементов");

                return _array[_position++];
            }

            public void Reset()
            {
                _position = 0;
            }
        }
    }
}
