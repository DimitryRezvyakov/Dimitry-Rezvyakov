using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Example
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Complexity { get; set; }
        public string Category { get; set; }

        public Ticket(int id, string title, string description, int complexity, string category)
        {
            Id = id;
            Title = title;
            Description = description;
            Complexity = complexity;
            Category = category;
        }

        public override string ToString()
        {
            return $"Тикет #{Id}: {Title} (сложность: {Complexity}, категория: {Category})";
        }
    }
}
