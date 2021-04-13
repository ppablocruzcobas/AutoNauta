using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace AutoNauta.Model
{
    public class BaseQueryParams
    {
        public HttpContent GetHttpContent()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();

            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(this, null);
                if (value != null) 
                    dict.Add(property.Name, value.ToString());
            }

            return new FormUrlEncodedContent(dict);
        }
    }
}
