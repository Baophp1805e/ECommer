using System;
using System.Threading.Tasks;

namespace ECommerce.Common.HelperDic
{
    public interface ILocalCache
    {
        void SetData<T>(string Key, T Value);
        Task<T> GetData<T>(string Key);
        void RemoveData<T>(string Key);
    }
}
