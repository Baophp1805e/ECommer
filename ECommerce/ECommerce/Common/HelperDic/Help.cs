using System;
using System.Collections.ObjectModel;
using System.Linq;
using ECommerce.Home.Models;
using Prism.Mvvm;

namespace ECommerce.Common.HelperDic
{
    public class Help : BindableBase
    {
        public static Help Instance { get; } = new Help();
        public Help()
        {
            GroupedCart = new ObservableCollection<GroupedCartModel>();
            Store = new ObservableCollection<StoreModel>();
        }
        public ObservableCollection<GroupedCartModel> GroupedCart { get; set; }
        public ObservableCollection<StoreModel> Store { get; set; }

        public ProductModel Product { get; set; }

        public void AddProductToCart(ProductModel product, StoreModel store)
        {
            //var x = product;
            var grouped = new ObservableCollection<GroupedCartModel>();
            
            var Bao = new GroupedCartModel()
            {
                Store = store
            };
            if (Bao != null && Bao.Count > 0)
            {
                Bao.Add(product);
            }
            grouped.Add(Bao);
            GroupedCart = new ObservableCollection<GroupedCartModel>(grouped);
    }
    }
    public class BadgeModel : BindableBase
    {
        public string BadgeCount { set; get; }
    }
}
