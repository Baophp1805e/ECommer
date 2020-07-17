using System;
using System.Threading.Tasks;
using ECommerce.Common.HelperDic;
using ECommerce.iOS;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(LocalCache))]
namespace ECommerce.iOS
{
    public class LocalCache : ILocalCache
    {
        public Task<T> GetData<T>(string Key)
        {
            string data = Foundation.NSUserDefaults.StandardUserDefaults.StringForKey(Key);
            if (data != null)
            {
                return Task.FromResult(JsonConvert.DeserializeObject<T>(data));
            }
            else
            {
                return Task.FromResult(JsonConvert.DeserializeObject<T>(""));
            }
        }
        public void RemoveData<T>(string Key)
        {
            Foundation.NSUserDefaults.StandardUserDefaults.RemoveObject(Key);
        }
        public void SetData<T>(string Key, T Value)
        {
            Foundation.NSUserDefaults defaults = Foundation.NSUserDefaults.StandardUserDefaults;
            if (defaults != null)
            {
                string value = JsonConvert.SerializeObject(Value);
                defaults.SetString(value != null ? value : String.Empty, Key);
                defaults.Synchronize();
            }
            else
            {
            }
        }
    }
}
