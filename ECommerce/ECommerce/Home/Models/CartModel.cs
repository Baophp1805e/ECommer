using System;
using ECommerce.Customers.Model;
using Prism.Mvvm;

namespace ECommerce.Home.Models
{
    public class CartModel: BindableBase
    {
        public int Id { get; set; }
        public string StoreName { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public ProductModel[] Products { get; set; }
    }


}
