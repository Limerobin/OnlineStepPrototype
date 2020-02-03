using System;
using System.IO;
using System.Net;



namespace Prototype.RestClient
{
    class RestClient_Alpha
    {
        //An enumeration type (or enum type) is a value type defined by a set of named constants of the underlying integral numeric type.
        public enum HttpVerb
        {
            GET,POST,PUT,DELETE
        }
        //Class properties/variables
        public string EndPoint { get; set; }
        public HttpVerb HttpMethod { get; set; }

        //Constructor that instantiates url (endpoint) and HttpVerb
        public RestClient_Alpha()
        {
            EndPoint = string.Empty;
            HttpMethod = HttpVerb.GET;
        }

        //Returns the string as a stream of data from the Specified EndPoint(url)
        public string DoRequest()
        {
            string ResponseVal = string.Empty;
            //request object that takes a string(EndPoint) as a param
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(EndPoint);
            //Specifying the requst method i.e, GET in this case
            request.Method = HttpMethod.ToString();
            //using disposes of the object by limiting to a single method. This basically saves memomery by being
            //instantiating objects using "using", which automatically disposes of them when finished.
            //response checks whether the response var successful or not
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                //OK reponse = 200
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new ApplicationException("DoRequest exception" + response.StatusCode.ToString());
                }
                //Manipulate/process the response, this can be anything (json, xml, html etc..)
                using (Stream responseStream = response.GetResponseStream())
                {
                    if(responseStream != null)
                    {
                        //Expecting a stream of data
                        //Up to the user to do what ever they want with it
                        using (StreamReader reader = new StreamReader(responseStream))
                        {
                            //This is what returns
                            ResponseVal = reader.ReadToEnd();
                        }
                    }
                }
                response.Close();
            }       
            return ResponseVal;    
            
        }
    }
}
