namespace Todo.ViewModels
{
    public class NewTagSearchResultViewModel : TagSearchResultViewModel
    {
        public NewTagSearchResultViewModel(string tagName)
            : base(null)
        {
            this.TagName = tagName;
        }

        public string TagName { get; private set; }

        public override string Text
        {
            get { return string.Format("Create \"{0}\"", this.TagName); }
        }
    }
}
