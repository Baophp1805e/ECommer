using System;
using Prism.Mvvm;

namespace ECommerce.Home.Models
{
    public class OrderModel: BindableBase
    {
        public int Id { get; set; }
        public string NameProduct { get; set; }
        public string Image { get; set; }
        public string DateOrdered { get; set; }
        public int isShip { get; set; }
        public string Status { get; set; }
    }

    public enum ViewMethod
    {
        View1, View2
    }
}
