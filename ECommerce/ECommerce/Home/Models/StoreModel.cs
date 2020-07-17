using System;
using Prism.Mvvm;

namespace ECommerce.Home.Models
{
    public class StoreModel: BindableBase
    {
        public int Id { get; set; }
        public string NameStoreOwner { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string BgShop { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public string Review { get; set; }
        public ProductModel[] Product { get; set; }
    }
}
