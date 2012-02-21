namespace Todo.Data
{
    using System.Linq;

    using Todo.Data.Contract;
    using Todo.Entities;

    public class DataContext : IDataContext
    {
        private readonly TodoContext todoDbContext = new TodoContext();

        public IQueryable<TodoItem> TodoItems
        {
            get
            {
                return this.todoDbContext.TodoItems;
            }
        }

        public IQueryable<Tag> Tags
        {
            get
            {
                return this.todoDbContext.Tags;
            }
        }

        //public IQueryable<TodoItem> TodoItems
        //{
        //    get
        //    {
        //        return new List<TodoItem>
        //            {
        //                new TodoItem
        //                    {
        //                        Id = 1, 
        //                        Text = "Erste Aufgabe"
        //                    }, 
        //                new TodoItem
        //                    { 
        //                        Id = 2, 
        //                        Text = "Zweite Aufgabe mit Notiz", 
        //                        Note = "Die Notiz (2).", 
        //                        Tags = { new Tag { Text = "Bewerbung" }, new Tag { Text = "Privat" }}
        //                    }, 
        //                new TodoItem
        //                    {
        //                        Id = 3, 
        //                        Text = "Dritte Aufgabe mit Datum (25.)", 
        //                        DueDate = new DateTime(2012, 02, 25)
        //                    }
        //            }.AsQueryable();
        //    }
        //}
    }
}
