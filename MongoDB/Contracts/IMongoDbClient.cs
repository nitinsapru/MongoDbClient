using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDB.Contracts
{
    public interface IMongoDbClient
    {
        /// <summary>
        ///     Gets the mongoDB client object.
        /// </summary>
        /// <param name="connectionString">The connection string of the mongoDB database.</param>
        /// <returns>The mongoDB client.</returns>
        MongoClient GetMongoDbClient { get; }

        /// <summary>
        ///     Gets the list of database in a MongoDB server.
        /// </summary>
        /// <returns>The list of database names in MongoDB server.</returns>
        Task<IEnumerable<string>> ListDatabasesAsync();

        /// <summary>
        ///     Gets the list of collections in a MongoDB database.
        /// </summary>
        /// <param name="databaseName">The name of the database in which the collections are present.</param>
        /// <returns>The list of collections names in MongoDB database.</returns>
        Task<IEnumerable<string>> ListCollectionsAsync(string databaseName);

        /// <summary>
        ///     Gets the collection using collection name & database name.
        /// </summary>
        /// <typeparam name="T">The type of object which replicates the JSON body of the document.</typeparam>
        /// <param name="database">The database name.</param>
        /// <param name="collection">The collection name.</param>
        /// <returns>The collection object.s.</returns>
        IMongoCollection<T> GetCollection<T>(string database, string collection);

        /// <summary>
        ///     Gets the list of documents from a collection.
        /// </summary>
        /// <typeparam name="T">The type which replicates the JSON model of the document.</typeparam>
        /// <param name="database">The database name.</param>
        /// <param name="collection">The collection name.</param>
        /// <returns>The list of items present in collection.</returns>
        Task<IEnumerable<T>> ListDocumentsFromCollection<T>(string database, string collection);

        /// <summary>
        ///     Gets the list of documents from a collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mongoCollection"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> ListDocumentsFromCollection<T>(IMongoCollection<T> mongoCollection, FilterDefinition<T> filter);

        /// <summary>
        ///     Inserts bulk documents into MongoDB collection.
        /// </summary>
        /// <typeparam name="T">The type of the document used in current transaction.</typeparam>
        /// <param name="mongoCollection">The mongo DB collection.</param>
        /// <param name="documents">The list of documents.</param>
        /// <returns>The count which lets the caller know, how many documents have been inserted into specified collection.</returns>
        Task<int> AddDocumentsToCollection<T>(IMongoCollection<T> mongoCollection, IList<T> documents);

        /// <summary>
        ///     Creates a collection in a database if it does not exist.
        /// </summary>
        /// <typeparam name="T">The type of the document used in current transaction.</typeparam>
        /// <param name="collectionName">The collection name.</param>
        /// <param name="databaseName">The database name.</param>
        /// <returns>The created mongoDB collection if it is newly created or returns the existing mongoDB collection.</returns>
        Task<IMongoCollection<T>> CreateCollectionIfNotExists<T>(string collectionName, string databaseName);
    }
}
