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
    }
}
