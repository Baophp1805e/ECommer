using System;
using System.Collections.ObjectModel;
using Prism.Mvvm;

namespace ECommerce.Home.Models
{
    public class ProductModel: BindableBase
    {
        public int IdProduct { get; set; }
        public string ProductionCode { get; set; }
        public string NameProduct { get; set; }
        public string Image { get; set; }
        public ImageProductModel[] ImageArray { get; set; }
        public string Manufacturer { get; set; }
        public string Description { get; set; }
        public string Desmini { get; set; }
        public string Price { get; set; }
        public int IdStore { get; set; }
        public int quantity { get; set; }
        public ProductModel product { get; set; }
    }

    public class GroupedCartModel : ObservableCollection<ProductModel>
    {
        public StoreModel Store { get; set; }
    }
}
