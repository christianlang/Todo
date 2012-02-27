namespace Todo.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Dynamic;

    using Caliburn.Micro;

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

        public bool Deleted
        {
            get { return this.item.Deleted; }
            set { this.item.Deleted = value; }
        }

        public IObservableCollection<TagViewModel> Tags
        {
            get { return this.tags; }
        }

        public void ShowTagSearch()
        {
            var tagSearch = new TagSearchViewModel();
            tagSearch.OnAddingTag += this.OnOnAddingTag;

            var wm = new WindowManager();
            wm.ShowWindow(tagSearch);
        }

        private void OnOnAddingTag(object sender, TagSearchViewModel.AddingTagEventArgs e)
        {
            Tag tag;
            if (e.SearchResult is NewTagSearchResultViewModel)
            {
                tag = new Tag { Name = ((NewTagSearchResultViewModel)e.SearchResult).TagName };
            }
            else
            {
                tag = e.SearchResult.Tag;
            }

            this.item.Tags.Add(tag);
            this.tags.Add(new TagViewModel(tag));
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
