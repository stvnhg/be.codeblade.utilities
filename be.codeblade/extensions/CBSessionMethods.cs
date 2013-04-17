using System;
using System.Web.SessionState;

namespace be.codeblade.extensions
{
    public static class CBSessionMethods
    { 
        /// <summary>
        /// Gets a session value.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="name">The name of the session variable.</param>
        /// <returns>
        /// The session value. 
        /// If undefined or the value is not from the expected type, the type's default value is returned.
        /// </returns>
        public static T GetValue<T>(this HttpSessionState session, string name)
        {
            return (T)Convert.ChangeType(session[name], typeof(T));
        }

        /// <summary>
        /// Inserts an object in the session.
        /// </summary>
        /// <typeparam name="T">The type of the value.</typeparam>
        /// <param name="name">The name of the session variable.</param>
        /// <param name="value">The object you want to insert.</param>
        public static void insert<T>(this HttpSessionState session, string name, T value)
        {
            session[name] = value;
        }
    }
}
