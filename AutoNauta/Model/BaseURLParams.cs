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
            PropertyInfo[] properties = this.GetType().GetProperties();

            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (PropertyInfo property in properties)
            {
                dict.Add(property.Name, property.GetValue(this, null).ToString());
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
            key.Close();
        }

        public void loadFromRegistry()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\AutoNauta");

            foreach (PropertyInfo property in properties)
            {
                if (key.GetValue(property.Name) != null)
                    property.SetValue(this, key.GetValue(property.Name));
            }
            key.Close();
        }
    }
}
