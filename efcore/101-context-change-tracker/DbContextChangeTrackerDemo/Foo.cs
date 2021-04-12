using System;

namespace DbContextChangeTrackerDemo
{
    public class Foo : ISoftDeleted
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public bool IsDeleted { get; set; }
    }
}