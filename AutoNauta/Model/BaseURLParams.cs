using Microsoft.Win32;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;

namespace AutoNauta.Model
{
    public class BaseURLParams
    {
        public HttpContent getHttpContent()
        {
            loadFromRegistry();

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

        public void saveToRegistry()
        {
            // FIXME: Do not save the password as a plain text.
            PropertyInfo[] properties = this.GetType().GetProperties();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\AutoNauta");

            foreach (PropertyInfo property in properties)
            {
                
                key.SetValue(property.Name, property.GetValue(this, null).ToString());
            }
            key.Flush();
            key.Close();
        }

        public void loadFromRegistry()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AutoNauta");

            if (key != null)
            {
                foreach (PropertyInfo property in properties)
                    property.SetValue(this, key.GetValue(property.Name));

                key.Close();
            }
        }
    }
}
