using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Xsl;

namespace be.codeblade.services
{
    public static class CBXsltTransformationService
    {
        public static XDocument transform(string xml_path, string xslt_path)
        {
            //Load the source xml
            XDocument source_xml = new XDocument();
            source_xml = XDocument.Load(xml_path);

            return CBXsltTransformationService.transform(source_xml, xslt_path);
        }

        public static XDocument transform(XDocument source_xml, string xslt_path)
        {
            //Create a var to store the result
            XDocument result_xml = new XDocument();

            //Create a new xml writer
            using (XmlWriter writer = result_xml.CreateWriter())
            {
                // Load the style sheet.
                XslCompiledTransform xslct = new XslCompiledTransform();
                XsltSettings settings = new XsltSettings();
                xslct.Load(xslt_path, settings, null);

                // Execute the transform and output the results to a writer.
                xslct.Transform(source_xml.CreateReader(), writer);
            }

            //Return the xml
            return result_xml;
        }
    }
}
