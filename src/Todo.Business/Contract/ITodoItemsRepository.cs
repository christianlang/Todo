namespace Todo.Business.Contract
{
    using System.Linq;

    using Todo.Entities;

    public interface ITodoItemsRepository
    {
        IQueryable<TodoItem> FindAll();
    }
}
