using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using be.codeblade.controls;

namespace be.codeblade.data
{
    public class CBPaging
    {
        public int currentPage { get; set; }
        public int recordsPerPage { get; set; }
        public int totalPages { get; set; }
        public int totalRecords { get; set; }

        public CBPaging()
        {
            this.currentPage = 0;
            this.recordsPerPage = 0;
            this.totalPages = 0;
            this.totalRecords = 0;
        }

        public CBPaging(int currentPage, int recordsPerPage, int totalPages, int totalRecords)
        {
            this.currentPage = currentPage;
            this.recordsPerPage = recordsPerPage;
            this.totalPages = totalPages;
            this.totalRecords = totalRecords;
        }


        public Dictionary<int, string> getPaging(HttpRequest req)
        {
            //Load the querystring keys
            CBQueryStringGenerator qsg = new CBQueryStringGenerator(req);

            //Create a dictionary to store the pages
            Dictionary<int, string> lsPaging = new Dictionary<int, string>();

            //Do a loop for the amount of pages you have
            for (int i = 1; i <= this.totalPages; i++)
            {
                //Add or overwrite the p querystring parameter
                qsg.add("p", i.ToString(), true);

                //Add the page number and url to the dictionary
                lsPaging.Add(i, qsg.getQueryString());
            }

            //Return the dictionary
            return lsPaging;
        }
    }
}