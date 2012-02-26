namespace Todo.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows.Input;

    using Caliburn.Micro;

    using Todo.Business.Contract;
    using Todo.Entities;

    public class TodoListViewModel : PropertyChangedBase
    {
        private readonly IFilterService filterService;
        private readonly ITodoItemsRepository repository;

        private IObservableCollection<TodoItemViewModel> todoItems;

        public TodoListViewModel(ITodoItemsRepository repository, IFilterService filterService)
        {
            this.repository = repository;
            this.filterService = filterService;
            this.filterService.FilterChanged += this.OnFilterChanged;
            this.filterService.FilterOptions = FilterOptions.All;

            this.NewTodoItem = new NewTodoItemViewModel();
        }

        public NewTodoItemViewModel NewTodoItem { get; set; }

        public IObservableCollection<TodoItemViewModel> TodoItems
        {
            get
            {
                return this.todoItems;
            }

            private set
            {
                this.todoItems = value;
                NotifyOfPropertyChange(() => TodoItems);
            }
        }

        // This method is called as a Caliburn Micro ActionMethod from TodoItemView. 
        public void SaveTodoList()
        {
            this.repository.Save();
        }

        public void AddNewTodo(NewTodoItemViewModel model, KeyEventArgs e)
        {
            if (e.Key == Key.Return && !string.IsNullOrWhiteSpace(model.Text))
            {
                var item = new TodoItem { Text = model.Text, DueDate = model.DueDate, Tags = new BindableCollection<Tag>() };
                this.TodoItems.Add(new TodoItemViewModel(item));
                this.repository.Add(item);
                this.repository.Save();
                model.Clear();
            }
        }

        public void DeleteTodo(TodoItemViewModel model)
        {
            model.Deleted = true;
            this.repository.Save();
            this.todoItems.Remove(model);
        }

        private void OnFilterChanged(object sender, EventArgs eventArgs)
        {
            var items = this.repository.FindAll()
                .Where(this.filterService.GetFilterPredicate())
                .OrderBy(i => i.Done).ThenBy(i => i.DueDate)
                .ToList().Select(t => new TodoItemViewModel(t));
            this.TodoItems = new BindableCollection<TodoItemViewModel>(items);
        }
    }
}
