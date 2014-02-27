using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace JT.RBAC.Exceptions
{
    public class CouchbaseSaveException : Exception, ISerializable
    {
        private const string EXCEPTION_MESSAGE = "Unable to save data to Couchbase";

        public object Model { get; private set; }
        public string ModelType { get; private set; }

        public CouchbaseSaveException(Interfaces.IModel model)
            : base(EXCEPTION_MESSAGE)
        {
            Model = model;
            ModelType = model.Type;
        }

        public CouchbaseSaveException(string modelType, object model)
            : base(EXCEPTION_MESSAGE)
        {
            Model = model;
            ModelType = modelType;
        }

        public CouchbaseSaveException(string modelType, object model, string message)
            : base(message)
        {
            Model = model;
            ModelType = modelType;
        }

        public CouchbaseSaveException(string modelType, object model, string message, Exception inner)
            : base(message, inner)
        {
            Model = model;
            ModelType = modelType;
        }

        protected CouchbaseSaveException(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            Model = (object)info.GetValue("Model", typeof(object));
            ModelType = (string)info.GetValue("ModelType", typeof(string));
        }
    }
}
