using System;

namespace CrestApps.Core.Data.Abstraction
{
    [Serializable]
    public class ModelNotFoundException : Exception
    {
        public ModelNotFoundException()
            : base("The requested model does not exists")
        {

        }

        public ModelNotFoundException(string message)
            : base(message)
        {

        }
    }
}

