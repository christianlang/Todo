namespace Todo.Business
{
    using System;
    using System.Linq.Expressions;

    using Todo.Business.Contract;
    using Todo.Entities;

    public class FilterService : IFilterService
    {
        public event EventHandler FilterChanged;

        private FilterOptions filterOptions;

        public FilterService()
        {
            this.filterOptions = FilterOptions.All;
        }

        public FilterOptions FilterOptions
        {
            get
            {
                return this.filterOptions;
            }

            set
            {
                this.filterOptions = value;
                if (FilterChanged != null) FilterChanged(this, EventArgs.Empty);
            }
        }

        public Expression<Func<TodoItem, bool>> GetFilterPredicate()
        {
            switch (FilterOptions)
            {
                case FilterOptions.Today:
                    return t => t.DueDate == DateTime.Today;
                case FilterOptions.Tomorrow:
                    var tomorrow = DateTime.Today.AddDays(1);
                    return t => t.DueDate == tomorrow;
                case FilterOptions.NextWeek:
                    var in7Days = DateTime.Today.AddDays(7);
                    return t => t.DueDate >= DateTime.Today && t.DueDate <= in7Days;
                case FilterOptions.Later:
                    var in8Days = DateTime.Today.AddDays(8);
                    return t => t.DueDate >= in8Days;
                case FilterOptions.NoDueDate:
                    return t => !t.DueDate.HasValue;
                case FilterOptions.All:
                    return t => true;
                default:
                    throw new ArgumentOutOfRangeException("Unknown value for FilterOption. ");
            }
        }
    }
}
