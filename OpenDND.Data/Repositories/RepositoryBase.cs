namespace OpenDND.Data.Repositories
{
    /// <summary>
    /// Describes a basic repository, which acts as a gatekeeper for all data storage and data retrieval operations,
    /// involving a particular type of data or record, and performs all interaction with the data storage layer.
    /// </summary>
    ///
    public class RepositoryBase
    {
        public RepositoryBase(OpenDNDContext openDndContext)
        {
            OpenDndContext = openDndContext;
        }
        
        /// <summary>
        /// The <see cref="Data.OpenDNDContext"/> to be used to interact with the data storage layer.
        /// </summary>
        internal protected OpenDNDContext OpenDndContext { get; }
    }
}