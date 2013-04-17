using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace be.codeblade.extensions
{
    public static class CBNameValueCollectionMethods
    {
        public static bool exists(this NameValueCollection nvc, string key)
        {
            bool exists = false;

            //If the collection is null, throw an argementNullException
            if (nvc == null) { throw new ArgumentNullException("NameValueCollection"); }

            //If the key is null, throw an argementNullException
            if (nvc[key] != null) { exists = true; }

            return exists;
        }

        public static T GetValue<T>(this NameValueCollection nvc, string key)
        {
            //If the collection is null, throw an argementNullException
            if (nvc == null) { throw new ArgumentNullException("NameValueCollection"); }

            //If the key is null, throw an argementNullException
            if (nvc[key] == null) { throw new ArgumentOutOfRangeException("key"); }
            
            //Store the value
            var value = nvc[key];

            //Get the type of T
            var converter = TypeDescriptor.GetConverter(typeof(T));

            //If the converter can not convert
            if (!converter.CanConvertFrom(value.GetType()))
            {
                throw new ArgumentException(String.Format("Cannot convert '{0}' to {1}", value, typeof(T)));
            }

            //Convert and return the value
            return (T)converter.ConvertFrom(value);
        }
    }
}
