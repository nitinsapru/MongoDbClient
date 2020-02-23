using System;

namespace MongoDB.Exceptions
{
    [Serializable]
    public class MongoDbClientException : Exception
    {
        private readonly string stackTrace;

        public MongoDbClientException(string message, Exception ex)
            : base(message)
        {
            this.stackTrace = ex.StackTrace;
        }

        public MongoDbClientException(Exception ex) :
            base(ex.Message)
        {
            this.stackTrace = ex.StackTrace;
        }

        public MongoDbClientException()
        {
        }

        public override string StackTrace => this.stackTrace;

        public override Exception GetBaseException()
        {
            return base.GetBaseException();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
