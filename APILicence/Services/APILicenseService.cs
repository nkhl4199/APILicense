using APILicence.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace APILicence.Services
{
    public static class APILicenseService
    {
        private static IMongoCollection<APITransaction> _transactionCollection;
        private static string connection_string = "mongodb://mongostore:OEOwusWXM2V3Hc5x6RRbpuqBDfnz0dbxSgDjcJm00pWHgIAChuV8Rxmc9gBWqWO5ARjhsLspqXWnS4etc05D7A==@mongostore.mongo.cosmos.azure.com:10255/?ssl=true&retrywrites=false&replicaSet=globaldb&maxIdleTimeMS=120000&appName=@mongostore@";
        private static string database_name = "APILicense";
        private static string collection_name = "Transaction";

        static APILicenseService()
        {
            var mongoClient = new MongoClient(connection_string);

            var mongoDatabase = mongoClient.GetDatabase(database_name);

            _transactionCollection = mongoDatabase.GetCollection<APITransaction>(collection_name);
        }

        public static List<APITransaction> GetTransactions(string appID, string startDate, string endDate)
        {
            DateTime start_date = DateTime.Parse(startDate);
            DateTime end_date = DateTime.Parse(endDate);
            return _transactionCollection.AsQueryable<APITransaction>().Where(e => e.ServiceName == appID && e.TimeStamp >= start_date && e.TimeStamp <= end_date).ToList();
        }

        public static List<APITransaction> GetTransactions()
        {
            return _transactionCollection.AsQueryable<APITransaction>().ToList();
        }

        public static async Task AddTransaction(APITransaction transaction)
        {
            await _transactionCollection.InsertOneAsync(transaction);
        }
    }
}
