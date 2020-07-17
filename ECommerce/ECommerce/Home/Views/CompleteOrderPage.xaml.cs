using System;
using System.Collections.Generic;
using ECommerce.Home.CarouselView;
using Xamarin.Forms;

namespace ECommerce.Home.Views
{
    public partial class CompleteOrderPage : ContentPage
    {
        public CompleteOrderPage()
        {
            InitializeComponent();
            
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (BindingContext != null)
            {
                Init();
            }
        }

        private void Init()
        {
            var personalAndShip = new PersonalShippingDetailsPage();
            var reviewAndPurchase = new ReviewPurchasePage();
            personalAndShip.BindingContext = BindingContext;
            reviewAndPurchase.BindingContext = BindingContext;
            var list = new List<View>(){
                personalAndShip,reviewAndPurchase
            };
            csView.ItemsSource = list;
        }
    }
}
