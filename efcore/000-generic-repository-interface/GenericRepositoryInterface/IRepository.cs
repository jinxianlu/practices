namespace GenericRespositoryInterface
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        public void Add(TEntity entity);

    }
}