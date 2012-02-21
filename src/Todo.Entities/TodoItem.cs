namespace Todo.Entities
{
    using System;
    using System.Collections.Generic;

    public class TodoItem
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public string Note { get; set; }

        public DateTime? DueDate { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
