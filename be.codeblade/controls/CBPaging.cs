using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.codeblade.controls
{
    public class CBPaging
    {
        public int totalPages { get; private set; }
        private int totalResults { get; set; }
        private int itemsPerPage { get; set; }
        public string queryStringKey { get; set; }
        private CBQueryStringGenerator qsg { get; set; }

        public CBPaging(CBQueryStringGenerator qsg, int totalPages, int totalResults, int itemsPerPage, string queryStringKey)
        {
            this.totalPages = totalPages;
            this.itemsPerPage = itemsPerPage;
            this.qsg = qsg;
            this.totalResults = totalResults;
            this.queryStringKey = queryStringKey;
        }

        public Dictionary<int, string> get()
        {
            //Calculate the total number of pages
            this.totalPages = ((this.totalResults - 1) / itemsPerPage) + 1;

            //Create a dictionary to store the pages
            Dictionary<int, string> lsPaging = new Dictionary<int, string>();

            //Do a loop for the amount of pages you have
            for (int i = 1; i <= totalPages; i++)
            {
                //Add or overwrite the p querystring parameter
                qsg.add(this.queryStringKey, i.ToString(), true);

                //Add the page number and url to the dictionary
                lsPaging.Add(i, qsg.getQueryString());
            }

            //Return the dictionary
            return lsPaging;
        }
    }
}
