namespace Todo.Business.Contract
{
    using System;
    using System.Linq.Expressions;

    using Todo.Entities;

    public interface IFilterService
    {   
        event EventHandler FilterChanged;

        FilterOptions FilterOptions { get; set; }

        Expression<Func<TodoItem, bool>> GetFilterPredicate();
    }
}
