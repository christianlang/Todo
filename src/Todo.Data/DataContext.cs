namespace Todo.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Todo.Data.Contract;
    using Todo.Entities;

    public class DataContext : IDataContext
    {
        private readonly TodoContext todoDbContext = new TodoContext();

        public void Add(object persistenceCapableObject)
        {
            if (persistenceCapableObject == null)
                throw new ArgumentNullException("persistenceCapableObject");
            
            this.GetDbSet(persistenceCapableObject).Add(persistenceCapableObject);
        }

        public void Remove(object persistentObject)
        {
            if (persistentObject == null)
                throw new ArgumentNullException("persistentObject");

            this.GetDbSet(persistentObject).Remove(persistentObject);
        }

        public void Save()
        {
            this.todoDbContext.SaveChanges();
        }

        public IQueryable<TodoItem> TodoItems
        {
            get { return this.todoDbContext.TodoItems; }
        }

        public IQueryable<Tag> Tags
        {
            get { return this.todoDbContext.Tags; }
        }

        private DbSet GetDbSet(object entity)
        {
            if (entity is TodoItem)
                return this.todoDbContext.TodoItems;
            
            if (entity is Tag)
                return this.todoDbContext.Tags;

            throw new ArgumentException("No DbSet found for this type.", "entity");
        }
    }
}
