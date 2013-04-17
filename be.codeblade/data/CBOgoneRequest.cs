using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.codeblade.data
{
    public class CBOgoneRequest
    {
        public string acceptUrl { get; set; }
        public decimal amount { get; set; }
        public string cancelUrl { get; set; }
        public string message { get; set; }
        public string currency { get; set; }
        public string declineUrl { get; set; }
        public string exceptionUrl { get; set; }
        public string homeUrl { get; set; }
        public CBEnumerations.Language language { get; set; }
        public string orderId { get; set; }
        public string pspid { get; set; }
        public string shaINPassPhrase { get; set; }
        public List<string> paymentMethods { get; set; }
        public CBEnumerations.OGoneOperations operation { get; set; }
        public string brand { get; set; }
        public string pm { get; set; }
        public string templatePage { get; set; }

        public CBOgoneRequest()
        {
            this.acceptUrl = "";
            this.amount = 0;
            this.cancelUrl = "";
            this.message = "";
            this.currency = "";
            this.declineUrl = "";
            this.exceptionUrl = "";
            this.homeUrl = "";
            this.language = CBEnumerations.Language.en_US;
            this.orderId = "";
            this.pspid = "";
            this.shaINPassPhrase = "";
            this.paymentMethods = new List<string>();
            this.operation = CBEnumerations.OGoneOperations.SAL;
            this.brand = "";
            this.pm = "";
            this.templatePage = "";
        }
    }
}
