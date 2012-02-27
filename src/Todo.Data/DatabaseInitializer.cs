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

            var cv = context.Tags.Add(new Tag { Name = "CV" });
            var job = context.Tags.Add(new Tag { Name = "job application" });
            var shopping = context.Tags.Add(new Tag { Name = "shopping list" });

            int id = 0;
            context.TodoItems.Add(
                new TodoItem
                    {
                        Id = ++id,
                        Text = "write CV",
                        DueDate = new DateTime(2012, 2, 24),
                        Tags = new[] { cv, job }, 
                        Done = true
                    });
            context.TodoItems.Add(
                new TodoItem
                    {
                        Id = ++id,
                        Text = "take picture (photographer)",
                        DueDate = new DateTime(2012, 2, 23),
                        Tags = new[] { cv, job },
                        Done = true
                    });
            context.TodoItems.Add(
                new TodoItem
                    {
                        Id = ++id,
                        Text = "edit picture",
                        DueDate = new DateTime(2012, 2, 23),
                        Tags = new[] { cv, job },
                        Done = true
                    });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "scan diploma",
                    DueDate = new DateTime(2012, 2, 25),
                    Tags = new[] { job },
                    Done = true
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "download MCPD transcript",
                    DueDate = new DateTime(2012, 2, 25),
                    Tags = new[] { job },
                    Done = true
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "send application",
                    DueDate = new DateTime(2012, 2, 26),
                    Tags = new[] { job },
                    Done = true
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "wait to be interviewed",
                    Tags = new[] { job }
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "quit my current job",
                    DueDate = new DateTime(2012, 3, 31),
                    Tags = new[] { job }
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "milk",
                    DueDate = DateTime.Today.AddDays(1),
                    Tags = new[] { shopping }
                });
            context.TodoItems.Add(
                new TodoItem
                {
                    Id = ++id,
                    Text = "call Daniel",
                    DueDate = DateTime.Today.AddDays(6)
                });
        }
    }
}
