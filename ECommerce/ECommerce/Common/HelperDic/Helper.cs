using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Prism.Mvvm;
using Prism.Services;
using Xamarin.Forms;

namespace ECommerce.Common.HelperDic
{
    public class Helper: BindableBase
    {
        public static Helper Instance { get; } = new Helper();
        public Helper()
        {

            CheckExistLang();

        }
        public string Currentlang;
        public async void CheckExistLang()
        {
            Currentlang =await  Xamarin.Forms.DependencyService.Get<ILocalCache>()
                    .GetData<string>(Plugin.DeviceInfo.CrossDeviceInfo.Current.Id + "lang");
            if (!string.IsNullOrEmpty(Currentlang))
            {
                if (LangOpt == null)
                {
                    
                        LangOpt = LoadTitlelang(Currentlang); //Loading Json file follow name language which saved
                   
                    
                }
            }
            else
            {
                if (LangOpt == null)
                    LangOpt = LoadTitlelang("en.json"); //Loading Json file follow name language default
                Currentlang = "en.json";
            }
        }

        private TittleLanguage langOpt;
        public TittleLanguage LangOpt
        {
            get => langOpt;
            set { SetProperty(ref langOpt, value); }
        }
        /// <summary>
        /// Getting language json file follow language
        /// </summary>
        /// <param name="nameFile"></param>
        /// <returns></returns>
        public TittleLanguage LoadTitlelang(string nameFile)
        {
            TittleLanguage list = new TittleLanguage();
            if (list.LangDictionary == null)
            {
                list.LangDictionary = new Dictionary<string, TitleHome>();
            }
            try
            {
                var type = this.GetType();
                var assembly = type.GetTypeInfo().Assembly;
                var name = assembly.GetName().Name;
                Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{nameFile}");
                using (var reader = new StreamReader(stream))
                {
                    var jsonString = reader.ReadToEnd();
                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        var listjson = JsonConvert.DeserializeObject<Dictionary<string, string>>(jsonString);
                        foreach (var item in listjson)
                        {
                            TitleHome ti = new TitleHome() { TitleDic = listjson[item.Key] };
                            if (!list.LangDictionary.ContainsKey(item.Key))
                            {
                                list.LangDictionary.Add(item.Key, ti);
                            }
                        }
                    }
                }
                Xamarin.Forms.DependencyService.Get<ILocalCache>().SetData(Plugin.DeviceInfo.CrossDeviceInfo.Current.Id + "lang", nameFile);
                Currentlang = nameFile;
                return list;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return list;
            }
        }
        /// <summary>
        /// again assigned of title after changing language
        /// </summary>
        /// <param name="nameFile"></param>
        public void ChangeLanguage(string nameFile)
        {
            var dic = LoadTitlelang(nameFile);
            foreach (var item in dic.LangDictionary)
            {
                LangOpt.LangDictionary[item.Key].TitleDic = item.Value.TitleDic;
            }
        }

    }
    public class TittleLanguage : BindableBase
    {
        private Dictionary<string, TitleHome> langDictionary;
        public Dictionary<string, TitleHome> LangDictionary
        {
            get => langDictionary;
            set
            {
                SetProperty(ref langDictionary, value);
            }
        }
    }

    public class TitleHome: BindableBase
    {
        private string titleDic;
        public string TitleDic
        {
            get => titleDic;
            set { SetProperty(ref titleDic, value); }
        }
    }
}
