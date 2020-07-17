using System;
using System.Globalization;
using Plugin.Multilingual;
using Xamarin.Essentials;

namespace ECommerce.Localization
{
    public interface ILocalizedResourceProvider
    {
        string GetText(string resourceKey, params object[] objects);
    }


    public class LocalizedResourceProvider : ILocalizedResourceProvider
    {
        public string GetText(string resourceKey, params object[] objects)
        {
            return LocalizedResourceHelper.GetText(resourceKey, objects);
        }
    }

    public class LocalizedResourceHelper
    {
        public static string GetText(string resourceKey, params object[] objects)
        {
            if (string.IsNullOrWhiteSpace(resourceKey))
            {
                return string.Empty;
            }

            var useEnglish = Preferences.Get("language", "en-US");
            //var ci = CrossMultilingual.Current.CurrentCultureInfo;
            var EN = CultureInfo.GetCultureInfo(useEnglish);

            string translation = App.ResourceManager.GetString(resourceKey, EN);

            if (translation == null)
            {
                translation = resourceKey;
            }

            if (objects == null || objects.Length == 0)
            {
                return translation;
            }

            try
            {
                return string.Format(translation, objects);
            }
            catch //(Exception e)//Logged-ex
            {
                return translation;
            }
        }
    }
}
