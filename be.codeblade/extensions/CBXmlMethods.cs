using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace be.codeblade.extensions
{
    public static class CBXmlMethods
    {
        /// <summary>Get the innerXml from an xElement</summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string InnerXml(this XElement element)
        {
            //Create a stringbuilder to store the innerxml
            StringBuilder innerXml = new StringBuilder();

            //loop over the nodes
            foreach (XNode node in element.Nodes())
            {
                // append node's xml string to innerXml
                innerXml.Append(node.ToString());
            }

            //Return the innerxml
            return innerXml.ToString();
        }

        /// <summary>Get the OuterXml from an xElement</summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string OuterXml(this XElement element)
        {
            //Create a stringbuilder to store the innerxml
            StringBuilder outerXml = new StringBuilder();

            outerXml.Append("<" + element.Name + ">");

            //loop over the nodes
            foreach (XNode node in element.Nodes())
            {
                // append node's xml string to innerXml
                outerXml.Append(node.ToString());
            }

            outerXml.Append("</" + element.Name + ">");

            //Return the innerxml
            return outerXml.ToString();
        }
    }
}
