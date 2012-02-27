namespace Todo.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<TodoItem> TodoItems { get; set; }
    }
}
