namespace Todo.Data.Contract
{
    using System.Linq;

    using Todo.Entities;

    public interface IDataContext
    {
        IQueryable<TodoItem> TodoItems { get; }

        IQueryable<Tag> Tags { get; }
    }
}
