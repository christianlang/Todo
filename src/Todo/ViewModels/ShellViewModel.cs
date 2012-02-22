namespace Todo.ViewModels
{
    public class ShellViewModel : IShell
    {
        public ShellViewModel(TodoListViewModel todoList, FilterViewModel filter)
        {
            this.TodoList = todoList;
            this.Filter = filter;
        }

        public TodoListViewModel TodoList { get; private set; }

        public FilterViewModel Filter { get; private set; }
    }
}
