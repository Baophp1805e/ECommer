using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ECommerce.Home.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
            
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            switch (CurrentPage)
            {
                case HomePage homePage:
                    Title = "Home";
                    break;
                case DealsPage dealsPage:
                    Title = "Deals";
                    break;
                case TagsPage tagsPage:
                    Title = "Tags";
                    break;
                case ProfilePage profilePage:
                    Title = "Profile";
                    break;
                case ShoppingCartPage shoppingCartPage:
                    Title = "Shopping Cart";
                    break;
            }
        }
    }
}
