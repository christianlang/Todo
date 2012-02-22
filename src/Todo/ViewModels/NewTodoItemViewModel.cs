namespace Todo.ViewModels
{
    using System;

    using Caliburn.Micro;

    public class NewTodoItemViewModel : PropertyChangedBase
    {
        public string Text { get; set; }

        public DateTime? DueDate { get; set; }

        public void Clear()
        {
            this.Text = string.Empty;
            this.DueDate = null;
        
            NotifyOfPropertyChange(string.Empty);
        }
    }
}
