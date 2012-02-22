namespace Todo
{
    using Todo.ViewModels;

    public interface IShell
    {
        TodoListViewModel TodoList { get; }
    }
}
