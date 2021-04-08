namespace EventDemo
{
    public class HistoryService
    {
        public static void FooNameChangedEventHandler(object sender, FooNameChangedEventArgs eventArg)
        {
            System.Console.WriteLine(eventArg.NewValue);
        }
    }
}