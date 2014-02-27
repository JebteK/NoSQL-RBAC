using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JT.RBAC.Exceptions
{
    public class CouchbaseInvalidKeyException : Exception, ISerializable
    {
        private const string EXCEPTION_MESSAGE = "Invalid key or key is null";

        public object Model { get; private set; }
        public string ModelType { get; private set; }

        public CouchbaseInvalidKeyException(Interfaces.IModel model)
            : base(EXCEPTION_MESSAGE)
        {
            Model = model;
            ModelType = model.Type;
        }

        public CouchbaseInvalidKeyException(string modelType, object model)
            : base(EXCEPTION_MESSAGE)
        {
            Model = model;
            ModelType = modelType;
        }

        public CouchbaseInvalidKeyException(string modelType, object model, string message)
            : base(message)
        {
            Model = model;
            ModelType = modelType;
        }

        public CouchbaseInvalidKeyException(string modelType, object model, string message, Exception inner)
            : base(message, inner)
        {
            Model = model;
            ModelType = modelType;
        }

        protected CouchbaseInvalidKeyException(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");

            Model = (object)info.GetValue("Model", typeof(object));
            ModelType = (string)info.GetValue("ModelType", typeof(string));
        }
    }
}
