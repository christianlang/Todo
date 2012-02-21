namespace Todo.Business.Contract
{
    using System.Linq;

    /// <summary>
    /// Generic repository interface. 
    /// </summary>
    /// <typeparam name="TEntity">Entity type.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Adds a new object to the repository.
        /// </summary>
        /// <param name="entity">The object to add.</param>
        /// <returns>The added object.</returns>
        TEntity Add(TEntity entity);

        /// <summary>
        /// Removes an existing entity from the repository.
        /// </summary>
        /// <param name="entity"></param>
        void Remove(TEntity entity);

        /// <summary>
        /// Saves the current object scope.
        /// </summary>
        void Save();

        /// <summary>
        /// Liefert die Entität mit der angegebenen ID. 
        /// </summary>
        /// <returns>Die Entität mit der angegebenen ID oder null, wenn keine gefunden wurde. </returns>
        TEntity Find(int id);

        /// <summary>
        /// Findet alle Entitäten des entsprechenden Typs, auf die der aktuelle Benutzer Zugriff hat. 
        /// </summary>
        /// <returns>Ein IQuerably, das per LINQ weiter eingeschränkt werden kann. </returns>
        IQueryable<TEntity> FindAll();
    }
}
