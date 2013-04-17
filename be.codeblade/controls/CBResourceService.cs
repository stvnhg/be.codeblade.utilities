using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace be.codeblade.controls
{

    /// <summary>Create a new ResourceService</summary>
    public class CBResourceService
    {
        private ResXResourceReader reader { get; set; }
        private IEnumerable<DictionaryEntry> enumerator { get; set; }

        /// <summary>Create a new ResourceService.</summary>
        /// <param name="path">The full path to the .resx file</param>
        /// <param name="lang">Language you want to retrieve</param>
        public CBResourceService(string path)
        {
            //Create an  new instance of the resxReader
            this.reader = new ResXResourceReader(path);
            this.enumerator = this.reader.OfType<DictionaryEntry>();
        }

        /// <summary>Gets a value by specified key</summary>
        /// <param name="key">Unique key to retrieve the correct value.</param>
        /// <returns>The value..</returns>
        public string get(string key)
        {
            try
            {
                //Return the value with the corresponding key
                return this.enumerator.Single(k => k.Key.ToString() == key).Value.ToString();
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
