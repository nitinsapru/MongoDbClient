namespace System
{
    public static class Extension
    {
        public static void ShouldNotBeNull(this object type)
        {
            if (type == null)
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentNullException("The value of the object should not be null.");
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }
        }

        public static void ShouldNotBeNullOrEmpty(this object type)
        {
            if (string.IsNullOrEmpty(type.ToString()))
            {
#pragma warning disable S3928 // Parameter names used into ArgumentException constructors should match an existing one 
                throw new ArgumentNullException("The value of the object should not be null or empty.");
#pragma warning restore S3928 // Parameter names used into ArgumentException constructors should match an existing one 
            }
        }
    }
}
