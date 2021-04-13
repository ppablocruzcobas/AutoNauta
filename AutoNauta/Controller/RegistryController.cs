using Microsoft.Win32;
using System.Reflection;

namespace AutoNauta.Controller
{
    public class RegistryController
    {
        private readonly string KEY = @"SOFTWARE\AutoNauta";

        public void Save(object obj)
        {
            // FIXME: Do not save the password as a plain text.
            PropertyInfo[] properties = obj.GetType().GetProperties();
            RegistryKey key = Registry.CurrentUser.CreateSubKey(KEY);

            foreach (PropertyInfo property in properties)
            {
                var value = property.GetValue(obj, null);
                if (value != null)
                    key.SetValue(property.Name, value.ToString());
            }
            key.Flush();
            key.Close();
        }

        public void Load(object obj)
        {
            PropertyInfo[] properties = obj.GetType().GetProperties();
            RegistryKey key = Registry.CurrentUser.OpenSubKey(KEY);

            if (key != null)
            {
                foreach (PropertyInfo property in properties)
                    property.SetValue(obj, key.GetValue(property.Name));

                key.Close();
            }
        }
    }
}
