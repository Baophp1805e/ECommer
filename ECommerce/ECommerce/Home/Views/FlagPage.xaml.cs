using System;
using System.Collections.Generic;

using Xamarin.Forms;
using ZXing;
using ZXing.Net.Mobile.Forms;
using ZXing.QrCode;

namespace ECommerce.Home.Views
{
    public partial class FlagPage : ContentPage
    {
        public static string qrCode = "Hi Quynh";
        public FlagPage()
        {
            InitializeComponent();
            GenerateQR(qrCode);
        }

        async void btnScan_Clicked_1(System.Object sender, System.EventArgs e)
        {
            var scan = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scan.Scan();
            if (result != null)
            {
                myCode.Text = result.Text; 
            }
        }

        ZXingBarcodeImageView GenerateQR(string codeValue)
        {
            var qrCode = new ZXingBarcodeImageView
            {
                BarcodeFormat = BarcodeFormat.QR_CODE,
                BarcodeOptions = new QrCodeEncodingOptions
                {
                    Height = 350,
                    Width = 350
                },
                BarcodeValue = codeValue,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            // Workaround for iOS
            qrCode.WidthRequest = 350;
            qrCode.HeightRequest = 350;
            return qrCode;
        }
    }
}
