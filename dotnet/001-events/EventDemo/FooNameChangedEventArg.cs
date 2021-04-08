using System;

namespace EventDemo
{
    public class FooNameChangedEventArgs : EventArgs
    {
        public Foo ChangedObject { get; }

        public string OldValue {get;set;}

        public string  NewValue { get; set; }

        public FooNameChangedEventArgs(Foo changedObject, string newValue, string oldValue)
        {
            ChangedObject = changedObject;
            OldValue=oldValue;
            NewValue = newValue;
        }
    }

}