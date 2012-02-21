namespace Todo.Business
{
    using System.Linq;

    using Todo.Business.Contract;
    using Todo.Data.Contract;

    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected RepositoryBase(IDataContext dataContext)
        {
            this.DataContext = dataContext;
        }

        public IDataContext DataContext { get; set; }

        public TEntity Add(TEntity entity)
        {
            this.DataContext.Add(entity);
            return entity;
        }

        public void Remove(TEntity entity)
        {
            this.DataContext.Remove(entity);
        }

        public void Save()
        {
            this.DataContext.Save();
        }

        public abstract TEntity Find(int id);

        public abstract IQueryable<TEntity> FindAll();
    }
}
