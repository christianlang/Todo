namespace Todo.Entities
{
    using System.Collections.Generic;

    public class Tag
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
