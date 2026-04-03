using System;
using System.Collections.Generic;
using System.Text;

namespace Iterator.Example
{
    public class Profile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }

        public Profile(int id, string name, string email, int age)
        {
            Id = id;
            Name = name;
            Email = email;
            Age = age;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}, {Age} лет, {Email}";
        }
    }
}
