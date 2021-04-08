using System;
using System.Collections.Generic;

namespace BlazorBootstrapDemo.Shared
{
    public class Foo
    {
        public static List<Foo> GetFoos(int count)
        {
            var random = new Random();
            var list = new List<Foo>();
            for (var i = 0; i < count; i++)
            {
                var foo = new Foo
                {
                    Name = $"zhangsan {random.Next(1000)}",
                    Address = $"beijing {random.Next(1000)}",
                    DateTime = DateTime.Today.AddDays(random.Next(100)),
                    Education = "sucks",
                    Complete = random.Next(1, 200) > 100,
                    Count = random.Next(100)
                };

                list.Add(foo);
            }
            return list;
        }
        public string Name { get; set; }

        public string Address { get; set; }

        public DateTime DateTime { get; set; }

        public string Education { get; set; }

        public bool Complete { get; set; }

        public int Count { get; set; }
    }


}