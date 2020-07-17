using System;
using System.Threading.Tasks;
using Android.Content;
using ECommerce.Common.HelperDic;
using ECommerce.Droid.Localize;
using Newtonsoft.Json;

[assembly: Xamarin.Forms.Dependency(typeof(LocalCache))]
namespace ECommerce.Droid.Localize
{
    public class LocalCache : ILocalCache
    {
        public Task<T> GetData<T>(string Key)
        {
            ISharedPreferences Preferences = MainActivity.Instance.GetSharedPreferences("Sample", FileCreationMode.Private);
            string data = Preferences.GetString(Key, null);
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
            ISharedPreferences Preferences = MainActivity.Instance.GetSharedPreferences("Sample", FileCreationMode.Private);
            ISharedPreferencesEditor PreferencesEditor = Preferences.Edit();
            PreferencesEditor.Remove(Key);
            PreferencesEditor.Commit();
        }
        public void SetData<T>(string Key, T Value)
        {
            ISharedPreferences Preferences = MainActivity.Instance.GetSharedPreferences("Sample", FileCreationMode.Private);
            ISharedPreferencesEditor PreferencesEditor = Preferences.Edit();
            string value = JsonConvert.SerializeObject(Value);
            PreferencesEditor.PutString(Key, value);
            PreferencesEditor.Commit();
        }
    }
}
