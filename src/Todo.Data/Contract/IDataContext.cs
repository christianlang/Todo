namespace Todo.Data.Contract
{
    using System.Linq;

    using Todo.Entities;

    public interface IDataContext
    {
        /// <summary>
        /// Marks an object of a persistence-capable class to be added to the database context.
        /// </summary>
        /// <param name="persistenceCapableObject">Instance of a persistence capable class. It can also be an IEnumerable of objects to add.</param>
        void Add(object persistenceCapableObject);

        /// <summary>
        /// Marks an object from this context as 'deleted' and to be removed from the database.
        /// </summary>
        /// <param name="persistentObject">Persistent object which must be known to the context before. It can also be an IEnumerable of objects to remove.</param>
        void Remove(object persistentObject);

        /// <summary>
        /// Saves alle changes to the database. 
        /// </summary>
        /// <returns></returns>
        void Save();

        /// <summary>
        /// The TodoItems table. 
        /// </summary>
        IQueryable<TodoItem> TodoItems { get; }

        /// <summary>
        /// The Tags table. 
        /// </summary>
        IQueryable<Tag> Tags { get; }
    }
}
