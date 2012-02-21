namespace Todo.Business
{
    using System.Linq;

    using Todo.Business.Contract;
    using Todo.Data.Contract;
    using Todo.Entities;

    public class TagsRepository : RepositoryBase<Tag>, ITagsRepository
    {
        public TagsRepository(IDataContext dataContext)
            : base(dataContext)
        {
        }

        public override IQueryable<Tag> FindAll()
        {
            return this.DataContext.Tags;
        }

        public override Tag Find(int id)
        {
            return this.FindAll().FirstOrDefault(t => t.Id == id);
        }
    }
}
