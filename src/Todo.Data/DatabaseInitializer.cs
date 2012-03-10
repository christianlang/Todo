namespace Todo.Data
{
    using System;
    using System.Data.Entity;

    using Todo.Entities;

    /// <summary>
    /// Simple initializer that creates a database with sample data on first startup. For testing purposes 
    /// it also recreates the database everytime the model (schema) changes. For production we have to use migrations 
    /// (see http://blogs.msdn.com/b/adonet/archive/2012/02/09/ef-4-3-code-based-migrations-walkthrough.aspx). 
    /// </summary>
    internal class DatabaseInitializer : DropCreateDatabaseIfModelChanges<TodoContext>
    {
        protected override void Seed(TodoContext context)
        {
            base.Seed(context);

            var shopping = context.Tags.Add(new Tag { Name = "shopping list" });

            int id = 0;
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "milk",
                    Tags = new[] { shopping }
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "butter",
                    Tags = new[] { shopping }
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "eggs",
                    Tags = new[] { shopping }
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "call Daniel",
                    DueDate = DateTime.Today.AddDays(3)
                });
        }
    }
}
