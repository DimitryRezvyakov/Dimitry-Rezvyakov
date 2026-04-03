using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Example.Collections
{
    public class FriendsListCollection : ISocialCollection
    {
        private List<Profile> _friends;

        public FriendsListCollection()
        {
            _friends = new List<Profile>();
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
            return new ListIterator(_friends);
        }

        private class ListIterator : IIterator<Profile>
        {
            private List<Profile> _list;
            private int _position = 0;

            public ListIterator(List<Profile> list)
            {
                _list = list;
            }

            public bool HasNext()
            {
                return _position < _list.Count;
            }

            public Profile Next()
            {
                if (!HasNext())
                    throw new InvalidOperationException("Нет больше элементов");

                return _list[_position++];
            }

            public void Reset()
            {
                _position = 0;
            }
        }
    }
}
