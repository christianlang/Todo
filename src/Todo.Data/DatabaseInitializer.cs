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

            context.TodoItems.Add(new TodoItem { Id = 1, Text = "Erste Aufgabe" });
            context.TodoItems.Add(
                new TodoItem
                    {
                        Id = 2,
                        Text = "Zweite Aufgabe mit Notiz",
                        Tags = new[] { new Tag { Text = "Bewerbung" }, new Tag { Text = "Privat" } }
                    });
            context.TodoItems.Add(
                new TodoItem { Id = 3, Text = "Dritte Aufgabe mit Datum (25.)", DueDate = new DateTime(2012, 02, 25) });
        }
    }
}
