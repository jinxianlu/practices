using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DbContextChangeTrackerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<DemoDbContext>()
                .UseInMemoryDatabase("demo")
                .Options;

            using var context = new DemoDbContext(options);

            var foo = new Foo
            {
                Id = 1,
                Name = "zhangsan",
                Date = DateTime.Today,
                Description = "some decriptions",
                IsDeleted = false
            };

            context.Add(foo);
            context.SaveChanges();

            System.Console.WriteLine(foo.IsDeleted);

            var bar = context.Foos.AsNoTracking().FirstOrDefault();

            context.Remove(context.Foos.SingleOrDefault(f => f.Id == bar.Id));
            context.SaveChanges();

            System.Console.WriteLine(foo.IsDeleted);

            Console.ReadLine();
        }
    }
}
