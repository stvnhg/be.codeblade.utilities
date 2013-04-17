using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.codeblade.extensions
{
    public static class CBTraceMethods
    {
        public static string ToString<T>(this T o)
        {
            //Create a new stringbuilder to store the result
            StringBuilder result = new StringBuilder();

            //Get the object type
            Type ot = o.GetType();

            //Loop over the properties
            foreach (var p in ot.GetProperties())
            {
                //Construct the line
                result.AppendFormat("{0} [type = {1}] [value = {2}],{3}", p.Name, p.PropertyType, p.GetValue(o, null), Environment.NewLine);
            }

            //Return the result
            return result.ToString();
        }
    }
}
