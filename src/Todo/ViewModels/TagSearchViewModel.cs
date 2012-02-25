namespace Todo.ViewModels
{
    using System.Linq;
    using System.Windows.Controls.Primitives;

    using Caliburn.Micro;

    using Todo.Business.Contract;
    using Todo.Views;

    public class TagSearchViewModel
    {
        private readonly ITagsRepository tagsRepository;

        private string searchText;

        public TagSearchViewModel()
        {
            this.tagsRepository = IoC.Get<ITagsRepository>();
            this.TagSearchResult = new BindableCollection<string>();
        }

        public string SearchText
        {
            get
            {
                return this.searchText;
            }

            set
            {
                this.searchText = value;
                this.TagSearchResult.Clear();
                this.TagSearchResult.AddRange(
                    from t in this.tagsRepository.FindAll()
                    where t.Text.StartsWith(searchText)
                    orderby t.Text
                    select t.Text);
            }
        }

        public IObservableCollection<string> TagSearchResult { get; set; }
    }
}
