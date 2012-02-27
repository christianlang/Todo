namespace Todo.ViewModels
{
    using System;
    using System.Linq;
    using System.Windows;

    using Caliburn.Micro;

    using Todo.Business.Contract;
    
    public class TagSearchViewModel : ViewAware
    {
        private readonly ITagsRepository tagsRepository;

        private string searchText;

        public TagSearchViewModel()
        {
            this.tagsRepository = IoC.Get<ITagsRepository>();
            this.TagSearchResults = new BindableCollection<object>();
        }

        public event EventHandler<AddingTagEventArgs> OnAddingTag;

        public string SearchText
        {
            get
            {
                return this.searchText;
            }

            set
            {
                this.searchText = value;
                this.TagSearchResults.Clear();

                var tags = from t in this.tagsRepository.FindAll()
                           where t.Name.StartsWith(searchText)
                           orderby t.Name
                           select t;

                if (!tags.Any(t => t.Name == searchText))
                {
                    this.TagSearchResults.Add(new NewTagSearchResultViewModel(searchText));
                }
                
                this.TagSearchResults.AddRange(tags.ToList().Select(t => new TagSearchResultViewModel(t)));
            }
        }

        public IObservableCollection<object> TagSearchResults { get; set; }

        public void AddTag(TagSearchResultViewModel model)
        {
            var view = this.GetView() as Window;
            if (view != null) view.Close();

            if (this.OnAddingTag != null)
                this.OnAddingTag(model, new AddingTagEventArgs { SearchResult = model });
        }

        public class AddingTagEventArgs : EventArgs
        {
            public TagSearchResultViewModel SearchResult { get; set; }
        }
    }
}
