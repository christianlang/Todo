namespace Todo.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Caliburn.Micro;

    using Todo.Business.Contract;

    public class TodoListViewModel : PropertyChangedBase
    {
        private readonly IFilterService filterService;
        private readonly ITodoItemsRepository repository;

        private IList<TodoItemViewModel> todoItems;

        public TodoListViewModel(ITodoItemsRepository repository, IFilterService filterService)
        {
            this.repository = repository;
            this.filterService = filterService;

            this.filterService.FilterChanged += this.OnFilterChanged;

            this.filterService.FilterOptions = FilterOptions.All;
        }

        public IList<TodoItemViewModel> TodoItems
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

        public void Save()
        {
            this.repository.Save();
        }

        private void OnFilterChanged(object sender, EventArgs eventArgs)
        {
            this.TodoItems =
                this.repository.FindAll().Where(this.filterService.GetFilterPredicate()).ToList().Select(
                    t => new TodoItemViewModel(t)).ToList();
        }
    }
}
