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
    public class RoleElementAccessService : BaseClasses.ModelServicesBase
    {
        public const string KEY_PREFIX = KeyPrefixList.SecurityRoleElementAccess;

        public static RoleElementAccessModel Load(string roleID, string elementID)
        {
            string key = KEY_PREFIX + roleID + "-" + elementID;

            if (!client.KeyExists(key))
                return null;

            var node = client.GetJson<RoleElementAccessModel>(key);

            return node;
        }

        public static string Save(RoleElementAccessModel model)
        {
            if (string.IsNullOrEmpty(model.RoleID) || string.IsNullOrEmpty(model.ElementID))
            {
                throw new Exception("RoleID and ElementID are both required.");
            }

            string key = KEY_PREFIX + model.RoleID + "-" + model.ElementID;

            //check if this is a new entry
            if (!client.KeyExists(key))
            {
                model.Created = DateTimeOffset.Now;
            }

            model.LastModified = DateTimeOffset.Now;

            if (client.StoreJson(Enyim.Caching.Memcached.StoreMode.Set, key, model))
            {
                return key;
            }

            Exceptions.CouchbaseSaveException ex =
                new Exceptions.CouchbaseSaveException(model.Type, model);

            throw (ex);
        }

        #region Views
        public static Couchbase.IView<RoleElementAccessModel> GetElementAccessForRole(string roleID)
        {
            var models = client.GetView<RoleElementAccessModel>("Security", "GetElementAccessForRole")
                .Key(roleID)
                .Stale(StaleMode.False);

            return models;
        }
        #endregion
    }
}
