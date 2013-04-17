using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Globalization;
using be.codeblade.data;

namespace be.codeblade.services
{
    public static class CBServices
    {
        /// <summary>
        /// Converts the specified string to a Guid
        /// </summary>
        /// <param name="v">String that needs to be converted</param>
        /// <returns>a Guid and will default to Guid.Empty when it can not be converted.</returns>
        public static Guid toGuid(string v)
        {
            //Set a default value -1
            Guid value = Guid.Empty;

            //Try converting the object and catch the exception if it crashes
            try { value = Guid.Parse(v); }
            catch (Exception) { }

            //Return the value
            return value;
        }

        /// <summary>
        /// Converts the specified object
        /// </summary>
        /// <param name="v">Object that needs to be converted</param>
        /// <returns>a decimal and will default to -1 when it can not be converted.</returns>
        public static decimal toDecimal(object v, CBEnumerations.Language lang)
        {
            //Set a default value -1
            decimal value = -1;
            
            //Set the culture info fro the conversion
            CultureInfo ci = new CultureInfo(CBLanguageManager.toInt32(lang));

            //Try converting the object and catch the exception if it crashes
            try { value = Convert.ToDecimal(v, ci); }
            catch (Exception) { }

            //Return the value
            return value;
        }

        /// <summary>
        /// Converts the specified object
        /// </summary>
        /// <param name="v">Object that needs to be cached</param>
        /// <returns>an integer and will default to -1 when it can not be converted.</returns>
        public static int toInt32(object v)
        {
            //Set a default value -1
            int value = -1;

            //Try converting the object and catch the exception if it crashes
            try { value = Convert.ToInt32(v); }
            catch (Exception) { }

            //Return the value
            return value;
        }

        /// <summary>
        /// Converts the specified object
        /// </summary>
        /// <param name="v">Object that needs to be cached</param>
        /// <returns>a long and will default to -1 when it can not be converted.</returns>
        public static long toInt64(object v)
        {
            //Set a default value -1
            long value = -1;

            //Try converting the object and catch the exception if it crashes
            try { value = Convert.ToInt64(v); }
            catch (Exception) { }

            //Return the value
            return value;
        }

        /// <summary>
        /// Converts the specified object
        /// </summary>
        /// <param name="v">Object that needs to be cached</param>
        /// <returns>a bool and will default to false when it can not be converted.</returns>
        public static bool toBool(object v)
        {
            //Set a default value false
            bool value = false;

            //Try converting the object and catch the exception if it crashes
            try { value = Convert.ToBoolean(v); }
            catch (Exception) { }

            //Return the value
            return value;
        }

        /// <summary>
        /// Converts the specified object
        /// </summary>
        /// <param name="v">Object that needs to be cached</param>
        /// <returns>a string and will default to "" when it can not be converted.</returns>
        public static string toString(object v)
        {
            //Set a default value -1
            string value = "";

            //Try converting the object and catch the exception if it crashes
            try { value = Convert.ToString(v); }
            catch (Exception) { }

            //Return the value
            return value;
        }

        public static int getRandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        /// <summary>
        /// Generates a unique sequence of random non zero values
        /// </summary>
        /// <param name="max">Max amount of characters to return</param>
        /// <param name="characters">Characters that can be used</param>
        /// <returns>Returns a unique sequence of random non zero values</returns>
        public static string getUniqueId(int max, string characters)
        {
            //Create a new array and store the characters
            char[] chars = characters.ToCharArray();

            //Create a new byte array
            byte[] data = new byte[1];

            //Generate a random string based on the data
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            
            //create an new instance of the byte array by max size
            data = new byte[max];

            //Fill the bytearray with a sequence of random non zero values
            crypto.GetNonZeroBytes(data);

            //Create a new stringbuilder
            StringBuilder result = new StringBuilder(max);

            //Loop over the non zero values
            foreach (byte b in data)
            {
                //And append to the stringbuilder
                result.Append(chars[b % (chars.Length - 1)]);
            }

            //Return the result
            return result.ToString();
        }


        /// <summary>
        /// Converts a long to a base (number of characters)
        /// </summary>
        /// <param name="N"></param>
        /// <param name="characters"></param>
        /// <returns></returns>
        public static string base10ToN(long value, string characters)
        {
            string R = "";
            while (value != 0)
            {
                R += characters[(int)(value % characters.Count())];
                value /= characters.Count();
            }
            return R;
        }
    }
}
