namespace Todo.Data
{
    using System.Linq;

    using Todo.Data.Contract;
    using Todo.Entities;

    public class DataContext : IDataContext
    {
        private readonly TodoContext todoDbContext = new TodoContext();

        public IQueryable<TodoItem> TodoItems
        {
            get { return this.todoDbContext.TodoItems; }
        }

        public IQueryable<Tag> Tags
        {
            get { return this.todoDbContext.Tags; }
        }
    }
}
