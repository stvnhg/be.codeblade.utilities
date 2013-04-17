using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.codeblade.data
{
    /// <summary>
    /// Create a new RssItem
    /// </summary>
    public class CBRssItem
    {
        /// <summary>Set or get the title of the RssItem</summary>
        public string title { get; set; }

        /// <summary>Set or get the link of the RssItem</summary>
        public string link { get; set; }

        /// <summary>Set or get the desc of the RssItem</summary>
        public string desc { get; set; }

        /// <summary>Set or get the guid of the RssItem</summary>
        public string guid { get; set; }

        /// <summary>Set or get the Publication date of the RssItem</summary>
        public DateTime publicationDate { get; set; }

        /// <summary>Create a new RssItem with empty default values</summary>
        public CBRssItem()
        {
            this.title = "";
            this.link = "";
            this.desc = "";
            this.guid = "";
            this.publicationDate = DateTime.MinValue;
        }

        /// <summary>Creates a new RssItem with the specified values</summary>
        /// <param name="title">The title of the RSS item</param>
        /// <param name="link">The link of the RSS item</param>
        /// <param name="desc">The description of the RSS item</param>
        /// <param name="guid">Unique link to the item</param>
        /// <param name="publicationDate">Publication date of the item</param>
        public CBRssItem(string title, string link, string desc, string guid, DateTime publicationDate)
        {
            this.title = title;
            this.link = link;
            this.desc = desc;
            this.guid = guid;
            this.publicationDate = publicationDate;
        }
    }
}
