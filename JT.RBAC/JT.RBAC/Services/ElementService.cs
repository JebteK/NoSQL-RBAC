using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase;
using Couchbase.Extensions;
using JT.RBAC.Models;
using JT.RBAC.Internal;

namespace JT.RBAC.Services
{
    public class ElementService : BaseClasses.ModelServicesBase
    {
        public const string KEY_PREFIX = KeyPrefixList.SecurityElement;

        public static ElementModel Load(string elementID)
        {
            string key = KEY_PREFIX + elementID;

            if (!client.KeyExists(key))
                return null;

            var node = client.GetJson<ElementModel>(key);

            return node;
        }

        public static string Save(ElementModel model)
        {
            if (string.IsNullOrEmpty(model.ElementID))
            {
                model.ElementID = GenerateDbKey(KEY_PREFIX);
                model.Created = DateTimeOffset.Now;
            }

            string key = KEY_PREFIX + model.ElementID;

            model.LastModified = DateTimeOffset.Now;

            if (client.StoreJson(Enyim.Caching.Memcached.StoreMode.Set, key, model))
            {
                return key;
            }

            Exceptions.CouchbaseSaveException ex =
                new Exceptions.CouchbaseSaveException(model.Type, model);

            throw (ex);
        }

        /// <summary>
        /// Check if this element is in our database, and accordingly add/update the element
        /// </summary>
        /// <param name="model">Element model</param>
        public static void Sync(ElementModel model)
        {
            ElementModel savedModel = FindByApplicationID(model.ElementApplicationID);

            if (savedModel == null)
            {
                //add it
                Save(model);
            }
            else
            {
                model.ElementID = savedModel.ElementID;
                Save(model);
            }
        }

        #region Views
        public static Couchbase.IView<ElementModel> GetAllElements()
        {
            var models = client.GetView<ElementModel>("Security", "GetAllElements")
                .Stale(StaleMode.False);

            return models;
        }

        public static ElementModel FindByApplicationID(string applicationID)
        {
            var models = client.GetView<ElementModel>("Security", "FindElementByApplicationID")
                .Key(applicationID)
                .Stale(StaleMode.False);

            foreach (ElementModel model in models)
                return model;

            return null;
        }
        #endregion
    }
}
