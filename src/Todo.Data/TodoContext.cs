namespace Todo.Data
{
    using System.Data.Entity;

    using Todo.Entities;

    internal class TodoContext : DbContext
    {
        public TodoContext()
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
