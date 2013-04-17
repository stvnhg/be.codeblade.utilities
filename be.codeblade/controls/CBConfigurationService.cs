using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace be.codeblade.controls
{
    /// <summary>Create a new ConfigurationService</summary>
    public class CBConfigurationService
    {
        private XDocument document { get; set; }
        private Dictionary<string, string> items = new Dictionary<string, string>();

        /// <summary>Create a new ConfigurationService.</summary>
        /// <param name="path">The full path to the .config file</param>
        public CBConfigurationService(string path)
        {
            //Create a new XDocument to store the config file
            this.document = XDocument.Load(path);
            readConfigurationFile();
        }

        /// <summary>
        /// Read the configuration file and store the key and values in a Dictionary
        /// </summary>
        private void readConfigurationFile()
        {
            //Loop over every add element in the configuration file
            foreach (XElement add in this.document.Element("configuration").Elements("add"))
            {
                //Get the key and value from the element
                string key = add.Attribute("key").Value;
                string value = add.Attribute("value").Value;

                //Check if the key isn't allready added
                if (!items.ContainsKey(key))
                {
                    //if not add it to the dictionary
                    items.Add(key, value);
                }

            }
        }

        /// <summary>Gets a value by specified key</summary>
        /// <param name="key">Unique key to retrieve the correct value.</param>
        /// <returns>The value..</returns>
        public string get(string key)
        {
            try
            {
                //Return the value with the corresponding key from the Dictionary
                return this.items.Single(kvp => kvp.Key.Equals(key)).Value;
            }
            catch (KeyNotFoundException)
            {
                throw new KeyNotFoundException();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
