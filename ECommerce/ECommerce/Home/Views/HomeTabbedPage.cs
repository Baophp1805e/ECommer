using System;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;

namespace ECommerce.Home.Views
{
    public partial class HomeTabbedPage : Xamarin.Forms.TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
            On<Android>().SetIsSwipePagingEnabled(false);
            On<Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }

        //protected override void OnCurrentPageChanged()
        //{
        //    base.OnCurrentPageChanged();
        //    switch (CurrentPage)
        //    {
        //        case HomePage homePage:
        //            ToolbarItems.Clear();
        //            ToolbarItems.Add(toolbar);
        //            Title = "Home";
        //            break;
        //        case DealsPage dealsPage:
        //            ToolbarItems.Clear();
        //            ToolbarItems.Add(toolbar);
        //            Title = "Deals";
        //            break;
        //        case TagsPage tagsPage:
        //            ToolbarItems.Clear();
        //            ToolbarItems.Add(toolbar);
        //            Title = "Tags";
        //            break;
        //        case ProfilePage profilePage:
        //            ToolbarItems.Clear();
        //            ToolbarItems.Add(toolbar);
        //            Title = "Profile";
        //            break;
        //        case ShoppingCartPage shoppingCartPage:
        //            ToolbarItems.Clear();
        //            Title = "Shopping Cart";
        //            break;

        //    }
        //}

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            switch (CurrentPage)
            {
                case HomePage homePage:
                    {
                        txtTitle.Text = "Home";
                        btnSearch.IsVisible = true;
                        btnNext.IsVisible = false;
                        break;
                    }

                case DealsPage dealsPage:
                    {
                        btnSearch.IsVisible = true;
                        btnNext.IsVisible = false;
                        txtTitle.Text = "Deals";
                        break;
                    }

                case TagsPage tagsPage:
                    {
                        btnSearch.IsVisible = true;
                        btnNext.IsVisible = false;
                        txtTitle.Text = "Tags";
                        break;
                    }

                case ProfilePage profilePage:
                    {
                        btnSearch.IsVisible = true;
                        btnNext.IsVisible = false;
                        txtTitle.Text = "Profile";
                        break;
                    }

                case ShoppingCartPage shoppingCartPage:
                    {
                        txtTitle.Text = "Shopping Cart";
                        btnSearch.IsVisible = false;
                        btnNext.IsVisible = true;
                        break;
                    }
                case ProductDetailsPage shoppingCartPage:
                    {
                        txtTitle.Text = "Details";
                        btnSearch.IsVisible = false;
                        btnNext.IsVisible = true;
                        break;
                    }

            }
        }
    }
}
