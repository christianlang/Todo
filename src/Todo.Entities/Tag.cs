namespace Todo.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
