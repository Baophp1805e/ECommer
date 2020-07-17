using System;
using System.Collections.Generic;
using ZXing.Net.Mobile.Forms;

using Xamarin.Forms;

namespace ECommerce.Customers.Views
{
    public partial class LandingPage : ContentPage
    {
        ZXingBarcodeImageView barcode;
        public LandingPage()
        {
            InitializeComponent();
            barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView",
            };
            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeOptions.Width = 300;
            barcode.BarcodeOptions.Height = 300;
            barcode.BarcodeOptions.Margin = 10;
            barcode.BarcodeValue = "Hi Quynh";

            //this.Content = barcode
            imageQrCode.Children.Insert(1, barcode);

        }
    }
}
