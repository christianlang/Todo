namespace Todo.Business
{
    using System.Linq;

    using Todo.Business.Contract;
    using Todo.Data.Contract;
    using Todo.Entities;

    public class TodoItemsRepository : ITodoItemsRepository
    {
        private readonly IDataContext dataContext;

        public TodoItemsRepository(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IQueryable<TodoItem> FindAll()
        {
            return this.dataContext.TodoItems;
        }
    }
}
