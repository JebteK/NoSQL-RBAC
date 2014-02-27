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
    public class RoleService : BaseClasses.ModelServicesBase
    {
        public const string KEY_PREFIX = KeyPrefixList.SecurityRole;
        public const string GlobalAdminRole = "GlobalAdmin";

        public static RoleModel Load(string roleID)
        {
            string key = KEY_PREFIX + roleID;

            if (!client.KeyExists(key))
                return null;

            var node = client.GetJson<RoleModel>(key);

            return node;
        }

        public static string Save(RoleModel model)
        {
            if (string.IsNullOrEmpty(model.RoleID))
            {
                model.RoleID = GenerateDbKey(KEY_PREFIX);
                model.Created = DateTimeOffset.Now;
            }

            string key = KEY_PREFIX + model.RoleID;

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
        /// Initialize the global admin role. NOTE: you must sync all elements first!
        /// </summary>
        public static void SyncGlobalAdmin()
        {
            //check if the global admin role exists, if not create it
            if (!client.KeyExists(KEY_PREFIX + GlobalAdminRole))
            {
                RoleModel globalAdmin = new RoleModel()
                {
                    RoleID = GlobalAdminRole,
                    Created = DateTimeOffset.Now,
                    RoleName = "Global Admin"
                };

                Save(globalAdmin);
            }

            //make sure the global admin role has read/write access to all elements
            Couchbase.IView<ElementModel> allElements = ElementService.GetAllElements();

            foreach (ElementModel element in allElements)
            {
                RoleElementAccessModel model = new RoleElementAccessModel()
                {
                    AccessLevel = Enums.SecurityAccessLevels.ReadWrite,
                    ElementID = element.ElementID,
                    RoleID = GlobalAdminRole
                };

                RoleElementAccessService.Save(model);
            }
        }

        #region Views
        public static Couchbase.IView<RoleModel> GetAllRoles()
        {
            var models = client.GetView<RoleModel>("Security", "GetAllRoles")
                .Stale(StaleMode.False);

            if (models.TotalRows == 0)
                return null;

            return models;
        }
        #endregion
    }
}
