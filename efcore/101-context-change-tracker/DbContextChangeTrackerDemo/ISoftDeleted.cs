namespace DbContextChangeTrackerDemo
{
    public interface ISoftDeleted
    {
        bool IsDeleted { get; set; }
    }
}