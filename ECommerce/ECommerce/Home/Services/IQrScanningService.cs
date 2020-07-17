using System;
using System.Threading.Tasks;

namespace ECommerce.Home.Services
{
    public interface IQrScanningService
    {
        Task<string> ScanQrCodeAsync();
    }
}
