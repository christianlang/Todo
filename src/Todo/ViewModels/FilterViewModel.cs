namespace Todo.ViewModels
{
    using Caliburn.Micro;

    using Todo.Business.Contract;

    public class FilterViewModel : PropertyChangedBase
    {
        private readonly IFilterService filterService;

        public FilterViewModel(IFilterService filterService)
        {
            this.filterService = filterService;
        }

        public bool All
        {
            get { return this.filterService.FilterOptions == FilterOptions.All; }
            set { if (value) this.filterService.FilterOptions = FilterOptions.All; }
        }

        public bool Today
        {
            get { return this.filterService.FilterOptions == FilterOptions.Today; }
            set { if (value) this.filterService.FilterOptions = FilterOptions.Today; }
        }

        public bool Tomorrow
        {
            get { return this.filterService.FilterOptions == FilterOptions.Tomorrow; }
            set { if (value) this.filterService.FilterOptions = FilterOptions.Tomorrow; }
        }

        public bool NextWeek
        {
            get { return this.filterService.FilterOptions == FilterOptions.NextWeek; }
            set { if (value) this.filterService.FilterOptions = FilterOptions.NextWeek; }
        }

        public bool Later
        {
            get { return this.filterService.FilterOptions == FilterOptions.Later; }
            set { if (value) this.filterService.FilterOptions = FilterOptions.Later; }
        }

        public bool NoDueDate
        {
            get { return this.filterService.FilterOptions == FilterOptions.NoDueDate; }
            set { if (value) this.filterService.FilterOptions = FilterOptions.NoDueDate; }
        }
    }
}
