namespace Todo.ViewModels
{
    using Caliburn.Micro;

    using Todo.Entities;

    public class TagViewModel : PropertyChangedBase
    {
        private readonly Tag tag;

        public TagViewModel(Tag tag)
        {
            this.tag = tag;
        }

        public string Text
        {
            get
            {
                return this.tag.Text;
            }

            set
            {
                this.tag.Text = value;
                NotifyOfPropertyChange(() => Text);
            }
        }
    }
}
