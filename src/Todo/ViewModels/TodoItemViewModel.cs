namespace Todo.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using Caliburn.Micro;

    using Todo.Entities;

    public class TodoItemViewModel : PropertyChangedBase
    {
        private readonly TodoItem item;
        private readonly IList<TagViewModel> tags;
        
        public TodoItemViewModel(TodoItem item)
        {
            this.item = item;
            //this.tags = item.Tags.Select(t => new TagViewModel(t)).ToList();
        }

        [Required]
        public string Text
        {
            get { return this.item.Text; }
            set { this.item.Text = value; }
        }

        public string Note
        {
            get { return this.item.Note; }
            set { this.item.Note = value; }
        }

        public DateTime? DueDate
        {
            get { return this.item.DueDate; }
            set { this.item.DueDate = value; }
        }

        public IList<TagViewModel> Tags
        {
            get { return this.tags; }
        }
    }
}
