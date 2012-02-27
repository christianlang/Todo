namespace Todo.ViewModels
{
    using Todo.Entities;

    public class TagSearchResultViewModel
    {
        public TagSearchResultViewModel(Tag tag)
        {
            this.Tag = tag;
        }

        public Tag Tag { get; private set; }

        public virtual string Text
        {
            get { return this.Tag.Name; }
        }
    }
}
