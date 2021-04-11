using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace AutoNauta.Model
{
    public class BaseURLParams
    {
        public HttpContent getHttpContent()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();

            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (PropertyInfo property in properties)
            {
                dict.Add(property.Name, property.GetValue(this, null).ToString());
            }

            return new FormUrlEncodedContent(dict);
        }
    }
}
