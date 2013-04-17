using System;
using System.Collections.Generic;
using System.Reflection;

namespace be.codeblade.extensions 
{
    /// <summary>Create a new PropertyComparer to compare the properties of the given object.</summary>
    /// <typeparam name="T">The object you want to compare</typeparam>
    public class CBPropertyComparer<T> : IEqualityComparer<T> 
    {
        private PropertyInfo _PropertyInfo;  

        /// <summary>Creates a new instance of PropertyComparer.</summary>
        /// <param name="propertyName">The name of the property on type T to perform the comparison on.</param>
        public CBPropertyComparer(string propertyName)
        {
            //store a reference to the property info object for use during the comparison
            _PropertyInfo = typeof(T).GetProperty(propertyName, BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.Public);
            if (_PropertyInfo == null)
            {
                throw new ArgumentException(string.Format("{0} is not a property of type {1}.", propertyName, typeof(T)));
            }
        }

        /// <summary>Check if the specified objects are equal</summary>
        /// <param name="x">First object</param>
        /// <param name="y">Second object</param>
        /// <returns>Wether the two object are equal or not</returns>
        public bool Equals(T x, T y)
        {
            //get the current value of the comparison property of x and of y
            object xValue = _PropertyInfo.GetValue(x, null);
            object yValue = _PropertyInfo.GetValue(y, null);

            //if the xValue is null then we consider them equal if and only if yValue is null
            if (xValue == null)
                return yValue == null;

            //use the default comparer for whatever type the comparison property is.
            return xValue.Equals(yValue);
        }

        /// <summary>Gets the hashcode of the object</summary>
        /// <param name="obj">The Object</param>
        /// <returns>The hascode of the object.</returns>
        public int GetHashCode(T obj)
        {
            //get the value of the comparison property out of obj
            object propertyValue = _PropertyInfo.GetValue(obj, null);

            if (propertyValue == null)
                return 0;

            else
                return propertyValue.GetHashCode();
        }
    }
}
