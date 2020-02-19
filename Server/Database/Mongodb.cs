using AltV.Net;
using FiveZ.Models;
using FiveZ.Utils;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using MongoDB.Driver.Core.Clusters;
using System;
using System.Drawing;
using System.Numerics;
using System.Threading.Tasks;

namespace FiveZ.Database
{
    public static class MongoDB
    {
        #region Private static variables
        private static IMongoClient _client;
        private static IMongoDatabase _database;
        #endregion

        #region Methods
        public static bool Init()
        {
            Alt.Server.LogInfo("MongoDB Starting ...");

            try
            {
                string host = Config.GetSetting<string>("host");
                string databaseName = Config.GetSetting<string>("database");
                string user = Config.GetSetting<string>("user");
                string password = Config.GetSetting<string>("password");
                int port = Config.GetSetting<int>("port");

                if (!string.IsNullOrEmpty(host))
                    _client = new MongoClient($"mongodb://{user}:{password}@{host}:{port}");
                else
                    _client = new MongoClient();

                _client.ListDatabaseNames();

                _database = _client.GetDatabase(databaseName);

                if (_database == null)
                    return false;
     
                Alt.Server.LogInfo("MongoDB Started!");
            }
            catch (Exception ex)
            {
                Alt.Server.LogError(ex.ToString());
                return false;
            }

            var conventionPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
            ConventionRegistry.Register("IgnoreExtraElements", conventionPack, type => true);

            BsonSerializer.RegisterSerializer(typeof(Vector3), new VectorSerializer());
            BsonSerializer.RegisterSerializer(typeof(Color), new ColorBsonSerializer());

            BsonClassMap.RegisterClassMap<Location>(cm =>
            {
                cm.AutoMap();
                cm.MapProperty(c => c.Pos).SetSerializer(new VectorSerializer());
                cm.MapProperty(c => c.Rot).SetSerializer(new VectorSerializer());
            });

            return _client.Cluster.Description.State == ClusterState.Connected;
        }

        public async static Task Insert<T>(string collectionName, T objet)
        {
            try
            {
                var collection = GetCollectionSafe<T>(collectionName);
                await collection.InsertOneAsync(objet);
            }
            catch (MongoWriteException be)
            {
                Alt.Server.LogError(be.Message);
            }
        }

        public async static Task<ReplaceOneResult> Update<T>(T objet, string collectionName, object ID)
        {
            try
            {
                var collection = GetCollectionSafe<T>(collectionName);
                return await collection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", ID), objet);
            }
            catch (Exception be)
            {
                Alt.Server.LogError(be.Message);
            }

            return null;
        }

        public async static Task<DeleteResult> Delete<T>(string collectionName, object ID)
        {
            try
            {
                var collection = GetCollectionSafe<T>(collectionName);
                return await collection.DeleteOneAsync(Builders<T>.Filter.Eq("_id", ID));
            }
            catch (BsonException be)
            {
                Alt.Server.LogError(be.Message);
            }

            return null;
        }

        public static IMongoCollection<T> GetCollectionSafe<T>(string collectionName)
        {
            if (_database.GetCollection<T>(collectionName) == null)
                _database.CreateCollection(collectionName);

            return _database.GetCollection<T>(collectionName);
        }

        public static IMongoDatabase GetMongoDatabase() => _database;
        #endregion
    }
}
