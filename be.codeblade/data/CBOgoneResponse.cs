using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace be.codeblade.data
{
    public class CBOgoneResponse
    {
        public string orderId { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string paymentMethod { get; set; }
        public string acceptence { get; set; }
        public string status { get; set; }
        public string cardnumber { get; set; }
        public string ed { get; set; }
        public string cn { get; set; }
        public string trxdate { get; set; }
        public string payid { get; set; }
        public string ncerror { get; set; }
        public string brand { get; set; }
        public string ip { get; set; }
        public string shaOUTPassPhrase { get; set; }
        public string scoring { get; set; }
        public string sco_category { get; set; }
        public string aavcheck { get; set; }
        public string bin { get; set; }
        public string cccty { get; set; }
        public string cvccheck { get; set; }
        public string eci { get; set; }
        public string ipcty { get; set; }
        public string vc { get; set; }

        public CBOgoneResponse()
        {           
            this.aavcheck = "";
            this.acceptence = "";
            this.amount = "";
            this.bin = "";
            this.brand = "";
            this.cardnumber = "";
            this.cccty = "";
            this.cn = "";
            this.currency = "";
            this.cvccheck = "";
            this.eci = "";
            this.ed = "";
            this.ip = "";
            this.ipcty = "";
            this.ncerror = "";
            this.orderId = "";
            this.payid = "";
            this.paymentMethod = "";
            this.sco_category = "";
            this.scoring = "";
            this.shaOUTPassPhrase = "";
            this.status = "";
            this.trxdate = "";
            this.vc = "";
        }

    }
}
