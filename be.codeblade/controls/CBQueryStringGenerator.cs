using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using be.codeblade.extensions;

namespace be.codeblade.controls
{

    public class CBQueryStringGenerator
    {
        public List<KeyValuePair<string, string>> items { get; set; }

        public CBQueryStringGenerator()
        {
            this.items = new List<KeyValuePair<string, string>>();
        }

        public CBQueryStringGenerator(HttpRequest req)
            : this()
        {
            //Store all the keys in a collection
            List<string> allKeys = req.QueryString.AllKeys.ToList();

            //Loop over all the keys
            foreach (string key in allKeys)
            {
                //If the key does not allready exists
                if (!this.exists(key))
                {
                    //Add it to the collection
                    this.items.Add(new KeyValuePair<string, string>(key, req.QueryString.GetValue<string>(key)));
                }
            }
        }

        public string getQueryString()
        {
            //Create a list to store the formatted keys and values
            List<string> lsKeyValues = new List<string>();

            //Loop over all the keys
            foreach (KeyValuePair<string, string> kvp in this.items)
            {
                //And add them to the list
                lsKeyValues.Add(String.Format("{0}={1}", kvp.Key, kvp.Value));
            }

            return "?" + String.Join("&", lsKeyValues.ToArray());
        }

        public KeyValuePair<string, string> get(string key)
        {
            //Return the keyvaluepair from the list
            return this.items.SingleOrDefault(x => x.Key.ToLower().Equals(key.ToLower()));
        }

        public bool exists(string key)
        {
            //create the default value
            bool exists = false;

            //Check wether you found the key
            if (this.get(key).Key != null) { exists = true; }

            //Return the value
            return exists;
        }

        public void remove(string key)
        {
            if (this.exists(key) && this.get(key).Key != null)
            {
                this.items.Remove(this.get(key));
            }
        }

        public void add(string key, string value, bool overwrite)
        {
            //If the key does not allready exist
            if (!this.exists(key))
            {
                //Add it to the collection
                this.items.Add(new KeyValuePair<string, string>(key, value));
            }
            else if (overwrite)
            {
                //remove the key
                this.remove(key);

                //Add it again with the new value
                this.add(key, value, overwrite);
            }
        }

        public void addRange(string url)
        {
            //check if the url has a querystring
            if (url.Contains("?"))
            {
                //Remove the ? character
                url = url.Substring(url.IndexOf('?') + 1);

                //Create a list and split the values
                List<string> ls = new List<string>();
                ls.AddRange(url.Split('&'));

                //Loop over the list
                foreach (string keyvalue in ls)
                {
                    try
                    {
                        //Try to retrieve the key and value
                        string key = keyvalue.Substring(0, keyvalue.IndexOf("="));
                        string value = keyvalue.Substring(keyvalue.IndexOf("=") + 1);

                        //If the key does not allready exists
                        if (!this.exists(key))
                        {
                            //Add it to the collection
                            this.items.Add(new KeyValuePair<string, string>(key, value));
                        }
                        else
                        {
                            //If the key exists, overwrite the existing one
                            this.add(key, value, true);
                        }
                    }
                    catch (Exception) { /* Do nothing */ }
                }

            }
        }

        public void addRange(List<KeyValuePair<string, string>> items, bool overwrite)
        {
            foreach (KeyValuePair<string, string> kvp in items)
            {
                this.add(kvp.Key, kvp.Value, overwrite);
            }
        }

        public void clear()
        {
            //Clear the list
            this.items.Clear();
        }
    }
}
