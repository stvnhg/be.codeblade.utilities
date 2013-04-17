using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

using be.codeblade.data;

namespace be.codeblade.controls
{
    /// <summary>Create a new RssGenerator</summary>
    public class CBRssGenerator
    {
        /// <summary>Get or set the RSS declaration.</summary>
        public XDeclaration declaration { get; set; }

        /// <summary>Get or set the atom namespace.</summary>
        public XNamespace atom { get; set; }

        /// <summary>Create a new instance of the RSSGenerator</summary>
        /// <param name="declaration">Set the RSS declaration.</param>
        /// <param name="atom">Set the atom namespace.</param>
        public CBRssGenerator(XDeclaration declaration, XNamespace atom)
        {
            this.declaration = declaration;
            this.atom = atom;
        }

        /// <summary>Generates a RSS document with the RssChannel</summary>
        /// <param name="channel">The RssChannel object</param>
        /// <returns>Rss Document</returns>
        public XDocument generate(CBRssChannel channel)
        {
            //Create a new xml document and start building the channel element
            XDocument xml = new XDocument(this.declaration,
                new XElement("rss", new XAttribute("version", "2.0"), new XAttribute(XNamespace.Xmlns + "atom", this.atom),
                    new XElement("channel",
                        new XElement("title", channel.title),
                        new XElement("link", channel.link),
                        new XElement(this.atom + "link", new XAttribute("href", channel.link), new XAttribute("rel", "self"), new XAttribute("type", "application/rss+xml")),
                        new XElement("description", channel.desc)
                        )
                    )
                );

            //Now loop over the list of items and add them to the channel in the xml
            foreach (CBRssItem item in channel.items)
            {
                xml.Root.Element("channel").Add(
                    new XElement("item",
                        new XElement("title", item.title),
                        new XElement("link", item.link),
                        new XElement("description", item.desc),
                        new XElement("guid", item.guid),
                        new XElement("pubDate", String.Format("{0:r}", item.publicationDate)) //Wed, 02 Oct 2002 13:00:00 GMT
                        )
                    );
            }

            //Return the xml
            return xml;
        }
    }
}
