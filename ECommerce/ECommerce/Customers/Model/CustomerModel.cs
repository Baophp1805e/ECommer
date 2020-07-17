using System;
using ECommerce.Home.Models;
using Prism.Mvvm;

namespace ECommerce.Customers.Model
{
    public class CustomerModel: BindableBase
    {
        public int IdCustomers { get; set; }
        public string NameCustomer { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }
        public TagsModel Tag { get; set; }
        public bool isFollow { get; set; }
        public ProductModel Product { get; set; }
    }
}
