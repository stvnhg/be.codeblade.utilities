using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.codeblade.data
{
    /// <summary>
    /// Create a new RssChannel
    /// </summary>
    public class CBRssChannel
    {
        /// <summary>Set or get the title of the RssChannel</summary>
        public string title { get; set; }

        /// <summary>Set or get the link of the RssChannel</summary>
        public string link { get; set; }

        /// <summary>Set or get the desc of the RssChannel</summary>
        public string desc { get; set; }

        /// <summary>Set or get the items of the RssChannel</summary>
        public List<CBRssItem> items { get; set; }

        /// <summary>Create a new RssChannel with empty default values</summary>
        public CBRssChannel()
        {
            this.title = "";
            this.link = "";
            this.desc = "";
            this.items = new List<CBRssItem>();
        }

        /// <summary>Create a new RssChannel with the specified values</summary>
        /// <param name="title">The Title of the RssChannel</param>
        /// <param name="link">The link of the RssChannel</param>
        /// <param name="desc">The description of the RssChannel</param>
        public CBRssChannel(string title, string link, string desc)
        {
            this.title = title;
            this.link = link;
            this.desc = desc;
            this.items = new List<CBRssItem>();
        }

    }
}
