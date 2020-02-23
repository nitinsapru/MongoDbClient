using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Contracts;
using MongoDB.Driver;
using MongoDB.Exceptions;

namespace MongoDB
{
    public class MongoDbClient : IMongoDbClient
    {
        private readonly MongoClient mongoDB;

        public MongoDbClient(string connectionString)
        {
            connectionString.ShouldNotBeNullOrEmpty();

            this.mongoDB = new MongoClient(connectionString);
        }

        /// <summary>
        ///     Gets the mongoDB client object.
        /// </summary>
        /// <param name="connectionString">The connection string of the mongoDB database.</param>
        /// <returns>The mongoDB client.</returns>
        public MongoClient GetMongoDbClient
        {
            get
            {
                return this.mongoDB;
            }
        }

        /// <summary>
        ///     Gets the list of database in a MongoDB server.
        /// </summary>
        /// <returns>The list of database names in MongoDB server.</returns>
        public async Task<IEnumerable<string>> ListDatabasesAsync()
        {
            try
            {
                var databaseNames = await this.mongoDB.ListDatabaseNamesAsync().ConfigureAwait(false);
                return await databaseNames.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new MongoDbClientException($"Failed to get the database names due to exception.", ex);
            }
        }

        /// <summary>
        ///     Gets the list of collections in a MongoDB database.
        /// </summary>
        /// <param name="databaseName">The name of the database in which the collections are present.</param>
        /// <returns>The list of collections names in MongoDB database.</returns>
        public async Task<IEnumerable<string>> ListCollectionsAsync(string databaseName)
        {
            try
            {
                var collections = await this.mongoDB.GetDatabase(databaseName)
                    .ListCollectionNamesAsync().ConfigureAwait(false);

                return await collections.ToListAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new MongoDbClientException(ex);
            }
        }
    }
}
