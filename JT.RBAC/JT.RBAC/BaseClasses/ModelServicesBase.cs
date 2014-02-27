using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Extensions;

namespace JT.RBAC.BaseClasses
{
    public abstract class ModelServicesBase
    {
        protected const int DB_KEY_LENGTH = 10;
        protected const int ACCOUNT_KEY_LENGTH = 12;
        protected const int BILLING_KEY_LENGTH = 16;

        /// <summary>
        /// Couchbase Client
        /// </summary>
        protected static CouchbaseClient client = new CouchbaseClient();

        /// <summary>
        /// Generates an unique key, and checks to make sure it does not already exist!
        /// </summary>
        /// <param name="keyPrefix">CouchBase key prefix used for checks</param>
        /// <returns>Unique key for the given model/key prefix</returns>
        public static string GenerateDbKey(string keyPrefix)
        {
            string key = GenerateKey(keyPrefix, DB_KEY_LENGTH);

            return key;
        }

        /// <summary>
        /// Generates an unique key, and checks to make sure it does not already exist!
        /// </summary>
        /// <param name="keyPrefix">CouchBase key prefix used for checks</param>
        /// <param name="length">Number of unique characters</param>
        /// <returns>Unique key for the given model/key prefix, with the given length</returns>
        public static string GenerateKey(string keyPrefix, int length)
        {
            string key;

            Random rnd = new Random();
            byte[] b = new byte[length];

            do
            {
                rnd.NextBytes(b);
                key = Convert.ToBase64String(b);

                key = key.Replace("+", "_");
                key = key.Replace("/", "s");
                key = key.Replace("=", "E");
            }
            while (client.KeyExists(keyPrefix + key));

            return key;
        }
    }
}
