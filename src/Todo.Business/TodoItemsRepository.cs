namespace Todo.Business
{
    using System.Linq;

    using Todo.Business.Contract;
    using Todo.Data.Contract;
    using Todo.Entities;

    public class TodoItemsRepository : RepositoryBase<TodoItem>, ITodoItemsRepository
    {
        public TodoItemsRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }

        public override IQueryable<TodoItem> FindAll()
        {
            return this.DataContext.TodoItems.Where(t => !t.Deleted);
        }

        public override TodoItem Find(int id)
        {
            return this.FindAll().FirstOrDefault(t => t.Id == id);
        }
    }
}
