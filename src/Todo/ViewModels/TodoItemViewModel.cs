namespace Todo.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Dynamic;

    using Caliburn.Micro;

    using Todo.Business.Contract;
    using Todo.Entities;

    public class TodoItemViewModel : PropertyChangedBase
    {
        private readonly TodoItem item;
        private readonly IObservableCollection<TagViewModel> tags;
        
        public TodoItemViewModel(TodoItem item)
        {
            this.item = item;

            this.tags = new BindableCollection<TagViewModel>();
            foreach (var tag in item.Tags)
            {
                var model = new TagViewModel(tag);
                this.tags.Add(model);
                model.OnRemove += this.OnRemoveTag;
            }
        }

        public bool Done
        {
            get { return this.item.Done; }
            set { this.item.Done = value; }
        }

        [Required]
        public string Text
        {
            get { return this.item.Text; }
            set { this.item.Text = value; }
        }

        public DateTime? DueDate
        {
            get { return this.item.DueDate; }
            set { this.item.DueDate = value; }
        }

        public IObservableCollection<TagViewModel> Tags
        {
            get { return this.tags; }
        }

        public void AddTag()
        {
            dynamic settings = new ExpandoObject();
            settings.StaysOpen = false;

            var wm = new WindowManager();
            wm.ShowWindow(new TagSearchViewModel(), null, settings);
        }

        private void OnRemoveTag(object sender, EventArgs eventArgs)
        {
            var tag = sender as TagViewModel;
            if (tag != null && this.tags.Contains(tag))
            {
                this.tags.Remove(tag);
                this.item.Tags.Remove(tag.Tag);
            }
        }
    }
}
