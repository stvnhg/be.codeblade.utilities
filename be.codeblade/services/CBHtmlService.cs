using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.codeblade.services
{
    public static class CBHtmlService
    {
        public static string formatNewLinesToParagraphs(string p)
        {
            if (p.Contains("\n\n"))
            {
                return "<p>" + p
                    .Replace("\n\n", "</p><p>")
                    .Replace("\n", "<br />")
                    .Replace("</p><p>", "</p>" + "\n" + "<p>") + "</p>";
            }
            else
            {
                return "<p>" + p
                    .Replace(Environment.NewLine + Environment.NewLine, "</p><p>")
                    .Replace(Environment.NewLine, "<br />")
                    .Replace("</p><p>", "</p>" + Environment.NewLine + "<p>") + "</p>";
            }
        }
    }
}
