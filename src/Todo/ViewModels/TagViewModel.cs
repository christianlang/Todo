namespace Todo.ViewModels
{
    using System;

    using Caliburn.Micro;

    using Todo.Entities;

    public class TagViewModel : PropertyChangedBase
    {
        public TagViewModel(Tag tag)
        {
            this.Tag = tag;
        }

        public event EventHandler OnRemove;

        public Tag Tag { get; private set; }

        public string Text
        {
            get
            {
                return this.Tag.Name;
            }

            set
            {
                this.Tag.Name = value;
                NotifyOfPropertyChange(() => Text);
            }
        }

        public void RemoveTag()
        {
            if (OnRemove != null) OnRemove(this, EventArgs.Empty);
        }
    }
}
