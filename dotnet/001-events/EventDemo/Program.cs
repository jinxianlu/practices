using System;

namespace EventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var fooService = new FooService();
            fooService.FooNameChanged += HistoryService.FooNameChangedEventHandler;
            fooService.UpdateFoo();


            var foo = fooService.NewFoo();
            foo.PropertyChanged += (sender, e) => Console.WriteLine(e.PropertyName);

            foo.Name="lisi";

            Console.ReadLine();

        }
    }
}
