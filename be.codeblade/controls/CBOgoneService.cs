using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using be.codeblade.data;
using System.Web;
using System.Web.Security;
using System.Data.Linq;
using System.Collections.Specialized;

namespace be.codeblade.controls
{
    public class CBOgoneService
    {
        public CBOgoneRequest request { get; set; }
        private CBEnumerations.OGoneEnvironmentType AccountType;

        public CBOgoneService(CBEnumerations.OGoneEnvironmentType AccountType)
        {
            this.AccountType = AccountType;
            this.request = new CBOgoneRequest();
        }

        public string submit()
        {
            SortedDictionary<string, string> ls = new SortedDictionary<string, string>();
            ls.Add("ACCEPTURL", this.request.acceptUrl);
            ls.Add("AMOUNT", (this.request.amount * 100).ToString("#"));
            ls.Add("CANCELURL", this.request.cancelUrl);
            ls.Add("COM", this.request.message);
            ls.Add("CURRENCY", this.request.currency);
            ls.Add("DECLINEURL", this.request.declineUrl);
            ls.Add("EXCEPTIONURL", this.request.exceptionUrl);
            ls.Add("HOMEURL", this.request.homeUrl);
            ls.Add("LANGUAGE", this.getLanguage());
            ls.Add("OPERATION", this.request.operation.ToString());
            ls.Add("ORDERID", this.request.orderId);
            if (this.request.brand != "")
            {
                ls.Add("BRAND", this.request.brand);
                ls.Add("PM", this.request.pm);
            }
            else
            {
                ls.Add("PMLIST", String.Join(";", this.request.paymentMethods.ToArray())); 
            }           
            ls.Add("PSPID", this.request.pspid);
            if (!this.request.templatePage.Equals("")) { ls.Add("TP", this.request.templatePage); }

            //Build the ShaSign with the post values
            ls.Add("SHASIGN", this.getShaSign(ls, this.request.shaINPassPhrase));

            return this.createOgoneResponseForm(ls);
        }

        private string createOgoneResponseForm(SortedDictionary<string, string> ls)
        {
            //Create a string to store the html
            string html = "";

            //Build the html form
            html += "<html><head>";
            html += string.Format("</head><body onload=\"document.{0}.submit()\">", "frmOgone");
            html += string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", "frmOgone", "post", String.Format("https://secure.ogone.com/ncol/{0}/orderstandard_utf8.asp", this.AccountType.ToString().ToLower()));

            //Add the hidden input fields
            foreach (KeyValuePair<string, string> element in ls)
            {
                //If the value is not empty
                if (!element.Value.Equals(""))
                {
                    //add the field 
                    html += string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", element.Key, element.Value);
                }
            }
            
            //End the html
            html += "</form>";
            html += "</body></html>";

            //Return the html
            return html;
        }

        public bool isPaymentValid(string shaOUTPassPhrase, NameValueCollection nvc)
        {
            //Set the default value
            bool isValid = false;

            //Get all the default ogone parameters
            List<string> lsOgoneResponseValues = this.getOgoneResponseValues();

            //Create a dictionary to store all the ogone response values from the application
            SortedDictionary<string, string> qs = new SortedDictionary<string, string>();

            //Loop over the querystring values
            foreach (KeyValuePair<string, string> kvp in nvc.AllKeys.ToDictionary(k => k, k => nvc[k]))
            {
                //Check if the querystring key in an ogone response value
                if (lsOgoneResponseValues.Contains(kvp.Key.ToString().ToUpper()))
                {
                    //If the value is empty do not add it
                    if (!kvp.Value.ToString().Equals(""))
                    {
                        //if yes, add it to the dictionary
                        qs.Add(kvp.Key.ToString().ToUpper(), kvp.Value.ToString());
                    }
                }
            }

            //Sort the list
            qs.OrderBy(k => k.Key);

            if (this.getShaSign(qs, shaOUTPassPhrase).ToUpper().Equals(nvc["SHASIGN"].ToUpper()))
            {
                isValid = true;
            }

            return isValid;
        }

        private string getShaSign(SortedDictionary<string, string> ls, string shaPassPhrase)
        {
            //Create a value to store the result
            string value = "";

            //Loop over the keys
            foreach (KeyValuePair<string, string> kvp in ls)
            {
                //And attach the values
                value += String.Format("{0}={1}{2}", kvp.Key.ToString().ToUpper(), kvp.Value.ToString(), shaPassPhrase);
            }

            //Return the value
            return FormsAuthentication.HashPasswordForStoringInConfigFile(value, "sha1");
        }

        private string getShaSign(NameValueCollection nvc, string shaPassPhrase)
        {
            //Create a value to store the result
            string value = "";

            //Loop over the keys
            foreach (string key in nvc)
            {
                //And attach the values
                value += String.Format("{0}={1}{2}", key, nvc[key], shaPassPhrase);
            }

            //Return the value
            return FormsAuthentication.HashPasswordForStoringInConfigFile(value, "sha1");
        }

        private List<string> getOgoneResponseValues()
        {
            List<string> ls = new List<string>();
            ls.Add("AAVADDRESS"); 
            ls.Add("AAVCHECK"); 
            ls.Add("AAVZIP"); 
            ls.Add("ACCEPTANCE"); 
            ls.Add("ALIAS"); 
            ls.Add("AMOUNT");
            ls.Add("BIN"); 
            ls.Add("BRAND"); 
            ls.Add("CARDNO"); 
            ls.Add("CCCTY"); 
            ls.Add("CN"); 
            ls.Add("COMPLUS"); 
            ls.Add("CREATION_STATUS"); 
            ls.Add("CURRENCY");
            ls.Add("CVC"); 
            ls.Add("CVCCHECK"); 
            ls.Add("DCC_COMMPERCENTAGE"); 
            ls.Add("DCC_CONVAMOUNT"); 
            ls.Add("DCC_CONVCCY"); 
            ls.Add("DCC_EXCHRATE");
            ls.Add("DCC_EXCHRATESOURCE"); 
            ls.Add("DCC_EXCHRATETS"); 
            ls.Add("DCC_INDICATOR"); 
            ls.Add("DCC_MARGINPERCENTAGE"); 
            ls.Add("DCC_VALIDHOURS");
            ls.Add("DIGESTCARDNO"); 
            ls.Add("ECI"); 
            ls.Add("ED"); 
            ls.Add("ENCCARDNO"); 
            ls.Add("IP"); 
            ls.Add("IPCTY"); 
            ls.Add("NBREMAILUSAGE"); 
            ls.Add("NBRIPUSAGE"); 
            ls.Add("NBRIPUSAGE_ALLTX");
            ls.Add("NBRUSAGE"); 
            ls.Add("NCERROR"); 
            ls.Add("NCERRORCARDNO"); 
            ls.Add("NCERRORCN"); 
            ls.Add("NCERRORCVC"); 
            ls.Add("NCERRORED"); 
            ls.Add("ORDERID"); 
            ls.Add("PAYID");
            ls.Add("PM"); 
            ls.Add("SCO_CATEGORY"); 
            ls.Add("SCORING"); 
            ls.Add("STATUS"); 
            ls.Add("SUBBRAND"); 
            ls.Add("SUBSCRIPTION_ID"); 
            ls.Add("TRXDATE");
            ls.Add("VC");

            return ls;
        }

        private string getLanguage()
        {
            switch (this.request.language)
            {
                case CBEnumerations.Language.en_US:
                    return "en_EN";
                default:
                    return "en_EN";
            }
        }        
    }
}
