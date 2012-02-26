namespace Todo.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TodoItem
    {
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        public bool Done { get; set; }

        public DateTime? DueDate { get; set; }

        public bool Deleted { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }
}
