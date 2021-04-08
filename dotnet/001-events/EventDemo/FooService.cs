using System;

namespace EventDemo
{
    public class FooService
    {
        public event EventHandler<FooNameChangedEventArgs> FooNameChanged;

        public void UpdateFoo()
        {
            var eventArg = new FooNameChangedEventArgs(new Foo(), "1", "2");
            OnFooNameChanged(eventArg);
        }

        public Foo NewFoo()
        {
            return new Foo
            {
                Id = 1,
                Name = "zhangsan"
            };
        }


        protected virtual void OnFooNameChanged(FooNameChangedEventArgs eventArg)
        {
            if (eventArg.NewValue != eventArg.OldValue)
                FooNameChanged?.Invoke(this, eventArg);
        }


    }
}